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
using RealmOne;
using System.IO;


namespace RealmOne.Enemies
{
    internal class MegaSquirmHead : WormHead
    {
        public override int BodyType => ModContent.NPCType<MegaSquirmBody>();

        public override int TailType => ModContent.NPCType<MegaSquirmTail>();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Squirm");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.DiggerHead];

         

            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                CustomTexturePath = "RealmOne/Enemies/ArtyWorm", // If the NPC is multiple parts like a worm, a custom texture for the Bestiary is encouraged.
                Position = new Vector2(40f, 28f),
                PortraitPositionXOverride = 0f,
                PortraitPositionYOverride = 12f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
        }

        public override void SetDefaults()
        {
            // Head is 10 defence, body 20, tail 30.
            NPC.CloneDefaults(NPCID.DiggerHead);
            NPC.aiStyle = -1;
            NPC.lifeMax = 110;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.damage = 7;
            NPC.defense = 1;
            NPC.DeathSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SquirmoMudBubblePop");
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.25f;
        }


        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
              BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
              BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
              BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Consuming and scavenging anything and anywhere it goes, serving for something much more disasterous"),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
            });
        }
        public override void HitEffect(int hitDirection, double damage)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);

                Dust d = Dust.NewDustPerfect(NPC.position, DustID.Worm, speed * 5, Scale: 2f); ;
                d.noGravity = true;

            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {


            npcLoot.Add(ItemDropRule.Common(ItemID.MudBlock, 2, 1, 3));


        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            // Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
            // Common use is applying buffs/debuffs:

            int buffType = BuffID.Slow;
            // Alternatively, you can use a vanilla buff: int buffType = BuffID.Slow;

            int timeToAdd = 2 * 60; //This makes it 5 seconds, one second is 60 ticks
            target.AddBuff(buffType, timeToAdd);
        }
        public override void Init()
        {
            // Set the segment variance
            // If you want the segment length to be constant, set these two properties to the same value
            MinSegmentLength = 5;
            MaxSegmentLength = 10;

            CommonWormInit(this);
        }
        internal static void CommonWormInit(Worm worm)
        {
            // These two properties handle the movement of the worm
            worm.MoveSpeed = 6f;
            worm.Acceleration = 0.09f;
        }
        private int attackCounter;
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(attackCounter);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            attackCounter = reader.ReadInt32();
        }

        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (attackCounter > 0)
                {
                    attackCounter--; // tick down the attack counter.
                }

                Player target = Main.player[NPC.target];
                // If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
                if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
                {
                    Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ProjectileID.MudBall, 5, 0, Main.myPlayer);
                    Main.projectile[projectile].timeLeft = 300;
                    attackCounter = 500;
                    NPC.netUpdate = true;
                    Main.projectile[projectile].velocity *= 11f;

                }
            }
        }

    }
    internal class MegaSquirmBody : WormBody
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Squirm");

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.DiggerBody);
            NPC.aiStyle = -1;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.damage = 6;
            NPC.defense = 2;

            NPC.DeathSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SquirmoMudBubblePop");
        }

        public override void Init()
        {
            MegaSquirmHead.CommonWormInit(this);
        }
    }

    internal class MegaSquirmTail : WormTail
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Squirm");

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.DiggerTail);
            NPC.aiStyle = -1;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.damage = 5;
            NPC.defense = 3;

            NPC.DeathSound = new SoundStyle($"{nameof(RealmOne)}/Assets/Soundss/SquirmoMudBubblePop");
        }

        public override void Init()
        {
            MegaSquirmHead.CommonWormInit(this);
        }
    }
}


