using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative; 

namespace RealmOne.Accessories
{
    public class MiningPowder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mining-Grade Powder"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A much more quality explosive powder than the regular'"
                 + "\n'Put this stuff in your bombs and watch the magic happen'"
                 +"\nIncreases bomb explosion radius and damage");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.rare = 1;
            Item.buyPrice(gold: 1, silver: 80);
            Item.accessory = true;
    
            

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

         

          
          player.GetAttackSpeed(DamageClass.Generic) += 0.11f;
           



        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 12);
            recipe.AddIngredient(ItemID.WhiteString, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}