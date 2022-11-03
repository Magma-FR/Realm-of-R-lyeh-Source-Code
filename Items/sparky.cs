using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures; 

namespace RealmOne.Items
{
    public class sparky : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sparky!"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Thanks to all my supporters :)'"
                + "\n'He's a bit twitchy.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(3, 2));

        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width = 32;
            Item.height = 32;
            Item.value = 20000;
            Item.rare = 9;


       


        }

  
     

    }
}