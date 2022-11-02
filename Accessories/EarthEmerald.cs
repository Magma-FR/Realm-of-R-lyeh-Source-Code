using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;
namespace RealmOne.Accessories
{
    public class EarthEmerald : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Emerald"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'If the Earth was shrunk into a gem'"
              + "\n25% increased tool and weapon speed"
              + "\nSpelunker, Night Owl, Shine buffs"
              + "\nThese stats are better in the day");

                                                
              

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

       // public override void UpdateAccessory(Player player, bool hideVisual)
      //  {

          //  player.AddBuff(BuffID.Spelunker, 90000);


         //   if (Main.dayTime == true)
         //   {
          //      player.toolTime += 15;
        //        player.itemTime += 15;
         //   }
         //   else
       //     {
         //       player.toolTime += 4;
          //      player.itemTime += 4;
         //   }




     //   }
    //  public override void AddRecipes()
     //   {
       //     Recipe recipe = CreateRecipe();
          //  recipe.AddIngredient(ItemID.Bone, 25);
          //  recipe.AddIngredient(ItemID.CrimtaneBar, 10);
          //  recipe.AddIngredient(ItemID.Chain, 2);
          //  recipe.AddTile(TileID.Anvils);
         //   recipe.Register();



         //   Recipe balls = CreateRecipe();
         //   balls.AddIngredient(ItemID.Bone, 25);
        //    balls.AddIngredient(ItemID.DemoniteBar, 10);
         //   balls.AddIngredient(ItemID.Chain, 2);
          //  balls.AddTile(TileID.Anvils);
         //   balls.Register();
     //   }

       
        
        

        
    }
}