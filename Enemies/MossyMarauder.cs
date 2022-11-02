using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using RealmOne.Enemies;
using RealmOne.Items;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace RealmOne.Enemies
{
    public class MossyMarauder : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mossy Marauder");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.ArmoredSkeleton];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 20;
            NPC.height = 42;
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 60;
            NPC.value = 80f;
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            AIType = NPCID.ArmoredSkeleton;
            AnimationType = NPCID.ArmoredSkeleton;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.5f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("This type of skeleton is an evolved and poisonous entity. Over time, surpassing heavy outfalls of bacteria and vines"),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Vinepoint>(), 36, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MossMarrow>(), 36, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoopyGrass>(), 2, 1, 3));

            npcLoot.Add(ItemDropRule.Common(ItemID.MudBlock, 2, 3, 6));

        }


        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            // Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
            // Common use is applying buffs/debuffs:

            int buffType = BuffID.Poisoned;
            // Alternatively, you can use a vanilla buff: int buffType = BuffID.Slow;

            int timeToAdd = 5 * 60; //This makes it 5 seconds, one second is 60 ticks
            target.AddBuff(buffType, timeToAdd);
        }

    }
}
