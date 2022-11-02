using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using RealmOne.Projectiles.HeldProj;
using RealmOne.Projectiles;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace RealmOne.Items
{

    public class PumpShotgun : ModItem
    {
        private int shotCount;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pump-action Shotgun"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A classic, brawny and reliable pump action shotgun'"
                +"\nShoots a spry and powerful round of 12 gauge Buckshot shells"
                +"\n'The bottom rear 'handguard' must be 'slid' back and forward to load the rounds back into the gun to fire again'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 34;
            Item.height = 25;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.rare = 3;
            Item.autoReuse = true;
            Item.shootSpeed = 75f;
            Item.shoot = ModContent.ProjectileType<VintageBulletProjectile>();
            Item.crit = 6;
            Item.noMelee = true; // The projectile will do the damage and not the item
            Item.value = Item.buyPrice(silver: 3);
         //   Item.noUseGraphic = true;
           // Item.channel = true;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_PumpShotgun");
            Item.reuseDelay = 40;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            float numberProjectiles = 3 + Main.rand.Next(2); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(5);
            position += Vector2.Normalize(velocity) * 28f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<VintageBulletProjectile>(), damage, knockback, player.whoAmI);
            }
            
            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.AddRecipeGroup("IronBar", 12);

            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.Chain, 3);
            recipe.AddIngredient(ItemID.MusketBall, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "PumpShotgun", "'Can't Double Pump with this!'")
            {
                OverrideColor = new Color(0, 255, 255)

            };
            tooltips.Add(line);

            // Here we give the item name a rainbow effect.
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.Mod == "Terraria" && line2.Name == "PumpShotgun")
                {
                    line2.OverrideColor = Main.DiscoColor;
                }
            }
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-10, -5);
            return offset;
        }

    }
}