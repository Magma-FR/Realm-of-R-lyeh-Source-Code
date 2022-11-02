using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using RealmOne.Projectiles;


namespace RealmOne.Pets
{
	public class DirtPETBufff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Durt Boi");
			Description.SetDefault("Thanks Trapper!");

			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{ // This method gets called every frame your buff is active on your player.
			player.buffTime[buffIndex] = 180000;

			int projType = ModContent.ProjectileType<minecraftProjectile>();

			// If the player is local, and there hasn't been a pet projectile spawned yet - spawn it.
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
			{
				var entitySource = player.GetSource_Buff(buffIndex);

				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}