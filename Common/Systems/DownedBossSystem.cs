using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RealmOne.Common.Systems
{
    public class DownedBossSystem : ModSystem
    {
        public static bool downedSquirmo;
        public static bool downedOutcropOutcast;


        public override void OnWorldLoad()
        {
            downedSquirmo = false;
            downedOutcropOutcast = false;
        }

        public override void OnWorldUnload()
        {
            downedSquirmo = false;
            downedOutcropOutcast = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (downedSquirmo)
            {
                tag.Set("downedSquirmo", (object)true);
            }

            if (downedOutcropOutcast)
            {
                tag.Set("downedOutcropOutcast", (object)true);
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedSquirmo = tag.ContainsKey("downedSquirmo");
            downedOutcropOutcast = tag.ContainsKey("downedOutcropOutcast");

        }


    }
}
