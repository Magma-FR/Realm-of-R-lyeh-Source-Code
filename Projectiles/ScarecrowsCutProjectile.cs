using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;


namespace RealmOne.Projectiles
{

    public class ScarecrowsCutProjectile : ModProjectile
    {
       

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("cut");
            
            
          Main.projFrames[Projectile.type] = 9;
        }

        public override void SetDefaults()
        {
            Projectile.width = 300;
            Projectile.height = 200;
            
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 27;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
         
        }
        public override void AI()
        {
            Projectile.aiStyle = 0;
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
            Lighting.Brightness(1, 1);

            if (++Projectile.frameCounter >= 3f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            Player player = Main.player[Projectile.owner];
            Projectile.Center = player.Center;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[Projectile.owner];
            int healingAmount = damage / 8; //decrease the value 30 to increase heal, increase value to decrease. Or you can just replace damage/x with a set value to heal, instead of making it based on damage.
            p.statLife += healingAmount;
            p.HealEffect(healingAmount, true);
        }




    }
        
           

            
        }





    
