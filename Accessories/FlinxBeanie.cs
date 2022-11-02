using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RealmOne.Accessories
{
    public class FlinxBeanie : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flinx Beanie"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Immune to Chilled amd Frozen"
                +"\n'My goly gosh its so soft!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
     
        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 1;
            Item.accessory = true;
            Item.material = true;
            Item.defense += 1;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;


        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FlinxFur, 2);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

        }
    }
}