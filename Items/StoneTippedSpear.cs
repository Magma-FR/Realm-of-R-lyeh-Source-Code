using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;

namespace RealmOne.Items
{
    public class StoneTippedSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Sharpened and sturdy, ready for thrusting'");
            DisplayName.SetDefault("Stone Tipped Spear");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 3);

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 29;
            Item.useTime = 29;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.damage = 13;
            Item.knockBack = 3f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;

            Item.shootSpeed = 3.7f;
            Item.shoot = ModContent.ProjectileType<StoneTippedSpearProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Mod.Find<ModProjectile>("StoneTippedSpearProj").Type] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 14);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }
    }

}