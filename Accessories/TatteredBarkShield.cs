using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;


namespace RealmOne.Accessories
{
    public class TatteredBarkShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tattered Bark Shield"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Nothing but skin penetrating wooden splinters on this shield'"
                + "\nWhen hit by an enemy, they take damage and get inflicted by 'Splintered' which damages the enemy for 2 damage forever until they die"
                +"\nAll weapons inflict Splintered while equipping the shield");
              

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 1;
            Item.accessory = true;
            
         

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 2;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod,"BarkShield", 1);
            recipe.AddTile(TileID.Sawmill);
            recipe.Register();


        }

       
        
        

        
    }
}