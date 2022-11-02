using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using RealmOne.Common.Systems;

namespace RealmOne.Items
{
    public class HeatedGlassXiphoss : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heated Glass Xiphos"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Smelted and structured with sand at extreme heat'"
             + "\n'A training sword from the gods'"
			 + "\n'The xiphos upgrades in power the more you hit hit enemies'"
			 + "\n5 hits of enemies makes the sword increase in the sword's speed"
			 + "\n10 hits of enemies makes the sword increase its damage by 15%"
			 + "\n15 hits of enemies makes the sword reach it's final stage and inflicts Sharp Heat debuff");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new Terraria.DataStructures.DrawAnimationVertical(9, 9));


        }


        public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.useTurn = true;
			Item.holdStyle = ItemHoldStyleID.HoldUp;
			Item.crit = 5;
            Item.scale = 1.5f;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_MetalSwing");


        }





        
        
        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 0, default, 1f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 2f;

		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire3, 180);
			Collision.AnyCollision(Item.position + Item.velocity, Item.velocity, Item.width, Item.height);
            SoundEngine.PlaySound(rorAudio.SFX_MetalClash);


        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddIngredient(ItemID.Torch, 20);
            recipe.AddIngredient(Mod, "BrassIngot", 6);

            recipe.AddTile(TileID.GlassKiln);
            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

        
            
        

    }
}