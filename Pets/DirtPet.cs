using RealmOne.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RealmOne.Pets;
using System.Collections.Generic;

namespace RealmOne.Pets
{
	public class DirtPet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Block Boi");
			Tooltip.SetDefault("Summons the durt block boi");
			

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.CompanionCube); // Copy the Defaults of the Zephyr Fish Item.

			Item.shoot = ModContent.ProjectileType<minecraftProjectile>(); // "Shoot" your pet projectile.
            Item.buffType = ModContent.BuffType<DirtPETBufff> (); // Apply buff upon usage of the Item.
        }

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 800000);
			}
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "DirtPet", "@trapper")
            {
                OverrideColor = new Color(61, 219, 183)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "DirtPet", "--Supporter Item--")
            {
                OverrideColor = new Color(173, 48, 248)
				
            };
            tooltips.Add(line);

        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
		{
			CreateRecipe()
				
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}