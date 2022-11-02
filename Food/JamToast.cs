using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Audio;
using RealmOne.Common.Systems;
using RealmOne.Buffs;

namespace RealmOne.Food
{
    public class JamToast : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strawberry Jam Toast"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'What I used to wake up to in the morning as a kid'");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;



        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.value = 500;
            Item.rare = 2;
            Item.consumable = true;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_Toast");

        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "JamToast", "'Excellent with home style butter!'")
            {
                OverrideColor = new Color(211, 197, 73)

            };
            tooltips.Add(line);

            // Here we give the item name a rainbow effect.
            foreach (TooltipLine line2 in tooltips)
                if (line2.Mod == "Terraria" && line2.Name == "IronAxe")
                    line2.OverrideColor = Main.DiscoColor;
        }
        public override void AddRecipes()
        {
            CreateRecipe(5)
            .AddIngredient(Mod, "BreadLoaf", 1)
            .AddTile(TileID.Furnaces)
            .Register();


        }

    }
}