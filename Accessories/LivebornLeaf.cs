using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative; 

namespace RealmOne.Accessories
{
    public class LivebornLeaf : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Liveborn Leaf"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A common, powerful, fragile leaf of the overgrown forest'"
                 + "\n10% increased summon damage");

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

            player.GetDamage(DamageClass.Summon) += 0.10f;
           



        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Acorn, 4);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}