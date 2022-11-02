using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using RealmOne.Common.Systems;

namespace RealmOne.Vanities
{
    // This tells tModLoader to look for a texture called MinionBossMask_Head, which is the texture on the player
    // and then registers this item to be accepted in head equip slots
    [AutoloadEquip(EquipType.Head)]
    public class SkullMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skull Mask");
            Tooltip.SetDefault("'Bro thinks he's bro :skull:'"
                +"\nSold by the Clothier!"
            + "\n'To my skull emoji enthuasists!'");
           
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;

            // Common values for every boss mask
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 10);
            Item.vanity = true;
            Item.maxStack = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "SkullMask", "'HAPPY HALLOWEEN'")
            {
                OverrideColor = new Color(240, 143, 10)

            };
            tooltips.Add(line);



        }
        public override bool OnPickup(Player player)
        {
            bool pickupText = false;
            for (int i = 0; i < 50; i++)
            {
                if (player.inventory[i].type == 0 && !pickupText)
                {
                    CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 20, player.width, player.height), new Color(255, 255, 255, 255), "BROOOO NAWWWW :skull:", false, false);
                    pickupText = true;
                }
            }
            SoundEngine.PlaySound(rorAudio.VINEBOOM);
            return true;
        }
      
    }

}