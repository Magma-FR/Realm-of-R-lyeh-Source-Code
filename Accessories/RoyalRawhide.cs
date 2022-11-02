using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;

namespace RealmOne.Accessories
{
    public class RoyalRawhide : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Rawhide"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("5% increased acceleration and movement speed"
            + "\n4 defense"
            + "\nWhen hit by an enemy you have a chance to dash in a direction"
            + "\nThis dash has a 10 cooldown");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 32;
            Item.height = 32;
            Item.value = 10000;
            Item.rare = -12;
            Item.accessory = true;
            Item.material = true;
            Item.masterOnly = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.15f;
            player.accRunSpeed += 0.15f;
            player.statDefense += 4;


        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.RoyalGel, 1);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}