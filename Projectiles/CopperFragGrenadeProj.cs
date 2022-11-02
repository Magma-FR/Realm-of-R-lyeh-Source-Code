using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;
using RealmOne;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using RealmOne.Common.Systems;
using RealmOne.Common.DamageClasses;


namespace RealmOne.Projectiles
{
    public class CopperFragGrenadeProj : ModProjectile
    {
       
            public bool Exploded { get => Projectile.ai[0] != 0; set => Projectile.ai[0] = !value ? 0 : 1; }


            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Copper Frag Grenade");

                Main.projFrames[Projectile.type] = 2;


            }

            public override void SetDefaults()
            {
                Projectile.width = 16;
                Projectile.height = 16;
                Projectile.friendly = true;
                Projectile.extraUpdates = 1;
                Projectile.hostile = false;
                Projectile.timeLeft = 260;
                Projectile.penetrate = 2;
            Projectile.DamageType = ModContent.GetInstance<DemolitionClass>();


            Projectile.ownerHitCheck = true;
        }

            public override void AI()
            {
                Projectile.rotation += 0.04f * Projectile.velocity.X;
                Projectile.velocity.Y += 0.1f;

            if (++Projectile.frameCounter >= 25f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            if (Projectile.timeLeft < 4 && !Exploded)
            {
                const int ExplosionSize = 240;

                Projectile.position -= new Vector2(ExplosionSize / 2f) - Projectile.Size / 2f;
                Projectile.width = Projectile.height = ExplosionSize;
                Projectile.hostile = true;
                Projectile.friendly = true;
                Projectile.hide = true;
                SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
                Exploded = true;
            }
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;
                dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.FlameBurst, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2 - 6)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;


             }

        public override bool OnTileCollide(Vector2 oldVelocity)
            {
                if (Projectile.velocity.X != oldVelocity.X)
                    Projectile.velocity.X = -oldVelocity.X;

                if (Projectile.velocity.Y != oldVelocity.Y)
                    Projectile.velocity.Y = -oldVelocity.Y * 0.22f;

                Projectile.velocity.X *= 0.9f;
            return false;
          
            }

            public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
            {
            target.AddBuff(BuffID.OnFire, 140);

            }

            public override bool? CanHitNPC(NPC target) => !target.friendly;
        public override void Kill(int timeLeft)
        {
            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(rorAudio.SFX_GrenadeRoll, Projectile.position);
            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            // Fire Dust spawn
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.FlameBurst, 0f, 0f, 150, default(Color), 1.2f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].velocity *= 3f;
            }
        }
    }
}
   
       

    
 
    