using RealmOne.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Items
{
    public class RichMahoganyPoker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rich Mahogany Poker");
            Tooltip.SetDefault("'Harnessed from the moist tree tops of the Jungle'");
                
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.knockBack = 5f;
            Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.width = 34;
            Item.height = 34;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item

            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 10);

            Item.shoot = ModContent.ProjectileType<RichMahoganyPokerProjectile>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.RichMahogany, 15)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}