using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;
using RealmOne.Items;

namespace RealmOne.Buffs
{
    public class TangledBuff : ModBuff
    {
        public override void SetStaticDefaults()


        {
            DisplayName.SetDefault("Tangled");
            Description.SetDefault("'Wrath of the vines grows in you, Greatly slows enemies and inflict poison'");
           

        }

       
        public override void Update(Player player, ref int buffIndex)
        {
            
            player.statDefense += 6;
            player.buffImmune[BuffID.Poisoned] = true;
            player.AddBuff(BuffID.Poisoned, 300);
            
        }


    }


}