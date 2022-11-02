using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;
using RealmOne.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace RealmOne.Items
{
    public class SandTwister : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Twister Yoyo"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Shoots mini homing sandstorms'"
                + "\n'Don't get twisted!");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Melee;
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 15;
            Item.useAnimation = 15; 
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4;
            Item.value = 30000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SandTwisterProj>();
            Item.shootSpeed = 20f;

            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;


        }
        private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy };


        public override bool AllowPrefix(int pre)
        {
            // return false to make the game reroll the prefix

            // DON'T DO THIS BY ITSELF:
            // return false;
            // This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true

            if (Array.IndexOf(unwantedPrefixes, pre) > -1)
            {
                // IndexOf returns a positive index of the element you search for. If not found, it's less than 0. Here check the opposite
                // Rolled a prefix we don't want, reroll
                return false;
            }
            // Don't reroll
            return true;
        }

       
        public override void AddRecipes()
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.SandstoneBrick, 30)
            .AddIngredient(ItemID.Cobweb, 20)
            .AddIngredient(ItemID.AntlionMandible, 4)

            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}