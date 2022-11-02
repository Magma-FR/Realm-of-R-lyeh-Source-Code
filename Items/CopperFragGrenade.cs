using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;
using Terraria.Audio;
using System;
using RealmOne;
using RealmOne.Common.Systems;
using RealmOne.Items;
using Microsoft.Xna.Framework;
using RealmOne.Common.DamageClasses;


namespace RealmOne.Items
{
    public class CopperFragGrenade: ModItem
    {
        public override string Texture => "RealmOne/Items/CopperFragGrenade"; //TODO: remove when sprite is made for this

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Frag Grenade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A commonly used hand thrown explosive, wrapped around in thick copper plating"
                +"\n'Best used combat situations. It's not something you want to juggle with");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
           
            Item.damage = 16;
            Item.DamageType = ModContent.GetInstance<DemolitionClass>();
            Item.width = 10;
            Item.height = 24;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = 1;
            Item.knockBack = 5;
            Item.value = 10000;
            Item.rare = 1;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_GrenadeThrow");
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CopperFragGrenadeProj>();
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.consumable = true;
            Item.maxStack = 999;
            
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.CopperBar, 12);
            recipe.AddIngredient(ItemID.Grenade, 50);

            recipe.AddRecipeGroup("IronBar", 12);

            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();

        }
    }
}