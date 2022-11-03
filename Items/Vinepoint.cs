using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;

namespace RealmOne.Items
{
    public class Vinepoint : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The tip is till sharp'");
            DisplayName.SetDefault("Vinepoint");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
            ItemID.Sets.Spears[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 85);

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 29;
            Item.useTime = 29;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;

            Item.damage = 18;
            Item.knockBack = 5f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;

            Item.shootSpeed = 3.7f;
            Item.shoot = ModContent.ProjectileType<VinepointProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Mod.Find<ModProjectile>("VinepointProj").Type] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GoopyGrass", 6);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddRecipeGroup("IronBar", 6);

            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }
    }

}