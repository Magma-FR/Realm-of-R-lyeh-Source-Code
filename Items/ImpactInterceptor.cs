using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Projectiles;
using RealmOne.Common.Systems;
using Terraria.Audio;

namespace RealmOne.Items
{

    public class ImpactInterceptor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impact Interceptor");
            Tooltip.SetDefault("Calls down randomly positioned pulse lasers that spark into electricity when homed onto an enemy"
                +"\nThe lasers depend on the mouse position when firing"
                +"\n'No WIFI password required'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.mana = 8;
            Item.damage = 6;
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 2f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 48f;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.buyPrice(silver: 11);
            Item.shoot = ModContent.ProjectileType<PulseProj>();
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_Sonar");

            Item.reuseDelay = 32;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.X;
            
            if (ceilingLimit > player.Center.X + 100f)
            {
                ceilingLimit = player.Center.Y + 700f;
            }


            for (int i = 0; i < 5; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.X += 100 * i;
                Vector2 heading = target - position;
                
                    Vector2 speed = Main.rand.NextVector2CircularEdge(3f, 3f);
                    Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Center, DustID.Flare_Blue, speed * 5, Scale: 2.5f); ;
                    d.noGravity = true;

                if (heading.X < 4f)
                {
                    heading.X *= 4f;
                }

                if (heading.Y < 40f)
                {
                    heading.Y = 40f;
                }




                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<PulseProj>(), damage, knockback, player.whoAmI, 0f, ceilingLimit);



            }

            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
            .AddIngredient(Mod, "ImpactTech", 12)
          
            .AddTile(TileID.Anvils)
            .Register();

        }
    }
}