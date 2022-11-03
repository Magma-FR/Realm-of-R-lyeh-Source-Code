using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace RealmOne.Items
{
    public class MossMarrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moss Marrow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'From all the degradation, it still looks viable'"
                +"\nConverts Wooden Arrows to Bone Arrows ");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 31;
            Item.useAnimation = 31;
            Item.useStyle = 5;
            Item.knockBack = 4;
            Item.rare = 2;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 18f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
           // Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_Scroll");

            Item.value = Item.buyPrice(silver: 3);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            { // or ProjectileID.WoodenArrowFriendly
                type = ProjectileID.BoneArrow; // or ProjectileID.FireArrow;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 20);
            recipe.AddIngredient(ItemID.StoneBlock, 15);

            recipe.AddIngredient(Mod, "GoopyGrass", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

    }
}