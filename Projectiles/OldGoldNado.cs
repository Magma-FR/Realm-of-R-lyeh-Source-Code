using Microsoft.Xna.Framework;
using RealmOne.Common.Systems;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Projectiles
{

    public class OldGoldNado : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Gold Nado");
            Main.projFrames[Projectile.type] = 8;

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 60;
            
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 300;
            Projectile.light = 1;
            Projectile.penetrate = 2;
            Projectile.extraUpdates = 1;
            Projectile.CloneDefaults(ProjectileID.WeatherPainShot);
            AIType = ProjectileID.WeatherPainShot;
           
        }

   
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (var i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sandnado, 0f, 0f, 0, default(Color), 1.5f);
            }
            SoundEngine.PlaySound(SoundID.DD2_PhantomPhoenixShot);

        }
     
        public override void AI()
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Sandnado, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
        }


    }
}