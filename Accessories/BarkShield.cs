using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;


namespace RealmOne.Accessories
{
    public class BarkShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bark Shield"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Carven from the bark of the trees'"
                + "\n15% increased axe and pickaxe speed when in the forest");
              

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 0;
            Item.accessory = true;
            
         

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 1;

            if (player.ZoneForest)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
               
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();



        }

       
        
        

        
    }
}