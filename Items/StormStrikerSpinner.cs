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
    internal class StormStrikerSpinner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Striker Spinner"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("The perfect skull basher!!");
              


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 4f;
            Item.value = 30000;
            Item.rare = 1;
            Item.autoReuse = true;
            Item.crit = 2;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<StormStrikerSpinnerProj>();
            Item.shootSpeed = 90f;
            Item.UseSound = SoundID.DD2_SkyDragonsFurySwing;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            
                
        }
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "StormStrikerSpinner", "'Spin and oversized dual sided Storm Spear that circles you with stormdust!'")
            {
                OverrideColor = new Color(80, 209, 150)

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
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(118, 240, 209, 30), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(196, 120, 255, 30), rotation, frameOrigin, scale, SpriteEffects.None, 0);
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

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.Sandnado, velocity);
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

            .AddIngredient(ItemID.BoneJavelin, 50)
            .AddIngredient(ItemID.SandBlock, 25)
            .AddIngredient(ItemID.FossilOre, 10)

            .AddTile(TileID.Anvils)
            .Register();

        }

    
        

       
        
      

       

    }
    internal class StormStrikerSpinnerProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 132;
            Projectile.height = 132;
            Projectile.penetrate = -2;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.aiStyle = ProjAIStyleID.SleepyOctopod;
            AIType = ProjectileID.MonkStaffT3;
            
        }








    }
}