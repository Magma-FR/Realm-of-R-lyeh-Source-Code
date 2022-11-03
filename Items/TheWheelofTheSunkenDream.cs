using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;
using RealmOne;
using RealmOne.Common.Systems;
using RealmOne.Common;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.GameContent.RGB;

namespace RealmOne.Items
{
    public class TheWheelofTheSunkenDream : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Wheel Of The Sunken Dream"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Throws the ignominy and tattered wheel of the abortive dream "
                + "\n'Homes and urges anything that survived the yore skirmish'"
                + "\nVendetta is never balanced and never will be. Each 2nd or 4th shot is random");
                


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 3984;
            Item.DamageType = DamageClass.Melee;
            Item.width = 84;
            Item.height = 80;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 1;
            Item.knockBack = 3f;
            Item.value = 10000;
            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.DD2_DarkMageSummonSkeleton;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.holdStyle = ItemHoldStyleID.HoldGuitar;
            Item.crit = 10;
            
            
            Item.shoot = ModContent.ProjectileType<PirateWheelProjectile>();
            Item.shootSpeed = 30f;
            Item.noMelee = true;
            Item.channel = true;
            
            
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
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(70,53, 109, 60), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(50, 194, 150, 66), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.SeaGreen.ToVector3() * 0.6f);

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.BoneTorch, velocity);
                dust.scale = 2f;
                dust.fadeIn = 1.1f;
                dust.noGravity = true;
                dust.noLight = true;
                dust.alpha = 0;
                
            }
        }
        

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
       
    }
}