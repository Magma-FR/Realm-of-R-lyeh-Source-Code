using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

using Terraria.Localization;
using RealmOne.Projectiles;
using Terraria.Audio;
using RealmOne.Common.Systems;

namespace RealmOne.Items
{
    public class ImpactPiercer : ModItem
    {
        private int shotCount;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impact Piercer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A weak plasma diverged bow that shoots pulse arrows that pierce multiple enemies'"
                +"\nMidway through the shooting the bow, the bow will short circuit and shoot 2 arrows"
                +"\nThe first of the 2 circuit arrows is a arrow that has a 100% crit chance"
                +"\nThe last circuit arrow is a slow use arrow that deals 7x the damage"
            +"\n'Xeonically Charged!!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = 5;
            Item.knockBack = 2f;
            Item.value = 30000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item158;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.PulseBolt;
            Item.shootSpeed = 27f;
            Item.noMelee = true;
            Item.crit = 1;
            
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            { // or ProjectileID.WoodenArrowFriendly
                type = ProjectileID.PulseBolt; // or ProjectileID.FireArrow;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            shotCount++;
            if (shotCount == 8)
            {
                shotCount = 0;
                Item.shootSpeed = 80f;
                Item.useTime = 41;
                Item.useAnimation = 41;
                Item.damage = 60;
                Item.crit = 99;
                Item.reuseDelay = 45;
                Item.noMelee = true;
                Item.knockBack = 2f;

                for (int d = 0; d < 40; d++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.Electric, 0f, 0f, 150, default(Color), 1f);
                }

                SoundEngine.PlaySound(rorAudio.ElectricPulse);

            }

            else
            {

                Item.damage = 11;
                Item.DamageType = DamageClass.Ranged;
                Item.width = 32;
                Item.height = 32;
                Item.useTime = 24;
                Item.useAnimation = 24;
                Item.useStyle = 5;
                Item.knockBack = 3f;
                Item.value = 30000;
                Item.rare = 1;
                Item.UseSound = SoundID.Item158;
                Item.autoReuse = true;
                Item.useAmmo = AmmoID.Arrow;
                Item.shoot = ProjectileID.PulseBolt;
                Item.shootSpeed = 27f;
                Item.noMelee = true;
                Item.reuseDelay = 0;
                Item.crit = 1;


                for (int i = 0; i < 50; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Center, DustID.Flare_Blue, speed * 5, Scale: 1.5f); ;
                    d.noGravity = true;
                }
            }
            return true;
        
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            
            .AddIngredient(Mod,"ImpactTech",14)
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