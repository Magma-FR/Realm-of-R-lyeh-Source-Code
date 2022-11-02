using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace RealmOne.Potions
{
    public class Cigarette1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cigarette"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'When you light cigarette'" + "\n'Your life burns with it'"
            + "\nWhen holding a cigarette, you gain 25% increased damage and weapon speed but no life regen nor pickup hearts");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 10;
            Item.useTime = 155;
            Item.useAnimation = 155;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 500;
            Item.rare = 3;
            Item.UseSound = SoundID.Item3;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<CigaretteBuff>();
            Item.buffTime = 3600;
            Item.UseSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SFX_Cigarette");
            Item.scale = 0.4f;


        }









        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "Parchment", 2);
            recipe.AddTile(TileID.Tables);
            recipe.Register();
        }

    }
}