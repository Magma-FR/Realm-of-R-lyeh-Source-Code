using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;


namespace RealmOne.Projectiles
{

    public class VintageBulletProjectile : ModProjectile
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vintage Bullet Projectile");

        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 3;

            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 4;
            Projectile.extraUpdates = 1;
            AIType = 0;
            Projectile.CloneDefaults(ProjectileID.ExplosiveBullet);
        }
        public override void AI()
        {
            Projectile.aiStyle = 0;
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
            Lighting.Brightness(1, 1);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.8f, Projectile.velocity.Y * 0.8f);   //spawns dust behind it, this is a spectral light blue dust

        }
        public override void Kill(int timeleft)
        {
            for (var i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 0, default(Color), 1f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 0, default(Color), 1f);

            }

            Collision.TileCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Tink, Projectile.position);


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)

        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 speed = Utils.NextVector2Square(Main.rand, -1f, 1f);

                Dust d = Dust.NewDustPerfect(target.position, DustID.Smoke, speed * 5, Scale: 2.5f); ;
                d.noGravity = true;

            }
            target.AddBuff(BuffID.OnFire3, 220);
            for (var i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 127, 0f, 0f, 150, default(Color), 1.5f);

            }




        }




    }
}





    
