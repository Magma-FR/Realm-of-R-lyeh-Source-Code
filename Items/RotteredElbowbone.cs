using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.Audio;
using RealmOne;

namespace RealmOne.Items
{
    public class RotteredElbowbone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rottered Elbowbone"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'The bone is so old that bacteria and vines have become poisonous overtime'"
			+ "\nRight Click to release a bouncing cross-bone from the bone"
			+ "\nInflicts Tangled");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}


		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.useTurn = true;

			Item.autoReuse = true;
			Item.value = Item.buyPrice(silver: 2,  copper: 3);

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
				Item.useStyle = ItemUseStyleID.Swing;
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.damage = 10;
				Item.shoot = ProjectileID.BoneGloveProj;
				Item.shootSpeed = 9f;
				Item.knockBack = 0;
				Item.height = 20;
				Item.width = 20;
				Item.autoReuse = true;
				Item.useTurn = true;
				Item.rare = 2;
				
				
			}
			else
			{

                Item.damage = 16;
                Item.DamageType = DamageClass.Melee;
                Item.width = 40;
                Item.height = 40;
                Item.useTime = 23;
                Item.useAnimation = 23;
                Item.useStyle = 1;
                Item.knockBack = 4;
                Item.value = 10000;
                Item.rare = 2;
                Item.UseSound = SoundID.Item1;
                Item.useTurn = true;
				Item.autoReuse = true;
				Item.shoot = 0;
				Item.shootSpeed = 0f;
            }
            return base.CanUseItem(player);
        }
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.JungleGrass, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0.5f;

		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 180);
			SoundEngine.PlaySound(SoundID.DD2_SkeletonHurt);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 15);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(Mod,"GoopyGrass", 12);

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