using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using rail;

namespace RealmOne.Accessories
{
    public class GasMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gas Mask"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'When things get a bit more dangerous'"
                + "\n'Pass 'n Gas!'"
                + "\nImmunity to danger gas"
                +"\nGas does more damage and so does gas related explosives");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
     
        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.defense += 2;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Suffocation] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.OnFire3] = true;
            player.buffImmune[BuffID.Stoned] = true;


        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FlinxFur, 2);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

        }
    }
}