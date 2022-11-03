using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using RealmOne.Common.Systems;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class ScoutsMyBabyGirl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scout's My Baby Girl"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Let me explain 5 reasons why @scoutfrost is my baby girl");
			

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}


		public override void SetDefaults()
		{
			Item.damage = 92838;
			Item.DamageType = DamageClass.Melee;
			Item.width = 620;
			Item.height = 840;
			Item.useTime = 5;
			Item.useAnimation = 90;
			Item.useStyle = 1;
			Item.knockBack = 12;
			Item.value = 90000;
			Item.rare = ItemRarityID.Expert;
			Item.useTurn = true;
			Item.crit = 70;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_FlyingKnife");
            Item.autoReuse = true;
            
            

        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "", "");

            line = new TooltipLine(Mod, "ScoutsMyBabyGirl", "'1. He's never off Discord, so I can chat to him all the time ;)'")
            {
                OverrideColor = new Color(61, 202, 187)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "ScoutsMyBabyGirl", "'2. He's a good spriter and he helps me (he's bad at spriting, I hope you give up on life)'")
            {
                OverrideColor = new Color(61, 202, 91)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "ScoutsMyBabyGirl","'3. He works part time for my mod. (He will never get paid, nor laid)'")
            {
                OverrideColor = new Color(227, 70, 255)

            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "ScoutsMyBabyGirl", "'4. He pings @everyone'")
            {
                OverrideColor = new Color(243, 220, 19)

            };
            tooltips.Add(line);


            line = new TooltipLine(Mod, "ScoutsMyBabyGirl", "'5. He ruffles under the covers'")
            {
                OverrideColor = new Color(243, 19, 19)

            };
            tooltips.Add(line);


            
            
        }

        public override bool OnPickup(Player player)      
        {

            //IL_003f: Unknown result type (might be due to invalid IL or missing references)
            //IL_0052: Unknown result type (might be due to invalid IL or missing references)
            bool pickupText = false;
            for (int i = 0; i < 50; i++)
            {
                if (player.inventory[i].type == 0 && !pickupText)
                {
                    CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y - 20, player.width, player.height), new Color(255, 198, 125, 105), "Enjoy!", false, false);
                    pickupText = true;
                }
            }
            return true;
        }





        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.DungeonPink, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 1f;

		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			Collision.AnyCollision(Item.position + Item.velocity, Item.velocity, Item.width, Item.height);
            SoundEngine.PlaySound(rorAudio.SFX_Porce);

            for (int i = 0; i < 10; i++)
            {

                Vector2 speed = Utils.NextVector2Square(Main.rand, -1f, 1f);

                Dust d = Dust.NewDustPerfect(target.position, DustID.RainbowRod, speed * 5, Scale: 3f); ;
                d.noGravity = true;

            }

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
           
            recipe.AddIngredient(Mod, "PlanetaryShard", 6);

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