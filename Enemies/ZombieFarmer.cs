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
    public class ZombieFarmer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zombie Farmer");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];

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
            NPC.damage = 13;
            NPC.defense = 3;
            NPC.lifeMax = 50;
            NPC.value = 80f;
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            AIType = NPCID.Zombie;
            AnimationType = NPCID.Zombie;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A withered and undead zombie, looking for its next meal to plant in its fields"),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.Common(ItemID.Hay, 2, 6, 12));
            npcLoot.Add(ItemDropRule.Common(ItemID.Sickle, 38, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.GrassSeeds, 5, 1, 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Wheat>(), 2, 5, 8));

        }




    }
}