using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RealmOne.Items
{
    public class GushingFrostMinnow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gushing Frost Minnow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A rare fish of the snow that has been frozen over time, filled with icy water'");
            

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 16;
            Item.useAnimation = 16; 
            Item.useStyle = 5;
            Item.knockBack = 4;
            Item.value = 30000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item13;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WaterStream;
            Item.shootSpeed = 15f;
            
            Item.noMelee = true;
           
            
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 180);
        }



        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IceBlock, 35)
            .AddIngredient(ItemID.WaterBucket, 2)
            .AddIngredient(ItemID.SnowBlock, 20)

            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}