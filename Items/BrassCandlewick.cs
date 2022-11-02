using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace RealmOne.Items
{

    public class BrassCandlewick : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Hold an antique and powerful candle that shoots out burning wax in a diversed and wide spread");
            DisplayName.SetDefault("Brass Candlewick");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.autoReuse = true;
            Item.useTurn = true;
           
            Item.damage = 13;
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 1f;
            Item.mana = 4;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 27f;
            Item.useAnimation = 26;
            Item.useTime = 26;
            Item.UseSound = SoundID.Item131;
            
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.buyPrice(silver: 20);
           

            Item.shoot = ProjectileID.MolotovFire;
            
        }

     
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 7 + Main.rand.Next(1); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(40);
            position += Vector2.Normalize(velocity) * 20f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Candle, 1)
           .AddIngredient(Mod, "BrassIngot", 6)
            .AddIngredient(ItemID.PinkGel, 5)

            .AddTile(TileID.Anvils)
            .Register();


            CreateRecipe(1)
           .AddIngredient(ItemID.PlatinumCandle, 1)
           .AddIngredient(Mod, "BrassIngot", 6)
           .AddIngredient(ItemID.PinkGel, 5)

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