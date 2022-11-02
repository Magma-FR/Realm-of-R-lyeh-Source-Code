using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace RealmOne.Items
{
    public class GoopyGrass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goopy Grass"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Carries millions of bacteria and nutrients'"
                +"\n'#Green Thumbs'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;



        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = 2;
            Item.maxStack = 999;
           

        }

        
     

    }
}