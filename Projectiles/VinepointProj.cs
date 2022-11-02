using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace RealmOne.Projectiles;

public class VinepointProj : ModProjectile
{
    protected virtual float HoldoutRangeMin => 26f;
    protected virtual float HoldoutRangeMax => 108f;

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vinepoint");
    }

    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.Spear);
    }

    public override bool PreAI()
    {
        Player player = Main.player[Projectile.owner];
        int duration = player.itemAnimationMax;

        player.heldProj = Projectile.whoAmI;

        if (Projectile.timeLeft > duration)
        {
            Projectile.timeLeft = duration;
        }

        Projectile.velocity = Vector2.Normalize(Projectile.velocity);
        float halfDuration = duration * 0.5f;
        float progress;


        if (Projectile.timeLeft < halfDuration)
        {
            progress = Projectile.timeLeft / halfDuration;
        }
        else
        {
            progress = (duration - Projectile.timeLeft) / halfDuration;
        }

        Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);


        if (Projectile.spriteDirection == -1)
        {

            Projectile.rotation += MathHelper.ToRadians(45f);
        }
        else
        {

            Projectile.rotation += MathHelper.ToRadians(135f);
        }

        if (!Main.dedServ)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.JungleSpore, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, Alpha: 128, Scale: 1.2f);
            }

            if (Main.rand.NextBool(4))
            {
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.JungleSpore, Alpha: 128, Scale: 0.3f);
            }
        }

        return false;
    }
}