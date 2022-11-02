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

namespace RealmOne.Items
{

    public class DualWieldCrossbows : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dual-Wield Crossbows"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Wield Crossbows on the wrists!"
                +"\nThe crossbow shoots out 2 crossbolts, having to let go of the button and reload"
                +"\n'Double Trouble!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 25;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.rare = 1;
            Item.autoReuse = true;
            Item.shootSpeed = 30f;
            Item.shoot = ModContent.ProjectileType<WoodenCrossProj>();
            Item.crit = 5;
            Item.scale = 0.8f;
            Item.noMelee = true; // The projectile will do the damage and not the item
            Item.value = Item.buyPrice(silver: 3);
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_CrossbowLoad");


        }



        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenArrow, 30);
            recipe.AddIngredient(ItemID.Wood, 15);

            recipe.AddIngredient(ItemID.Cobweb, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        
        
    }
}