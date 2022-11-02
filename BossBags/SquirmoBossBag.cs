using System;
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
using RealmOne.Items;
using Terraria.GameContent.Creative;
using RealmOne.Enemies;

namespace RealmOne.BossBags
{
    public class SquirmoBossBag : ModItem
    {
        public override int BossBagNPC => ModContent.NPCType<MegaSquirmHead>();

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag (Squirmo)");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}"
                + "\n'It's a struggle to get the goodies out of this muddy bag!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

            ItemID.Sets.BossBag[Type] = true; // This set is one that every boss bag should have, it, for example, lets our boss bag drop dev armor..
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true; // ..But this set ensures that dev armor will only be dropped on special world seeds, since that's the behavior of pre-hardmode boss bags.
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = 11;
            Item.consumable = true;
            Item.maxStack = 99;
            Item.expert = true;

        }
        public override bool CanRightClick()
        {
            return true;
        }

       
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {

            itemLoot.Add(ItemDropRule.Common(ItemID.MudBlock, 1, 10, 20));
            itemLoot.Add(ItemDropRule.Common(ItemID.Worm, 1, 3, 6));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GlobGun>(), 3, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SquirmStaff>(), 3, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SquirYo>(), 3, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<LoreScroll1>(), 6, 1, 1));


        }

        public override Color? GetAlpha(Color lightColor)
        {
            // Makes sure the dropped bag is always visible
            return Color.Lerp(lightColor, Color.PeachPuff, 0.4f);
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
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(181, 128, 177, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(218, 122, 147, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.Salmon.ToVector3() * 0.4f);

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.Worm, velocity);
                dust.scale = 0.6f;
                dust.fadeIn = 1.1f;
                dust.noGravity = true;
                dust.noLight = true;
                dust.alpha = 0;
            }
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
