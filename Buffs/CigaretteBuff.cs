using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RealmOne.Buffs;
using RealmOne.Items;

namespace RealmOne.Buffs
{
    public class CigaretteBuff : ModBuff
    {
        public override void SetStaticDefaults()


        {
            DisplayName.SetDefault("Cigarette Buff");
            Description.SetDefault("'You're really feelin it right now'");
           

        }

       
        public override void Update(Player player, ref int buffIndex)
        {

            player.GetDamage(DamageClass.Generic) += 0.26f;
            player.GetAttackSpeed(DamageClass.Generic) += 0.26f;
           


        }




    }
}