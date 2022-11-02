using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Accessories;
using Terraria.Localization;
using System;
using RealmOne;
using RealmOne.Projectiles;
using RealmOne.Items;
using RealmOne.Common.Systems;


namespace RealmOne.Items
{
    public class CrashLandChainGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crash Land Chain Gun"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Shoots rapid fire Meteors!"
            +"\n'Not to be mistaken from the Meteor Staff!'"
            +"\nUses Fallen Stars"

              + $"[i:{ItemID.FallenStar}]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.rare = 4;
            Item.UseSound = SoundID.Item88;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Meteor1;
           
            Item.shootSpeed = 27f;
            Item.noMelee = true;
            Item.crit = 3;
            Item.value = Item.buyPrice(gold: 4, silver: 75);

            Item.useAmmo = AmmoID.FallenStar;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Meteor1)
            { // or ProjectileID.WoodenArrowFriendly
                type = ProjectileID.Meteor2; // or ProjectileID.FireArrow;
            }
        }
        public override void OnHitNPC(Player player , NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(0); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(6);
            position += Vector2.Normalize(velocity) * 21f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, ProjectileID.Meteor2, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PixieDust, 25)
            .AddIngredient(ItemID.Minishark, 1)
            .AddIngredient (ItemID.MeteoriteBar, 25)
            .AddIngredient(Mod,"GizmoScrap",2)
            .AddTile(TileID.MythrilAnvil)
            .Register();

        }




        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(3, -3);
            return offset;
        }

    }
}