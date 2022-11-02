using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Projectiles;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Collections.Generic;

namespace RealmOne.Items
{

    public class PhantomPumpkin : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Flicker a whisp of Phantom Flames that hunt and burn enemies into a crisp");
            DisplayName.SetDefault("Phantom Pumpkin");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 6));
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.mana = 6;
            Item.damage = 80;
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 5f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Yellow;
            Item.shootSpeed = 40f;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.UseSound = SoundID.DD2_PhantomPhoenixShot;
            Item.useStyle = ItemUseStyleID.RaiseLamp;
            Item.value = Item.buyPrice(gold: 4, silver: 11);

            Item.crit = 8;
            Item.shoot = ModContent.ProjectileType<FlamePumpkinProj>();
        }
        public override bool OnPickup(Player player)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath6);
            return true;
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
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(0); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(6);
            position += Vector2.Normalize(velocity) * 22f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<FlamePumpkinProj>(), damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.LightCyan.ToVector3() * 1f);

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.WitherLightning, velocity);
                dust.scale = 1f;
                dust.fadeIn = 1.1f;
                dust.noGravity = true;
                dust.noLight = true;
                dust.alpha = 0;
            }
        }
      
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "PhantomPumpkin", "'No lollies in this bucket this time, only flames of the dead!'")
            {
                OverrideColor = new Color(18, 240, 180)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "PhantomPumpkin", "'HAPPY HALLOWEEN'")
            {
                OverrideColor = new Color(240, 143, 10)

            };
            tooltips.Add(line);


        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Ectoplasm, 15)
            .AddIngredient(ItemID.Pumpkin, 35)
            .AddIngredient(ItemID.SpookyWood, 30)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(3, -3);
            return offset;
        }

    }
}