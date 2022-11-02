using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using System;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class EyePick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye Pick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'It stares at you while you dig, weird.'"
             + "\nCapable of mining Old Gold!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 13;
            Item.UseSound = SoundID.GlommerBounce;
            Item.useAnimation = 13;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(silver: 90);

            Item.rare = 1;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.crit = 2;
            Item.pick = 60;
            Item.useTurn = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod,"FleshyCornea", 12);
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(Mod, "FleshyCornea", 12);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            Collision.AnyCollision(Item.position + Item.velocity, Item.velocity, Item.width, Item.height);
            SoundEngine.PlaySound(SoundID.DD2_BetsyWindAttack, Item.position);
            
        }
    }
}