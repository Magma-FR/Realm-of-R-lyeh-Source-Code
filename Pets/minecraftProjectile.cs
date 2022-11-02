using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Pets
{
	public class minecraftProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt boi");

		
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.CompanionCube); 

			AIType = ProjectileID.CompanionCube; 
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];

			player.companionCube = false; // Relic from aiType

			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

			// Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<DirtPETBufff>()))
			{
				Projectile.timeLeft = 2;
			}

			if (++Projectile.frameCounter >= 4f)//the amount of ticks the game spends on each frame
			{
				Projectile.frameCounter = 0;

				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}



		}
	}
}
