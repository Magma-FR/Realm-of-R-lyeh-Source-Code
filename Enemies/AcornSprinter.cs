using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using RealmOne.Enemies;
using RealmOne.Items;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;
using RealmOne.Common.Systems;
using Terraria.GameContent.ItemDropRules;
using Mono.Cecil;
using System;
using Terraria.DataStructures;

namespace RealmOne.Enemies
{

    public class AcornSprinter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn Sprinter");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 37;
            NPC.height = 50;
            NPC.damage = 7;
            NPC.defense = 3;
            NPC.lifeMax = 40;
            NPC.value = 50f;
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.DD2_KoboldFlyerHurt;
            NPC.DeathSound = SoundID.DD2_KoboldFlyerDeath;

            AIType = NPCID.GiantWalkingAntlion;
            AnimationType = NPCID.Zombie;

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
				new FlavorTextBestiaryInfoElement("Hiding in the thickest of grasses, to the tops of the trees, this hyper acorn dashes and leaps onto any Terrarian that goes near!"),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
            });
        }
        public override void HitEffect(int hitDirection, double damage)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 speed = Main.rand.NextVector2Square(1f, 1f);

                Dust d = Dust.NewDustPerfect(NPC.position, DustID.t_LivingWood, speed * 5, Scale: 1f); ;
                d.noGravity = true;

            }

        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            
            npcLoot.Add(ItemDropRule.Common(ItemID.Acorn, 1, 1, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.Wood, 3, 4, 6));
            npcLoot.Add(ItemDropRule.Common(ItemID.LivingWoodWand, 40, 1, 1));


        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            // Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
            // Common use is applying buffs/debuffs:

            for (int d = 0; d < 30; d++)
            {
                Dust.NewDust(target.position, target.width, target.height, DustID.t_LivingWood, 0f, 0f, 150, default, 1.5f);
            }

        }
      

       
        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(rorAudio.SFX_Acorn);

        }
       

    }
}

