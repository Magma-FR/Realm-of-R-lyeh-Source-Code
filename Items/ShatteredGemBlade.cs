using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Creative;
using Terraria.Graphics;

namespace RealmOne.Items
{
    public class ShatteredGemBlade : ModItem
    {
        private float rotation;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shattered Gem Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A snapped, legendary blade, destined with full potential'"
                + "\nSwings a snapped, gem incrusted blade"
                + "\nClick right click to toggle swing or thrust");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 5;
            Item.value = 20000;
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item101;
            Item.autoReuse = true;
            Item.crit = 2;
            Item.useTurn = true;

        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.DamageType = DamageClass.Melee;
                Item.useStyle = 3;
                Item.useTime = 16;
                Item.useAnimation = 16;
                Item.damage = 40;
                Item.scale = 1.3f;
                Item.useTurn = true;
                Item.crit = 4;
                Item.autoReuse = true;
                Item.UseSound = SoundID.Item71;
                Item.knockBack = 8f;

              
            }
            else
            {

                Item.damage = 17;
                Item.DamageType = DamageClass.Melee;
                Item.width = 40;
                Item.height = 40;
                Item.useTime = 20;
                Item.useAnimation = 20;
                Item.useStyle = 1;
                Item.knockBack = 5;
                Item.value = 20000;
                Item.rare = ItemRarityID.Cyan;
                Item.UseSound = SoundID.Item101;
                Item.autoReuse = true;
                Item.crit = 2;
                Item.useTurn = true;



            }
            return base.CanUseItem(player);
        }
        public override bool? UseItem(Player player)
        {
            rotation = MathHelper.ToDegrees(Utils.ToRotation(Main.LocalPlayer.Center - Main.MouseWorld));
            if (rotation < 0f)
            {
                rotation += 360f;
            }
            if (rotation >= 330f || rotation < 30f)
            {
                player.AddBuff(BuffID.Swiftness, 10, true);
            }
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.WitheredArmor, 180);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperBroadsword);
            recipe.AddIngredient(ItemID.Emerald, 1);
            recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddIngredient(ItemID.Topaz, 1);
            recipe.AddIngredient(ItemID.Diamond, 1);
            recipe.AddIngredient(ItemID.Amethyst, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();


            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.TinBroadsword);
            recipe1.AddIngredient(ItemID.Emerald, 1);
            recipe1.AddIngredient(ItemID.Glass, 10);
            recipe1.AddIngredient(ItemID.Sapphire, 1);
            recipe1.AddIngredient(ItemID.Ruby, 1);
            recipe1.AddIngredient(ItemID.Topaz, 1);
            recipe1.AddIngredient(ItemID.Diamond, 1);
            recipe1.AddIngredient(ItemID.Amethyst, 1);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();
        }
      
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.ApprenticeStorm, 0f, 0f, 0, default(Color),2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 1f;

        }


        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
        
    }
}