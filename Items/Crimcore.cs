using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items
{
    public class Crimcore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimcore"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A bloody, dark and cold stone, dropped from the enemies that have surpassed and crumbled in the flesh ");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
            

        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.rare = 3;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 2);


        }




    }
}