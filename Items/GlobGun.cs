using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

using Terraria.Localization;
using Terraria.Audio;
using RealmOne.Projectiles;
using System;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class GlobGun: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glob Gun"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A bit too squelchy for my liking'"
            + "\nShoots a forced and sludgy explosive mud glob"
            +"\nStick the glob on a tile and let it charge up its power, dealing 2x the aoe and penetrate up to 3 enemies"
             + $"\nUses Mud Blocks [i:{ItemID.MudBlock}]");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 54;
            Item.useAnimation = 54;
            Item.useStyle = 5;
            Item.knockBack = 4f;
            Item.value = 30000;
            Item.rare = 2;
            Item.UseSound = SoundID.DD2_ExplosiveTrapExplode;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.noMelee = true;
            Item.shootSpeed = 11f;
            Item.shoot = ProjectileID.Bullet;



        }
        public override bool OnPickup(Player player)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath11);
            return true;
        }

        
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet)
            { // or ProjectileID.WoodenArrowFriendly
                type = ModContent.ProjectileType<GlobGunProjectile>(); // or ProjectileID.FireArrow;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MudBlock, 16)
           .AddIngredient(Mod, "GoopyGrass", 7)
            .AddIngredient(ItemID.IllegalGunParts, 1)

            .AddIngredient(ItemID.Worm, 3)
            .AddTile(TileID.Anvils)
            .Register();

        }

        


        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6 , 0);
            return offset;
        }

    }
}