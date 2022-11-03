using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

using Terraria.Localization;
using Terraria.Audio;
using RealmOne.Projectiles;
using System;
using System.Collections.Generic;

namespace RealmOne.Items
{
    public class NukeCukeJuiceCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nuke Cuke Juice Cannon"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("'Spray a fu** ton of toxic spray'"
            + "\nShoots a forced and sludgy explosive mud glob"
            +"\nStick the glob on a tile and let it charge up its power, dealing 2x the aoe and penetrate up to 3 enemies"
             + $"\nUses Mud Blocks [i:{ItemID.MudBlock}]");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 20;
            Item.knockBack = 4f;
            Item.value = 30000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item34;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Gel;
            Item.noMelee = true;
            Item.shootSpeed = 30f;
            Item.shoot = ProjectileID.SporeGas2;
            Item.CloneDefaults(ItemID.Flamethrower);
            

        }
     

        
  


        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6  , 0);
            return offset;
        }

    }
}