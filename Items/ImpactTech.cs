using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace RealmOne.Items
{
    public class ImpactTech : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impact Tech"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'The pieces of purged symbiones'"
                +"\n'Xenoically Sharp!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(3, 27));



        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = 20000;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 999;
           

        }

        
     

    }
}