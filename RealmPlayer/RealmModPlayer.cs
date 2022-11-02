using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using RealmOne;
using RealmOne.Items;
using RealmOne.Projectiles;
using Terraria.Localization;
using CsvHelper.TypeConversion;
using System.Drawing;
using Microsoft.Xna.Framework;

using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Terraria.UI;
using Terraria.Audio;
using Terraria.Achievements;
using Terraria.Utilities;
using Color = Microsoft.Xna.Framework.Color;

namespace RealmOne.RealmPlayer
{
    
    public class RealmModPlayer:Terraria.ModLoader.ModPlayer
    {
        public override bool ShiftClickSlot(Item[] inventory, int context, int slot)
        {
            // Apply our changes if this item is in inventory and is gel
            if (context == ItemSlot.Context.InventoryItem && inventory[slot].type == ModContent.ItemType<OtherWorldly>()); 
            {
                inventory[slot].color = Main.mouseColor; // Change the color of the item into a "random" color
                inventory[slot].rare = Main.rand.Next(ItemRarityID.Count); // Random rarity
             
                SoundEngine.PlaySound(SoundID.Item4); // Play mana crystal using sound

                // Block vanilla code so the item will not be picked up when it is clicked.
                return true;
            }
            return base.ShiftClickSlot(inventory, context, slot);
        }

        // Here we override the cursor style
        public override bool HoverSlot(Item[] inventory, int context, int slot)
        {
            // Apply our changes if this item is in inventory and is gel
            if (context == ItemSlot.Context.InventoryItem && inventory[slot].type == ModContent.ItemType<OtherWorldly>()) ;
            {
                // If player is holding shift, use FavoriteStar texture to indicate that a special action will be performed
                if (ItemSlot.ShiftInUse)
                {
                    Main.cursorOverride = CursorOverrideID.FavoriteStar;
                    return true; // return true to prevent other things from overriding cursor
                }
            }
            return base.HoverSlot(inventory, context, slot);
        }





        public override void OnEnterWorld(Player player)
        {
           
        
            if (Main.netMode != NetmodeID.Server)
            {

                CombatText.NewText(new Rectangle((int)player.position.X + 30, (int)player.position.Y - 20, player.width, player.height), new Color(200, 129, 178, 255), "Another day, another disappointment ", false, false);


            }

        

    }
     
        public override void OnRespawn(Player player)
        {
            if (Main.netMode != 2)
            {
                Main.NewText(Language.GetTextValue("Death is only so fragile, yet you take advantage of it."), (byte)218, (byte)39, (byte)44);

            }
        }
        public override void PlayerConnect(Player player)
        {
            if (Main.netMode != 2)
            {
                Main.NewText(Language.GetTextValue("'Your acquaintance wants to feel distress as well I see'"), (byte)64, (byte)16, (byte)227);
            }
        }
        public override void PlayerDisconnect(Player player)
        {
            if (Main.netMode != 2)
            {
                Main.NewText(Language.GetTextValue("'Never wait a second longer or shorter, it will always drive the pain towards you'"), (byte)210, (byte)30, (byte)30);
            }
        }

        public override void PostNurseHeal(NPC nurse, int health, bool removeDebuffs, int price)
        {
            if (Main.netMode != 2)
            {
                Main.NewText(Language.GetTextValue("'Regeneratating is more natural and increases your cardiovascular immunity, avoid healing, you pussy'"), (byte)210, (byte)100, (byte)175);
            }
        }
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            
            return (IEnumerable<Item>)(object)new Item[2]
            {
                new Item(ModContent.ItemType<SpaceStarfish>(), 1, 0),
                new Item(ModContent.ItemType<BreadLoaf>(), 1, 0)
            };
        }
    }
}
