
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Items;
using Terraria.GameContent.ItemDropRules;
using static Terraria.GameContent.ItemDropRules.Conditions;
using RealmOne.Items.Placeables;
using System;
using RealmOne.Vanities;

namespace RealmOne.GlobalNPCList
{
	public class ModGlobalNPCList : GlobalNPC
	{
		// ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
		// Here we go through all of them, and how they can be used.
		// There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.
	 
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Demon)
			{
				
			    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2)); // 4 and 1 is the chance, so 1 out of 4 chance of dropping it. And two is the amount you will probably get
			}
			if (npc.type == NPCID.Hellbat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2));
			}
			if (npc.type == NPCID.LavaSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2));
			}
			if (npc.type == NPCID.FireImp)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 2));
			}
			if (npc.type == NPCID.BoneSerpentHead)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 3));
			}
			if (npc.type == NPCID.VoodooDemon)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 3));
			}

			if (npc.type == NPCID.Demon)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 4, 1, 3));
			}


			//Goblin Army
			if (npc.type == NPCID.GoblinArcher)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4	, 1, 3));

			}
			if (npc.type == NPCID.GoblinPeon)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinScout)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinThief)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinWarrior)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinSorcerer)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 3));
			}
			if (npc.type == NPCID.GoblinSummoner)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GizmoScrap>(), 4, 1, 5));
			}

			if (npc.type == NPCID.ServantofCthulhu)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FleshyCornea>(), 3, 1, 2));
			}

			if (npc.type == NPCID.EyeofCthulhu)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyePick>(), 5, 1, 1));

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FleshyCornea>(), 1, 1, 10));
			}


			if (npc.type == NPCID.WallofFlesh)
			{
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Crimcore>(), 2, 1, 12));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Flamestone>(), 2, 1, 12));
			}

			if (npc.type == NPCID.KingSlime)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Accessories.RoyalRawhide>(), 2, 1, 1));
			}
			if (npc.type == NPCID.SkeletronHead)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Accessories.DungeonPendant>(), 2, 1, 1));
			}

			if (npc.type == NPCID.Vampire)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<vampdag>(), 4, 1, 30)); //4 out of 1 
			}

			if (npc.type == NPCID.VampireBat)
			{

				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<vampdag>(), 4, 1, 30)); //4 out of 1 
			}

            if (npc.type == NPCID.GiantFungiBulb)
            {
                new ItemDropWithConditionRule(ModContent.ItemType<ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }

            if (npc.type == NPCID.AnomuraFungus)
            {
                new ItemDropWithConditionRule(ModContent.ItemType<ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }
            if (npc.type == NPCID.MushiLadybug)
            {
				new ItemDropWithConditionRule(ModContent.ItemType <ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }
            if (npc.type == NPCID.SporeSkeleton)
            {
                new ItemDropWithConditionRule(ModContent.ItemType<ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }
            if (npc.type == NPCID.SporeBat)
            {
                new ItemDropWithConditionRule(ModContent.ItemType<ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }
            if (npc.type == NPCID.FungiBulb)
            {
                new ItemDropWithConditionRule(ModContent.ItemType<ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }
            if (npc.type == NPCID.ZombieMushroom)
            {
                new ItemDropWithConditionRule(ModContent.ItemType<ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }
            if (npc.type == NPCID.ZombieMushroomHat)
            {
                new ItemDropWithConditionRule(ModContent.ItemType<ShroomiteShattershards>(), 3, 1, 5, new IsHardmode());

            }
        }
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			// This example does not use the AppliesToEntity hook, as such, we can handle multiple npcs here by using if statements.
			if (type == NPCID.Merchant)
			{
				// Adding an item to a vanilla NPC is easy:
				// This item sells for the normal price.
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<TundraThrowingKnife>());
				nextSlot++; // Don't forget this line, it is essential.

				// We can use shopCustomPrice and shopSpecialCurrency to support custom prices and currency. Usually a shop sells an item for item.value.
				// Editing item.value in SetupShop is an incorrect approach.

				// This shop entry sells for 2 Defenders Medals.
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<sparky>());
				shop.item[nextSlot].shopCustomPrice = 2;

				nextSlot++;


			}
            if (type == NPCID.Clothier)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<SkullMask>());
                nextSlot++; // Don't forget this line, it is essential.

                // We can use shopCustomPrice and shopSpecialCurrency to support custom prices and currency. Usually a shop sells an item for item.value.
                // Editing item.value in SetupShop is an incorrect approach.

                // This shop entry sells for 2 Defenders Medals.
             



            }



        }

    }
	
}
