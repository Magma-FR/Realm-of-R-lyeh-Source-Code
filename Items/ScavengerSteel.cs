using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items
{
    public class ScavengerSteel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scavenger Steel"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'An artificial ingot, constructed from the mysteries under the caverns'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;


        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width = 32;
            Item.height = 32;
            Item.value = 20000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 999;
            

        }

        


    }
}