using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using RealmOne.Common.Systems;

namespace RealmOne.Projectiles
{
    public class CrossBowBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("CrossBolt");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 10;

            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -2;  
            Projectile.timeLeft = 320;
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            AIType = ProjectileID.WoodenArrowFriendly;
        }
        public override void Kill(int timeleft)
        {
            for (var i = 0; i < 6; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WoodFurniture, 0f, 0f, 0, default(Color), 1.5f);
            }
            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(rorAudio.SFX_CrossbowImpact);

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        
        {
            SoundEngine.PlaySound(rorAudio.SFX_CrossbowHit);

        }

       
        
    }
    
}