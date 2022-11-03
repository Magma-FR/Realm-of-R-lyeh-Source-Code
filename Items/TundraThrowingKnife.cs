using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using RealmOne.Projectiles;

namespace RealmOne.Items
{
    public class TundraThrowingKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tundra Throwing Knives"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("The Merchant finally got his grubby hands on these ice cold daggers, and now selling them at double the price");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ThrowingKnife);
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 24;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.shoot = ModContent.ProjectileType<TundraThrowingKnifeProjectile>();
            Item.noMelee = true;

        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddIngredient(ItemID.ThrowingKnife, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }
    }
}