using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class DrownedDeathpearl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Drowned Deathpearl"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Deep sea explorers seriously swam 100m underwater just to get obliterated by a pearl'");
                
              

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;



        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = Item.buyPrice(gold: 75);
            Item.rare = ItemRarityID.Cyan;
            Item.maxStack = 999;
           

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "DrownedDeathpearl", "'Even a sacrificial ceremony can commence with the use of this pearl'")
            {
                OverrideColor = new Color(0, 161, 189)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "DrownedDeathpearl", "''Who knows the end? What has risen may sink, and what has sunk may rise.''")
            {
                OverrideColor = new Color(95, 6, 195)

            };
            tooltips.Add(line);

            // Here we give the item name a rainbow effect.
            foreach (TooltipLine line2 in tooltips)
            {
               
            }
        }



    }
}