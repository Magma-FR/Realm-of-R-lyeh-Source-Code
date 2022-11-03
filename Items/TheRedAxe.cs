using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using RealmOne.Common.Systems;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Transactions;

namespace RealmOne.Items
{
    public class TheRedAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Red Axe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'A weapon, a tool? Who matters, all we know is that it's red and full of magic!'"
             + "\n'Vanquish those annoying pests while you chop down some lumber ;)'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.useStyle = 1;
            Item.knockBack = 6;
            
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.crit = 6;
            Item.useTurn = true;
            Item.value = Item.buyPrice(gold: 3, silver: 40, copper: 80);
            Item.shoot = ProjectileID.RubyBolt;
            Item.shootSpeed = 60f;
            

        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.damage = 28;
                Item.DamageType = DamageClass.Melee;
                Item.width = 32;
                Item.height = 32;
                Item.useTime = 12;
                Item.useAnimation = 12;
                Item.useStyle = 1;
                Item.knockBack = 5;

                Item.rare = ItemRarityID.Red;
                Item.UseSound = SoundID.Item1;
                Item.autoReuse = true;
                Item.maxStack = 1;
                Item.crit = 6;
                Item.axe = 30;
                Item.useTurn = true;
                Item.value = Item.buyPrice(gold: 3, silver: 40, copper: 80);
                Item.shoot = 0;
                Item.shootSpeed = 0f;


            }
            else
            {

                Item.damage = 20;
                Item.DamageType = DamageClass.Melee;
                Item.width = 32;
                Item.height = 32;
                Item.useTime = 13;
                Item.useAnimation = 13;
                Item.useStyle = 1;
                Item.knockBack = 6;
                
                Item.rare = ItemRarityID.Red;
                Item.UseSound = SoundID.Item1;
                Item.autoReuse = true;
                Item.maxStack = 1;
                Item.crit = 6;
                Item.useTurn = true;
                Item.value = Item.buyPrice(gold: 3, silver: 40, copper: 80);
                Item.shoot = ProjectileID.RubyBolt;
                Item.shootSpeed = 60f;



            }
            return base.CanUseItem(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ruby, 15);
            recipe.AddIngredient(ItemID.RedStainedGlass, 20);
            recipe.AddIngredient(ItemID.RedTorch, 30);
            recipe.AddIngredient(ItemID.RedBrick, 10);
            recipe.AddTile(TileID.TeamBlockRed);
            recipe.AddTile(TileID.RedBrick);
            recipe.Register();
        }
       
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            
            Collision.AnyCollision(Item.position + Item.velocity, Item.velocity, Item.width, Item.height);
            SoundEngine.PlaySound(SoundID.Item130);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(0); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(4);
            position += Vector2.Normalize(velocity) * 21f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, ProjectileID.RubyBolt, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            else
                frame = texture.Frame();

            Vector2 frameOrigin = frame.Size() / 4f;
            Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
                time = 2f - time;

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.25f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(239, 68, 89, 200), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.34f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;
                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(255, 0, 147, 200), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.Red.ToVector3() * 0.6f);

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                Vector2 velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                Dust dust = Dust.NewDustPerfect(center + direction * distance, DustID.GemRuby, velocity);
                dust.scale = 1f;
                dust.fadeIn = 1.1f;
                dust.noGravity = true;
                dust.noLight = true;
                dust.alpha = 0;
            }
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

    }
}