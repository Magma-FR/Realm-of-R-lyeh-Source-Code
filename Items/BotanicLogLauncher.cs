using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using RealmOne.Projectiles.HeldProj;
using RealmOne.Projectiles;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace RealmOne.Items
{

    public class BotanicLogLauncher : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Botanic Log Launcher"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Hold out a heavy and floral cannon that shoots oversized bouncing flower logs!"
                +"\nTheres a family of worms living in it!"
                +"\nMust reload the launcher after each shot");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.rare = 2;
            Item.autoReuse = true;
            Item.shootSpeed = 20f;
            Item.shoot = ModContent.ProjectileType<BotanicLogLauncherH>();
            Item.crit = 6;
            Item.noMelee = true; // The projectile will do the damage and not the item
            Item.value = Item.buyPrice(gold: 2, silver: 3);
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.UseSound = SoundID.DD2_GoblinBomberThrow;
            
           

        }



        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MudBlock, 25);
            recipe.AddIngredient(ItemID.Acorn, 20);

            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddIngredient(ItemID.GrassSeeds, 10);
            recipe.AddIngredient(Mod,"GoopyGrass", 12);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        
        
    }
}