using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Microsoft.Xna.Framework;
using RealmOne.Items.Placeables;

namespace RealmOne.Items.Placeables
{
    internal class Outcrop : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
            ItemID.Sets.SortingPriorityMaterials[Type] = 58;
            Tooltip.SetDefault("'Only a fool would go forth and touch this'"
                + "\nSummons the Outcrop Outcast with enchanted soil on the effigy"
                +"\n**TEST ITEM!! DOES NOT FULLY WORK**");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 999;
            
            Item.value = Item.buyPrice(copper: 50);

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.createTile = ModContent.TileType<Tiles.OutcropSpawn1>();
        }
    }
}