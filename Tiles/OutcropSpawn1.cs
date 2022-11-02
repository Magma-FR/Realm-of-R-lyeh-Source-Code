using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using RealmOne.Tiles;
using Terraria.DataStructures;

namespace RealmOne.Tiles
{
    internal class OutcropSpawn1 : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.AllTiles[Type] = true;

            Main.tileSolid[Type] = true;
            


            AddMapEntry(new Color(170, 146, 185), CreateMapEntryName());

            DustType = DustID.Tungsten;
            ItemDrop = ModContent.ItemType<Items.Placeables.Outcrop>();

            HitSound = SoundID.Tink;
            
            MineResist = 1.5f;
            MinPick = 100;
        }
    }
}