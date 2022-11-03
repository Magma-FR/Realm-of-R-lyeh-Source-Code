using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;

namespace RealmOne.Items
{
    public class WoodenTippedSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A blunt, but viable spear'");
            DisplayName.SetDefault("Wooden Tipped Spear");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 2);

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.damage = 10;
            Item.knockBack = 3f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;

            Item.shootSpeed = 3.7f;
            Item.shoot = ModContent.ProjectileType<WoodenTippedSpearProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Mod.Find<ModProjectile>("WoodenTippedSpearProj").Type] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Acorn, 2);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }
    }

}