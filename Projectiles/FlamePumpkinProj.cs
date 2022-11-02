using Microsoft.Xna.Framework;
using RealmOne.Common.Systems;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using RealmOne;

namespace RealmOne.Projectiles
{

    public class FlamePumpkinProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom Pumpkin");

            Main.projFrames[Projectile.type] = 3;

        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 51;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 220;
            Projectile.penetrate = 2;
            Projectile.light = 1f;
            AIType = ProjectileID.LostSoulFriendly;
            
        }

        public override void AI()
        {

            if (++Projectile.frameCounter >= 25f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            float maxDetectRadius = 300;
            float projSpeed = 14;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;
            

            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.aiStyle = 0;
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.FlameBurst, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, Scale: 1.5f);   //spawns dust behind it, this is a spectral light blue dust

        }


        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;


            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;


            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];

                if (target.CanBeChasedBy())
                {

                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);


                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath55);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.6f, Projectile.velocity.Y * 0.6f, Scale: 2f) ;   //spawns dust behind it, this is a spectral light blue dust

        }
    }
}