using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace RealmOne.Items
{
    public class GizmoScrap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gizmo Scrap"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A mixture of ores, metal and handy parts in one clump"
                +"\n'Dropped from the sneakiest of goblins'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 35;



        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = Item.buyPrice(silver: 5);
            Item.rare = 2;
            Item.maxStack = 999;
           

        }

        
     

    }
}