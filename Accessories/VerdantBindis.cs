using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Mono.Cecil;
using Terraria.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RealmOne.Accessories
{
    public class VerdantBindis : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Verdant Bindis"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("3+ Base Damage on all weapons"
                 + "\nYou are poisoned when equipping this, I mean you're carrying around Poisonous Bindis? :skull:");

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

            player.GetDamage(DamageClass.Generic).Base += 3f;
            player.AddBuff(BuffID.Poisoned, 60);
            
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "VerdantBindis", "'Australians would even think this is the devil itself!'")
            {
                OverrideColor = new Color(0, 204, 102)

            };
            tooltips.Add(line);

            
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Stinger, 4);
            recipe.AddIngredient(Mod,"GoopyGrass", 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }
    }
}