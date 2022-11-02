using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Rarities;

namespace RealmOne.Items
{
    public class BrassIngot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brass Ingot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Crafts antique and durable stationary and weaponary"
                + "\n'Brass is most widely used in applications that are decorative and mechanical.'"
                + "\n'Due to its unique properties, which include corrosion resistance and rusting.'"
                + "\n'Common uses for brass include applications that require low friction.'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
            

        }


        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.rare = 1;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 15);


        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
            .AddIngredient(Mod, "BrassNuggets", 4)
            .AddTile(TileID.Furnaces)
            .Register();

        }

        }
}