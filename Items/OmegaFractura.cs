using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using ReLogic.Content;
using Terraria.Graphics.Shaders;

namespace RealmOne.Items
{
    public class OmegaFractura : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omega Fractura"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'The last restrucuture of the Fractals'"
                + "\n''No matter how vast the downfall will be, never give up on the missing puzzle''"
                + "\n'The augmented slice in reality is in your hands'"
                 + "\nSwings the amended rise of the Last Fractal"
                 +"\n**TEST ITEM!! DOES NOT FULLY WORK**");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;



        }

        public override void SetDefaults()
        {
            Item.damage = 2121;
            Item.DamageType = DamageClass.Melee;
            Item.width = 120;
            Item.height = 120;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 1;
            Item.knockBack = 19;
            Item.value = 90000;
            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item163;
            Item.autoReuse = true;
            Item.shoot = 857;
            Item.shootSpeed = 23f;
            Item.crit = 30;
            Item.scale = 3.5f;
            


        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.TerraBlade, 1);
            recipe.AddIngredient(Mod, "PlanetaryShard", 8);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

       // public override void MeleeEffects(Player player, Rectangle hitbox)
    //    {

        //    Main.dust[Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.RainbowRod, 0f, 0f, 0, new Color(255, 255, 255), 1f)].shader = GameShaders.Armor.GetSecondaryShader(DustID.GemDiamond, player);
            
            
       // }
    }
}