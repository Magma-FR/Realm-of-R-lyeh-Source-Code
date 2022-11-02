using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using RealmOne;
using RealmOne.Items;
using Terraria.GameContent;

namespace RealmOne.Global
{
    // This is another part of the ExampleShiftClickSlotPlayer.cs that adds a tooltip line to the gel
    public class ShiftClickPlayer : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ModContent.ItemType<OtherWorldly>();

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // Here we add a tooltip to the gel to let the player know what will happen
            tooltips.Add(new(Mod, "SpecialShiftClick", "Shift-click on this item to show what the difficulty compares to"));
        }
    }
}