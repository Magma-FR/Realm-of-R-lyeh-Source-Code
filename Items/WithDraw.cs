using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

using Terraria.Localization;
using RealmOne.Projectiles;
using Terraria.Audio;
using RealmOne.Common.Systems;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class WithDraw : ModItem
    {
        private int shotCount;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WithDraw"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Shoots a very small spread of gold coins at a fast rate"
                + "\nEvery time you pick up this weapon you get 10 Silver Coins but every time you drop it you lose 10 Silver Coins"
                 + $"\nConverts Wooden Arrows to Gold Coins [i:{ItemID.GoldCoin}]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "WithDraw", "'Cheque or Savings?'")
            {
                OverrideColor = new Color(213, 122, 217)

            };
            tooltips.Add(line);

        }
        
        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 5;
            Item.knockBack = 2f;
            Item.value = 30000;
            Item.rare = 1;
            Item.UseSound = SoundID.CoinPickup;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.GoldCoin;
            Item.shootSpeed = 48f;
            Item.noMelee = true;
           
            
            
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            { // or ProjectileID.WoodenArrowFriendly
                type = ProjectileID.GoldCoin; // or ProjectileID.FireArrow;
            }
        }

       
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            float numberProjectiles = 1 + Main.rand.Next(2); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(3);
            position += Vector2.Normalize(velocity) * 28f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return true;
        }

        public override bool OnPickup(Player player)
        {

            bool pickupText = false;
            for (int i = 0; i < 50; i++)
            {
                if (player.inventory[i].type == 0 && !pickupText)
                {
                    CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 20, player.width, player.height), new Color(108, 209, 241, 105), "Please insert card...", false, false);
                    pickupText = true;
                }
            }
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 20, player.width, player.height), new Color(234, 129, 178, 105), "They gonna feel the pain of debt", false, false);

        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            
            .AddIngredient(Mod,"PiggyPorcelain", 10)
            .AddIngredient(ItemID.GoldCoin, 3)

            .AddTile(TileID.Anvils)
            .Register();

        }




        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

    }
}