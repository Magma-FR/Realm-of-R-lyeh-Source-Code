using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;


namespace RealmOne.Food
{
    public class SalmonAvoSushi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Salmon Avo Sushi Roll"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A tasty blend of the most carefully caught salmon in the ocean and fresh creamy slices of avocado'"
            + "\nGives Minor Improvements to all stats"
            + "\nIncreases Charm Duration by 8+ seconds"
            + "\nHeals 70 life");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AppleJuice);
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.value = 500;
            Item.rare = 2;
            Item.UseSound = SoundID.Item2;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.healLife = 70;
        }





        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "FreshSeaweed", 2);
            recipe.AddIngredient(ItemID.Salmon, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}