using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using IL.Terraria.GameContent;

namespace RealmOne.Projectiles
{
    public class ScavengerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rat Razor");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 24;

            Projectile.aiStyle = 14;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            
            Projectile.tileCollide = true;
            Projectile.timeLeft = 580;
            Projectile.penetrate = -2;
            AIType = ProjectileID.SpikyBall;
            
        }
       
        public override void Kill(int timeleft)
        { 

            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item94, Projectile.position);
            for (var i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 0, default(Color), 1.5f);
            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        
        {
            target.AddBuff(BuffID.Electrified, 180);
            SoundEngine.PlaySound(SoundID.Item94, Projectile.position);
            for (var i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 0, default(Color), 2f);
            }
        }

      
        

    }
    
}