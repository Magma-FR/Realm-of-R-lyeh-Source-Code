using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne;
using Terraria.GameContent.Creative;

namespace RealmOne.Accessories
{
    public class TheOutcastsOverseer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Outcast's Overseer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A physical form of the dirt titan's purpose'"
                +"\nEvery time you land a crit, your critical chance increases by +2%"
                +"\nMaximum crit stack is +10% (5 times)");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green; 
            Item.accessory = true;
            Item.material = true; 

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

          

        }
        
    }
}