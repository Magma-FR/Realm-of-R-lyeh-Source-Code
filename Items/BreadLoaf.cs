using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class BreadLoaf : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bread Loaf"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault($"[c/BBA95E:'Freshly baked from the rustic and antique stone baker ovens']");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
           

        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = 20000;
            Item.rare = 1;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 2);
            


        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "BreadLoaf", "'Strawberry Jam is my personal favourite.'")
            {
                OverrideColor = new Color(226, 34, 90)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "BreadLoaf", "'Vegemite is also good. An aussie classic :)'")
            {
                OverrideColor = new Color(222, 150, 0)

            };
            tooltips.Add(line);

          
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
            .AddIngredient(Mod, "Wheat", 16)          
            .AddTile(TileID.Furnaces)
            .Register();

       
        }

    }
}