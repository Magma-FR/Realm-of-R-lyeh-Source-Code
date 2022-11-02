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

    public class PossessedPiggy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Possessed Piggybank");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.GiantWalkingAntlion];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 22;
            NPC.damage = 20;
            NPC.defense = 5;
            NPC.lifeMax = 130;
            NPC.value = 80f;
            NPC.aiStyle = 25;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.Item59;

            AIType = NPCID.Mimic;
            AnimationType = NPCID.GiantWalkingAntlion;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.18f;
        }


        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("An evil piggy bank that got a bit too empty of money through its lifetime. Even though it has wings, it cannot fly (lol)."),

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

                Dust d = Dust.NewDustPerfect(NPC.position, DustID.DungeonPink, speed * 5, Scale: 1.5f); ;
                d.noGravity = true;

            }

        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PiggyPorcelain>(), 1, 1, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.PiggyBank, 29, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.MoneyTrough, 35, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 4, 6));


        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            // Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
            // Common use is applying buffs/debuffs:

            int buffType = BuffID.Midas;
            // Alternatively, you can use a vanilla buff: int buffType = BuffID.Slow;

            int timeToAdd = 3 * 60; //This makes it 5 seconds, one second is 60 ticks
            target.AddBuff(buffType, timeToAdd);

            CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y - 20, target.width, target.height), new Color(234, 129, 178, 110), "That's my money, fool!", false, false);

        }
        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            CombatText.NewText(new Rectangle((int)NPC.position.X, (int)NPC.position.Y - 20, NPC.width, NPC.height), new Color(234, 129, 178, 180), "Ow that hurt!", false, false);

            return false;
        }

        public override void OnKill()
        {
            if (Main.netMode != NetmodeID.Server)
            {

                CombatText.NewText(new Rectangle((int)NPC.position.X + 30, (int)NPC.position.Y - 20, NPC.width, NPC.height), new Color(234, 129, 178, 105), "You got lucky that time!", false, false);


            }

        }
        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.Item59);
            CombatText.NewText(new Rectangle((int)NPC.position.X, (int)NPC.position.Y - 20, NPC.width, NPC.height), new Color(234, 129, 178, 180), "Oink!! Oi buddy, over here!!", false, false);

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            CombatText.NewText(new Rectangle((int)NPC.position.X, (int)NPC.position.Y - 20, NPC.width, NPC.height), new Color(258, 27, 124, 200), "I got your little friends as well!", false, false);

        }

    }
}

