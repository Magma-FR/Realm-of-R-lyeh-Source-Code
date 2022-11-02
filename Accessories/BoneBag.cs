using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.LootSimulation;

namespace RealmOne.Accessories
{
    public class BoneBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Bag"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Used from the Clothier a long time when he was still trapped in the dungeon'"
                + "\n'Ya bonehead!'"
                + "\nSkeletons and dungeon enemies drop more loot and bones"
              + "\nShows the locaion of chests and treasure in the dungeon");
              

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
                player.AddBuff(BuffID.Spelunker, 90000);




        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();



            Recipe balls = CreateRecipe();
            balls.AddIngredient(ItemID.Bone, 25);
            balls.AddIngredient(ItemID.DemoniteBar, 10);
            balls.AddIngredient(ItemID.Silk,3);
            balls.AddTile(TileID.Anvils);
            balls.Register();
        }

       
        
        

        
    }
}