using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace RealmOne.Projectiles
{

    public class LightBulbRing1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightbulb Ring");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 70;
            Projectile.height = 70;

            Projectile.aiStyle = 9;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 3.5f;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 200;
           
            Projectile.penetrate = 5;
            Projectile.stepSpeed = 1f;
            
            Projectile.scale = 2f;
        }


        public override void AI() // this may add flamelash
        {
            AIType = ProjectileID.Flamelash;
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
            Lighting.Brightness(2, 2);


            Projectile.localAI[0] += 1f;
        }

        

    }
}

        
    
