using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;


namespace RealmOne.Projectiles
{

    public class CrimBulletProjectile : ModProjectile
    {
       

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crim Bullet");

        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
            Projectile.tileCollide = true; //It will hit the floor and die
            Projectile.timeLeft = 400;
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
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Crimstone, 0f, 0f, 0, default(Color), 1f);
            }

            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item171, Projectile.position);

           
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[Projectile.owner];
            int healingAmount = damage / 11; //decrease the value 30 to increase heal, increase value to decrease. Or you can just replace damage/x with a set value to heal, instead of making it based on damage.
            p.statLife += healingAmount;
            p.HealEffect(healingAmount, true);
        }




    }
        
           

            
        }





    
