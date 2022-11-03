using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.Audio;
using RealmOne.Common;
using RealmOne.Common.Systems;
using static Terraria.ModLoader.ModContent;

namespace RealmOne.Items
{
    internal class OldGoldGuillotines : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Gold Guillotines"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Slash and penetrate your foes with these ancient and sharp chains'");
              


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.knockBack = 4;
            Item.value = 30000;
            Item.rare = 3;
            Item.autoReuse = true;
            Item.crit = 3;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<OldGoldHookProjectile>();
            Item.shootSpeed = 29f;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/OldGoldChainSound");
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.channel = true;
            
            
        
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "OldGoldGuillotines", "'Whips out a sharp, gold guillotine with a sharp end that does guaranteed critical strike chance")
            {
                OverrideColor = new Color(254, 226, 82)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "OldGoldGuillotines", "'Pristinity!'")
            {
                OverrideColor = new Color(18, 240, 180)

            };
            tooltips.Add(line);


        }

        

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            else
                frame = texture.Frame();

            Vector2 frameOrigin = frame.Size() / 2f;
            Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
                time = 2f - time;

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.25f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(118, 240, 209, 70), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(196, 120, 255, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.LightCyan.ToVector3() * 0.5f);

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.Enchanted_Gold, velocity);
                dust.scale = 0.8f;
                dust.fadeIn = 1.1f;
                dust.noGravity = true;
                dust.noLight = true;
                dust.alpha = 0;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(Mod, "OldGoldBar", 8)
            .AddIngredient(ItemID.Chain, 10)

            .AddTile(TileID.Anvils)
            .Register();

        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
        internal class OldGoldHookProjectile : ModProjectile
        {

            private static Asset<Texture2D> chainTexture;

            public override void Load()
            { // This is called once on mod (re)load when this piece of content is being loaded.
              // This is the path to the texture that we'll use for the hook's chain. Make sure to update it.
                chainTexture = ModContent.Request<Texture2D>("RealmOne/Projectiles/OldGoldChainProjectile");
            }

            public override void Unload()
            { // This is called once on mod reload when this piece of content is being unloaded.
              // It's currently pretty important to unload your static fields like this, to avoid having parts of your mod remain in memory when it's been unloaded.
                chainTexture = null;
            }

            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("${ProjectileName.ChainGuillotine}");
            }

            public override void SetDefaults()
            {
                // Copies the attributes of the Amethyst hook's projectile.
                Projectile.width = 34;
                Projectile.height = 18;
                Projectile.tileCollide = true;
                Projectile.penetrate = -2;
                Projectile.DamageType = DamageClass.Melee;
                Projectile.damage = 28;
                Projectile.CloneDefaults(ProjectileID.ChainGuillotine);
                Projectile.aiStyle = ProjAIStyleID.Harpoon;
                AIType = ProjectileID.ChainGuillotine;
                Projectile.light = 0.7f;
                Projectile.CritChance = 100;
                
               
                
            }
            // Amethyst Hook is 300, Static Hook is 600.

            public override void Kill(int timeLeft)
            {
                for (var i = 0; i < 6; i++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sandnado, 0f, 0f, 0, default(Color), 0.6f);
                }

                Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            }
            public override bool PreDrawExtras()
            {
                Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
                Vector2 center = Projectile.Center;
                Vector2 directionToPlayer = playerCenter - Projectile.Center;
                float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
                float distanceToPlayer = directionToPlayer.Length();

                while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
                {
                    directionToPlayer /= distanceToPlayer; // get unit vector
                    directionToPlayer *= chainTexture.Height(); // multiply by chain link length

                    center += directionToPlayer; // update draw position
                    directionToPlayer = playerCenter - center; // update distance
                    distanceToPlayer = directionToPlayer.Length();

                    Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

                    // Draw chain
                    Main.EntitySpriteDraw(chainTexture.Value, center - Main.screenPosition,
                        chainTexture.Value.Bounds, drawColor, chainRotation,
                        chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);
                }
                // Stop vanilla from drawing the default chain.
                return false;
            }
            public override void AI()
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Enchanted_Gold, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
            }


        }
       
        
      

       

    }
}