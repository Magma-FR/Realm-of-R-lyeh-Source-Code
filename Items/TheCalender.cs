using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items
{
    public class TheCalender : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Calender"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A handy booklet of information'"
                + "\nShows a handy interface of the current date and month"
                +"\nShows a small sticky note on the side of the interface that shows side quests"
                +"\nSide Quests are simple quests that reward you for completing it"
                +"\nShows the time, date and shows when a certain NPC is selling items at a sale!"
                + "\n**TEST ITEM!! DOES NOT FULLY WORK**");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {
            Item.material = true;
            Item.width =20;
            Item.height = 20;
            Item.value = 20000;
            Item.rare = ItemRarityID.Quest;
            

        }

       
     

    }
}