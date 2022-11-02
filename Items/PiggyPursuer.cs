using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using RealmOne.Common.Systems;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using RealmOne;
using RealmOne.Items;

namespace RealmOne.Items
{
    public class PiggyPursuer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Piggy Pursuer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Swing a delicate but sharp porcelain sword"
             + "\n'And I Huff and I puff and I blow your house down!!'");
			

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}


		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.useTurn = true;
			Item.crit = 5;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_MetalSwing");


        }

        public static void DrawGlowmask(PlayerDrawSet info)
        {
            Player Player = info.drawPlayer;

            if (Player.itemAnimation != 0)
            {
                Texture2D tex = Request<Texture2D>("RealmOne/Assets/Hilt").Value;
                Texture2D tex2 = Request<Texture2D>("RealmOne/Assets/hglow").Value;
                Rectangle frame = new Rectangle(0, 0, 50, 50);
                Color color = Lighting.GetColor((int)Player.Center.X / 16, (int)Player.Center.Y / 16);
                Vector2 origin = new Vector2(Player.direction == 1 ? 0 : frame.Width, frame.Height);

                info.DrawDataCache.Add(new DrawData(tex, info.ItemLocation - Main.screenPosition, frame, color, Player.itemRotation, origin, Player.HeldItem.scale, info.itemEffect, 1));
                info.DrawDataCache.Add(new DrawData(tex2, info.ItemLocation - Main.screenPosition, frame, Color.LimeGreen, Player.itemRotation, origin, Player.HeldItem.scale, info.itemEffect, 1));
            }

        }



        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.DungeonPink, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0.5f;

		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			Collision.AnyCollision(Item.position + Item.velocity, Item.velocity, Item.width, Item.height);
            SoundEngine.PlaySound(rorAudio.SFX_Porce);

            for (int i = 0; i < 10; i++)
            {

                Vector2 speed = Utils.NextVector2Square(Main.rand, -1f, 1f);

                Dust d = Dust.NewDustPerfect(target.position, DustID.DungeonPink, speed * 5, Scale: 2f); ;
                d.noGravity = true;

            }

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
           
            recipe.AddIngredient(Mod, "PiggyPorcelain", 8);

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