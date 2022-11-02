using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Mono.Cecil;
using Terraria.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RealmOne.Items;
using RealmOne;
using RealmOne.Accessories;
using System;

namespace RealmOne.Accessories
{
    public class StaticStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Static Stone"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Increases the effectiveness of the Electrified buff"
                + "\nFull immune to the Electrified debuff"
                + "\nBuffs E-Weapons");
            

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "StaticStone", "'Portable Electricity!'")
            {
                OverrideColor = new Color(0, 255, 255)

            };
            tooltips.Add(line);

            // Here we give the item name a rainbow effect.
           
        }
        public override void SetDefaults()
        {


            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = 1;
            Item.accessory = true;
            Item.material = true;

        }
            
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Electrified] = true;
            if (Item.type == ModContent.ItemType<ImpactPiercer>()) Item.damage += 40;



        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "ImpactTech", 6);   
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}
//Tooltip.SetDefault("How are you feeling today?"
//  + $"\n[c/FF0000:Colors ][c/00FF00:are ][c/0000FF:fun ]and so are items: [i:{Item.type}][i:{ModContent.ItemType<EmptyLocket>()}"
//    + $"][i/s123:{ItemID.Ectoplasm}]");----


