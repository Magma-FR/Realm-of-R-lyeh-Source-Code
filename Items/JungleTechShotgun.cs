using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

using Terraria.Localization;
using Terraria.Audio;

namespace RealmOne.Items
{
    public class JungleTechShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Tech Shotgun"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A bio-infused boomstick with increased shoot speed'"
            +"\n'Snazzy!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 5;
            Item.knockBack = 4;
            Item.value = 30000;
            Item.rare = 2;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.GreenLaser;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 40f;
            Item.noMelee = true;
            Item.crit = 2;
            Item.UseSound = SoundID.Item36;
        }
        public override void OnHitNPC(Player player , NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 180);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(2); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(30);
            position += Vector2.Normalize(velocity) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.JungleSpores, 6)
            .AddRecipeGroup ("IronBar", 12)
            .AddRecipeGroup("Wood", 10)
            .AddIngredient(Mod,"GizmoScrap",2)
            .AddTile(TileID.Anvils)
            .Register();

        }




        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

    }
}