using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace RealmOne.Items
{
    public class Parchment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Parchment"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Parchment paper is made from cellulose fibers prepared from trees or plants such as cotton or flax.'"
                + "\n'Paper can be made which mimics the thickness and smooth surface of parchment.'"
                +"\n'Animal-free Parchment is used'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;



        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = Item.buyPrice(copper: 98);
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
           

        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("Wood", 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }



    }
}