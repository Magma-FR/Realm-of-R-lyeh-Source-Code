using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace RealmOne.Items
{
    public class AquamarineTurquiose : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquamarine Turquiose"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("An oceanside gem that is too fragile to handle"
                + "\n'So shine brriiiggghtt, toniggghhhht, you and I!!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;



        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = 20000;
            Item.rare = ItemRarityID.Cyan;
            Item.maxStack = 999;
           

        }

        
     

    }
}