using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;
using System.IO;


namespace RealmOne.Projectiles
{

    public class ArrivalsEdgeProjectile : ModProjectile
    {
       

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arrival's Edge Slice");
            
            
          Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.width = 162;
            Projectile.height = 93;
            
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.aiStyle = -1;
            Projectile.scale = 2f;
            Projectile.timeLeft = 36;            
            Projectile.ownerHitCheck = false;

         
        }
        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
            Lighting.Brightness(1, 1);

            if (++Projectile.frameCounter >= 6f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            float num = 1.57079637f;
            Player player = Main.player[Projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            if (player.direction > 0)
            {
                DrawOffsetX = +0;
                DrawOriginOffsetX = -0;
                DrawOriginOffsetY = -0;
            }
            else if (player.direction < 0) 
            {
                DrawOffsetX = -0;
                DrawOriginOffsetX = +0;
                DrawOriginOffsetY = -0;
            }
            if (Main.myPlayer == Projectile.owner) // Check if the local player is the owner of this projectile, if it is we update the rest.
            {
                if (player.channel && !player.noItems && !player.CCed) // So if the player is still using this weapon, since this weapon channels, we update it.
                {                                                                                          // Otherwise we KILL it (mwuahahaha). So basically destroy this projectile if the item is not being used.
                    float scaleFactor6 = 1f; //
                    if (player.inventory[player.selectedItem].shoot == Projectile.type) // Check if the item that is currently selected in the players' inventory is the one that is
                    {                                                                                                  // shooting this projectile.
                        scaleFactor6 = player.inventory[player.selectedItem].shootSpeed * Projectile.scale; // Set the 'scaleFactor6' value
                    }
                    Vector2 vector13 = Main.MouseWorld - vector; // Get the direction vector between the mouse position and the vector (vector was declared earlier, remember?)
                    vector13.Normalize(); // Normalize this vector since we're not in need of any large values, we just need to get the direction out of this.
                    if (vector13.HasNaNs()) // This check is basically used to check if the X value of the direction is 'Not a Number' (or a negative value in this case).
                    {
                        vector13 = Vector2.UnitX * (float)player.direction; // If it is, we
                    }
                    vector13 *= scaleFactor6;
                    if (vector13.X != Projectile.velocity.X || vector13.Y != Projectile.velocity.Y) // If the vector13 value is actually changing something
                    {                                                                                                        // (so if the mouse or the player have been moved).
                        Projectile.netUpdate = true; // Make sure it gets updated for everyone if you're in multiplayer.
                    }
                    Projectile.velocity = vector13; // At last, set the velocity of this projectile to the 'vector13'. This is later used to set the rotation of the projectile correctly.
                }
                else
                {
                    Projectile.Kill(); // Yeahh, so we destroy the projectile here if the item is not being used.
                }
            }
            num = 0f;
            if (Projectile.spriteDirection == -1) // If the projectile is facing left.
            {
                num = 3.14159274f; // Hardcode the 'num' value.
            }
         
            Projectile.rotation = Projectile.velocity.ToRotation() + num;
            Projectile.spriteDirection = Projectile.direction;
            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
         
        }
        
    




    }
        
           

            
        }





    
