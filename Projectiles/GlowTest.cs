using Microsoft.Xna.Framework;
using RealmOne.Common.Systems;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Projectiles
{

    public class GlowTest : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pristine Beam Blade");
            Main.projFrames[Projectile.type] = 5;

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 160;
            Projectile.height = 46;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 300;
            Projectile.light = 2;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            float maxDetectRadius = 350;
            float projSpeed = 16;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;
            if (++Projectile.frameCounter >= 5f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            Projectile.aiStyle = 0;
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.FlameBurst, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, Scale: 1.5f);   //spawns dust behind it, this is a spectral light blue dust
           
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            SoundEngine.PlaySound(rorAudio.SFX_OldGoldBeam);

        }
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawPosition = Projectile.Center;
            Color color = Color.Cyan;
            _ = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
            return true;
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
    }
}