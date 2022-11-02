using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

using Terraria.Localization;
using Terraria.Audio;
using RealmOne.Projectiles;
using System;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class EbonfrostBlunderbuss: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonfrost Blunderbuss"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Chilled and Corrupted'"
            + "\nShoots a icy corruption bullet");
           

            

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 55;
            Item.useAnimation = 55;
            Item.useStyle = 5;
            Item.knockBack = 1f;
            Item.value = 30000;
            Item.rare = 3;
            Item.UseSound = SoundID.DD2_ExplosiveTrapExplode;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.noMelee = true;
            Item.shootSpeed = 58f;

            Item.shoot = ModContent.ProjectileType<IceBulletProjectile>();


        }
        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(2); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(5);
            position += Vector2.Normalize(velocity) * 28f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<IceBulletProjectile>(), damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.DemoniteBar, 16)
           .AddIngredient(Mod, "BrassIngot", 7)
            .AddIngredient(ItemID.IllegalGunParts, 1)
            .AddIngredient(ItemID.Ebonwood, 10)

            .AddTile(TileID.Anvils)
            .Register();

        }

        


        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-12 , 0);
            return offset;
        }

    }
}