using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;

namespace RealmOne.Food
{
    public class TunaAndAvacado : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tuna and Avocado Sushi Roll"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A simple roll of sushi with beautiful Japanese Red Fin Tuna and creamy slices of avacado'"
            + "\nGives Minor Improvements to all stats"
            + "\nIncreases Charm Duration by 6+ seconds"
            + "\nHeals 60 life");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
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
            Item.healLife = 60;
        }





        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "FreshSeaweed", 2);
            recipe.AddIngredient(ItemID.Tuna, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}