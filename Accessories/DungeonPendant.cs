using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;


namespace RealmOne.Accessories
{
    public class DungeonPendant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dungeon Pendant"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A tattered, but still powerful, dungeon charm'"
                + "\nImmunity to spikes"
                + "\nDungeon enemies do 50% less damage to you"
              + "\n10% increased damage and 10+ defense while in the dungeon");
              

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 3;
            Item.accessory = true;
            
            Item.material = true;
         

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneDungeon)
            {
                player.statDefense += 10;
               
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();



            Recipe balls = CreateRecipe();
            balls.AddIngredient(ItemID.Bone, 25);
            balls.AddIngredient(ItemID.DemoniteBar, 10);
            balls.AddIngredient(ItemID.Chain, 2);
            balls.AddTile(TileID.Anvils);
            balls.Register();
        }

       
        
        

        
    }
}