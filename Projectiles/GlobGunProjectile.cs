using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent.Achievements;
using RealmOne.Common.Systems;

namespace RealmOne.Projectiles
{
    public class GlobGunProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glob Ball");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public override void SetDefaults()
        {

            // while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;

            // 4 second defuse
            Projectile.timeLeft = 100;

            // These 2 help the projectile hitbox be centered on the projectile sprite.
            DrawOffsetX = 5;
            DrawOriginOffsetY = 5;
            Projectile.ownerHitCheck = false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Die immediately if ai[1] isn't 0 (We set this to 1 for the 5 extra explosives we spawn in Kill)
            if (Projectile.ai[1] != 0)
            {
                return true;
            }

            return false;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.CoralTorch, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f);//spawns dust behind it, this is a spectral light blue dust

            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.tileCollide = true;
                // Set to transparant. This projectile technically lives as  transparant for about 3 frames
                Projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
                Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
                Projectile.width = 260;
                Projectile.height = 260;
                Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
                Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
                Projectile.damage = 32;
                Projectile.knockBack = 8f;
                Projectile.penetrate = 3;
                Projectile.ownerHitCheck = false;
            }
            else
            {
                // Smoke and fuse dust spawn.
                if (Main.rand.Next(2) == 0)
                {
                    int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Worm, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;
                    dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Mud, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2 - 6)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;
                }
            }
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] > 5f)
            {
                Projectile.ai[0] = 10f;
                // Roll speed dampening.
                if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
                {
                    Projectile.velocity.X = Projectile.velocity.X * 0.9f;
                    //if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
                    {
                        Projectile.velocity.X = Projectile.velocity.X * 0.7f;
                    }
                    if ((double)Projectile.velocity.X > -0.01 && (double)Projectile.velocity.X < 0.1)
                    {
                        Projectile.velocity.X = 0f;
                        Projectile.netUpdate = true;
                    }
                }
                Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
            }
            // Rotation increased by velocity.X
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            return;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.penetrate = 3;

            // If we are the original projectile, spawn the 5 child projectiles
            if (Projectile.ai[1] == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    // Random upward vector.
                    Vector2 vel = new Vector2(Main.rand.NextFloat(0, 0), Main.rand.NextFloat(0, 0));
                }
            }
            SoundEngine.PlaySound(rorAudio.SquirmoMudBubblePop);
            // Smoke Dust spawn
            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Worm, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            // Fire Dust spawn
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Mud, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Mud, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].velocity *= 3f;
            }
            // Large Smoke Gore spawn
           
            // reset size to normal width and height.
            Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);

            // TODO, tmodloader helper method
            {
                int explosionRadius = 150;
                //if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
                //{
                //  explosionRadius = 15;
                //}
                int minTileX = (int)(Projectile.position.X / 16f - (float)explosionRadius);
                int maxTileX = (int)(Projectile.position.X / 16f + (float)explosionRadius);
                int minTileY = (int)(Projectile.position.Y / 16f - (float)explosionRadius);
                int maxTileY = (int)(Projectile.position.Y / 16f + (float)explosionRadius);
                if (minTileX < 0)
                {
                    minTileX = 0;
                }
                if (maxTileX > Main.maxTilesX)
                {
                    maxTileX = Main.maxTilesX;
                }
                if (minTileY < 0)
                {
                    minTileY = 0;
                }
                if (maxTileY > Main.maxTilesY)
                {
                    maxTileY = Main.maxTilesY;
                }
                bool canKillWalls = false;
                for (int x = minTileX; x <= maxTileX; x++)
                {
                    for (int y = minTileY; y <= maxTileY; y++)
                    {
                        float diffX = Math.Abs((float)x - Projectile.position.X / 16f);
                        float diffY = Math.Abs((float)y - Projectile.position.Y / 16f);
                        double distance = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
                        if (distance < explosionRadius && Main.tile[x, y] != null && Main.tile[x, y].WallType == 0)
                        {
                            canKillWalls = true;
                            break;
                        }
                    }
                }
            
            }
        }
    }
}
        
    
