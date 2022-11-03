using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using RealmOne.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using RealmOne.Accessories;

namespace RealmOne.Items
{
    public class SpaceStarfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Starfish");
            Tooltip.SetDefault("<right> to receive Lustrea's recommendations"
            
                + "\nBelow are the Weapons you get from it!(You also get other necessities!)"
          
           
             + $"\n[i:{ModContent.ItemType<DualWieldCrossbows>()}][i:{ModContent.ItemType<DumLightbulb>()}]"
                          + $"\n[i:{ModContent.ItemType<ShatteredGemBlade>()}][i:{ModContent.ItemType<EmptyLocket>()}]");

        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Expert;
            Item.consumable = true;
            Item.maxStack = 1;

        }
        public override bool CanRightClick()
        {
            return true;
        }


        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ItemID.WoodenArrow, 1, 100, 100));
            itemLoot.Add(ItemDropRule.Common(ItemID.WoodPlatform, 1, 35, 35));
            itemLoot.Add(ItemDropRule.Common(ItemID.Aglet, 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ItemID.RecallPotion, 1, 10, 10));
            itemLoot.Add(ItemDropRule.Common(ItemID.BlandWhip, 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ItemID.ManaCrystal, 1, 4, 4));
            itemLoot.Add(ItemDropRule.Common(ItemID.LifeCrystal, 1, 2, 2));
            itemLoot.Add(ItemDropRule.Common(ItemID.HunterPotion, 1, 5, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.NightOwlPotion, 1, 5, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 20, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.ShinePotion, 1, 5, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Torch, 1, 50, 50));
            itemLoot.Add(ItemDropRule.Common(ItemID.MiningPotion, 1, 5, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Dynamite, 1, 5, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Bomb, 1, 15, 15));
            itemLoot.Add(ItemDropRule.Common(ItemID.SpelunkerPotion, 1, 5, 5));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ShatteredGemBlade>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.DumLightbulb>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.DualWieldCrossbows>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Accessories.EmptyLocket>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Food.SalmonAvoSushi>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Food.TunaAndAvacado>(), 1, 1, 1));


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
            Lighting.AddLight(Item.Center, Color.Teal.ToVector3() * 0.4f);

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.RainbowMk2, velocity);
                dust.scale = 0.9f;
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

            line = new TooltipLine(Mod, "SpaceStarfish", "'Wet, cold and has a distinct and otherworldly touch to it.'")
            {
                OverrideColor = new Color(107, 234, 186)

            };
            tooltips.Add(line);

        }
    }

}










         //   IItemDropRule[] oreTypes = new IItemDropRule[] {
          //      ItemDropRule.Common(ItemID.CopperOre, 1, 15, 20),
             //   ItemDropRule.Common(ItemID.Bomb, 1, 8, 10),
             //   ItemDropRule.Common(ItemID.IronOre, 1, 15, 20),
             //   ItemDropRule.Common(ItemID.TinOre, 1, 15, 20)
             //   ItemDropRule.Common(ItemID.LeadOre, 1, 15, 20),
             //   ItemDropRule.Common(ItemID.GoldOre, 1, 15, 20),
             //   ItemDropRule.Common(ItemID.PlatinumOre, 1, 15, 20),
            //    ItemDropRule.Common(ItemID.Torch, 1, 20, 26),
             //   ItemDropRule.Common(ItemID.MiningPotion, 1, 2, 3),
              //  ItemDropRule.Common(ItemID.Dynamite, 1, 8, 10),
               // ItemDropRule.Common(ItemID.SpelunkerPotion, 1, 2, 3),

              //  ItemDropRule.Common(ModContent.ItemType<Items.GizmoScrap>(), 1, 3, 4),
               // ItemDropRule.Common(ModContent.ItemType<Items.ScavengerSteel>(), 1, 3, 4),
