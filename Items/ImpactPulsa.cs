using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Common.Systems;
using Terraria.Localization;
using Terraria.Audio;

namespace RealmOne.Items
{
    public class ImpactPulsa : ModItem
    {
        private int shotCount;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impact Pulsa"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A weak, plasma diverged rifle'"
                +"\nMidway through firing the gun, the gun will short circuit and burst a burst of pulse bullets that bounces and targets enemies"
            +"\n'Xeonically Charged!!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 5;
            Item.knockBack = 3f;
            Item.value = 30000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item158;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.None;
            Item.shoot = ProjectileID.NanoBullet;
            Item.shootSpeed = 27f;
            Item.noMelee = true;
            Item.crit = 2;
            
        }
        
        

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(Mod,"ImpactTech",12)
            .AddTile(TileID.Anvils)
            .Register();

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
                shotCount++;
                if (shotCount == 4)
                {
                    shotCount = 0;
                    Item.shootSpeed = 60f;
                Item.useTime = 4;
                Item.useAnimation = 4;
                Item.damage = 14;
                Item.crit = 2;
                Item.reuseDelay = 0;
                    
                    for (int d = 0; d < 40; d++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, DustID.Electric, 0f, 0f, 150, default(Color), 1.5f);
                    }
                SoundEngine.PlaySound(rorAudio.ElectricPulse);
              
            }
            else if (shotCount == 3)
             {
                Item.useTime = 4;
                Item.useAnimation = 4;
                Item.reuseDelay = 0;
                for (int d = 0; d < 40; d++)
                {
                    Dust.NewDust(player.position, player.width, player.height, 206, 0f, 0f, 500, default(Color), 1f);
                    
                }

            }
                else
                {
                Item.damage = 14;
                Item.DamageType = DamageClass.Ranged;
                Item.width = 32;
                Item.height = 32;
                Item.useTime = 12;
                Item.useAnimation = 12;
                Item.useStyle = 5;
                Item.value = 30000;
                Item.rare = 1;
                Item.knockBack = 4;
                Item.UseSound = SoundID.Item158;
                Item.autoReuse = true;
                Item.useAmmo = AmmoID.None;
                Item.shoot = ProjectileID.NanoBullet;
                Item.shootSpeed = 27f;
                Item.noMelee = true;
                Item.crit = 2;
                Item.reuseDelay = 39;
                for (int i = 0; i < 50; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Center, DustID.Flare_Blue, speed * 5, Scale: 2.5f);;
                    d.noGravity = true;
                }
            }
                return true;
            }



        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

    }
}