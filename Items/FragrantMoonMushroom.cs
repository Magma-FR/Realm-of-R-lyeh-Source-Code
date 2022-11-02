using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items
{
    public class FragrantMoonMushroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fragrant Moon Mushroom"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Provides an otherworldly smell, nothing like you've smelled before'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;


        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.rare = ItemRarityID.Cyan;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(gold: 6, silver: 20);


        }




    }
}