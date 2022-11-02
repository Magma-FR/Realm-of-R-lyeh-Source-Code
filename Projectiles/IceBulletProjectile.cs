﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;


namespace RealmOne.Projectiles
{

    public class IceBulletProjectile : ModProjectile
    {
       

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonfrost Bullet");

        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 12;
            
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
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
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ice_Purple, 0f, 0f, 0, default(Color), 1f);
            }

            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);

           
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)

        {
            target.AddBuff(BuffID.Frostburn, 180);
        }




    }
        
           

            
 }





    
