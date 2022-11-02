using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items
{
    public class FreshSeaweed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fresh Seaweed"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Way too salty for my liking'"
                +"\n'Can be dried and wrapped up in sushi!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;


        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 8, copper: 20);


        }




    }
}