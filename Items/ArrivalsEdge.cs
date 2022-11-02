using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using RealmOne.Common.Systems;
using RealmOne.Projectiles;

namespace RealmOne.Items
{
    public class ArrivalsEdge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arrival's Edge"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Reconstructed from the fall of a heroic warrior'"
             + "\n'Slash with Speed'"
			 + "\n5 swings of the sword grants the Arrival's Destiny Buff, which buffs the weapons size and speed");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;


        }


        public override void SetDefaults()
		{
            Item.damage = 28;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.useTurn = true;
			Item.crit = 5;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_MetalSwing");
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<ArrivalsEdgeProjectile>();
            Item.autoReuse = true;
        }






        
        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 264, 0f, 0f, 0, default(Color), 2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;

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
            recipe.AddIngredient(ItemID.Glass, 10);
			recipe.AddIngredient(ItemID.Torch, 20);
            recipe.AddIngredient(Mod, "BrassIngot", 6);

            recipe.AddTile(TileID.GlassKiln);
            recipe.Register();
        }

        public override void HoldItem(Player player)
        {

            if (player.direction < 0)
            {
                player.itemRotation = 5f;
                player.itemLocation.Y = player.Center.Y + 10f;
                player.itemLocation.X = player.Center.X + 40f;
            }
            else if (player.direction > 0)
            {
                player.itemRotation = -5f;
                player.itemLocation.Y = player.Center.Y + 10f;
                player.itemLocation.X = player.Center.X - 40f;

            }
        }
        public virtual void UseStyle(Item item, Player player)
        {
            if (player.HeldItem.handOnSlot < 0)
            {
                player.itemRotation = 5f;
                player.itemLocation.Y = player.Center.Y + 10f;
                player.itemLocation.X = player.Center.X + 40f;
            }
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

        
            
        

    }
}