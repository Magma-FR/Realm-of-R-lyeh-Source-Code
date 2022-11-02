using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Terraria.Audio;

namespace RealmOne.Projectiles
{
    public class vampdagProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Dagger");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 35;

            Projectile.aiStyle = 2;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 330;
            
            Projectile.penetrate = -2;
            AIType = ProjectileID.ThrowingKnife;
        }
        public override void Kill(int timeleft)
        { 

            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item39, Projectile.position);


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        
        {
            SoundEngine.PlaySound(SoundID.NPCDeath6, Projectile.position);
            Player p = Main.player[Projectile.owner];
            int healingAmount = damage / 16; //decrease the value 30 to increase heal, increase value to decrease. Or you can just replace damage/x with a set value to heal, instead of making it based on damage.
            p.statLife += healingAmount;
            p.HealEffect(healingAmount, true);
        }
    }
    
}