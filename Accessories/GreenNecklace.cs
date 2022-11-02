using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne;
using RealmOne.Buffs;

namespace RealmOne.Accessories
{
    public class GreenNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Renaissance Cross"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Wrap Evolution around your neck'"
                 + "\n'Worn from the dying soldiers of the past'"
                 +"\nAll weapons and equipment inflict 'Tangled'"
                 +"\nYou gain Night Owl, Thorns, Swiftness and Titan while equipping this"
                 +"\nWhen in the Renaissance Biome, all enemies and bosses instantly get inflicted with the 'Withering Evolution' debuff, which obliterates their health by 30%");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 2;
            Item.accessory = true;
    
            

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
           
           



        }
       
    }
}