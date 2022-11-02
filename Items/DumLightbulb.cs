using Microsoft.Xna.Framework;
using RealmOne.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;


namespace RealmOne.Items
{

    public class DumLightbulb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Casts a bright ring around the mouse position that eventually homes on to enemies when let go");
            DisplayName.SetDefault("Dim Lightbulb");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.mana = 9;
            Item.damage = 10;
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 1f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 3f;
            Item.useAnimation = 100;
            Item.useTime = 100;
            Item.UseSound = SoundID.Item132;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.buyPrice(silver: 14);
            Item.timeLeftInWhichTheItemCannotBeTakenByEnemies = 200;
            Item.channel = true;

            Item.shoot = ModContent.ProjectileType<LightBulbRing1>();
        }


        public override void AddRecipes()
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Glass, 10)
            .AddIngredient(ItemID.Torch, 10)

            .AddRecipeGroup("Wood", 16)
            .AddTile(TileID.WorkBenches)
            .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;

        }

    }

}

