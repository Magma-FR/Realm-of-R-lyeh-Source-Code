using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;
using RealmOne;
using RealmOne.Common.Systems;
using RealmOne.Common;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class ScavengerSawblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scavenger Sawblade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Throws a unstable and explosive sawblade"
                +"\nRight click to detonate the sawblade into unstable sparks of electricity"
                +"\n'Recommended to hold the sawblade in the middle not the blades :OMEGALUL:'"
                +"\n'I'm not even sure how this is safe'");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.knockBack = 3f;
            Item.value = 10000;
            Item.rare = 3;
            Item.UseSound = SoundID.Item23;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.holdStyle = ItemHoldStyleID.HoldGuitar;
            Item.crit = 4;
            Item.axe = 30;
            Item.scale = 0.9f;
            
            Item.shoot = ModContent.ProjectileType<ScavengerProjectile>();
            Item.shootSpeed = 8f;
            Item.noMelee = true;
            Item.channel = true;
            
            
        }

      
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "ScavengerSteel", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
       
    }
}