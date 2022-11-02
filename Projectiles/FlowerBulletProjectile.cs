using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;


namespace RealmOne.Projectiles
{

    public class FlowerBulletProjectile : ModProjectile
    {
       

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flower Bullet");

        }

        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 10;
            
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            AIType = 0;
         
        }
        public override void AI()
        {
            Projectile.aiStyle = 0;
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
            Lighting.Brightness(1, 1);
        }
        public override void Kill(int timeleft)
        {
            for (var i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleSpore, 0f, 0f, 0, default(Color), 1f);
            }

            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Grass, Projectile.position);

           
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)

        {
            target.AddBuff(BuffID.Poisoned, 180);
        }




    }
        
           

            
        }





    
