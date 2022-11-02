using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items
{
    public class BrassNuggets : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brass Nuggets"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A durable and inexpensive chunk of common brass");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
            

        }
        // See? look, this doesnt give me any errors! Great for organised your code lines!
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

        public override void AddRecipes()
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.CopperOre, 2)
            .AddIngredient(ItemID.IronOre, 2)

            .AddTile(TileID.Furnaces)
            .Register();

            CreateRecipe(1)
          .AddIngredient(ItemID.TinOre, 2)
          .AddIngredient(ItemID.LeadOre, 2)

          .AddTile(TileID.Furnaces)
          .Register();
        }

        }
}