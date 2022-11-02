using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using RealmOne.Items;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace RealmOne.Common.Systems
{
    public class rorAudio : ModSystem
    {
        public static readonly SoundStyle SFX_Scroll;
        public static readonly SoundStyle ElectricPulse;
        public static readonly SoundStyle SFX_BoomGun;
        public static readonly SoundStyle SFX_MetalSwing;
        public static readonly SoundStyle SFX_MetalClash;
        public static readonly SoundStyle SFX_ElectricDeath;
        public static readonly SoundStyle SFX_Porce;
        public static readonly SoundStyle SFX_Sonar;
        public static readonly SoundStyle SFX_Toast;
        public static readonly SoundStyle aughhhh;
        public static readonly SoundStyle Scroll;
        public static readonly SoundStyle SFX_Cigarette;
        public static readonly SoundStyle SFX_CrossbowShot;
        public static readonly SoundStyle SFX_CrossbowImpact;
        public static readonly SoundStyle SFX_CrossbowHit;
        public static readonly SoundStyle SFX_FlyingKnife;
        public static readonly SoundStyle SquirmoSummonSound;
        public static readonly SoundStyle blunderbussShot;
        public static readonly SoundStyle SFX_CrossbowLoad;
        public static readonly SoundStyle SFX_PumpShotgun;
        public static readonly SoundStyle OldGoldTink;
        public static readonly SoundStyle SFX_OldGoldBeam;
        public static readonly SoundStyle OldGoldChainSound;
        public static readonly SoundStyle SFX_Cord;
        public static readonly SoundStyle ModMenuClick;
        public static readonly SoundStyle SquirmoDiggingMiddle;
        public static readonly SoundStyle SquirmoMudBubbleBlow;
        public static readonly SoundStyle SquirmoMudBubblePop;
        public static readonly SoundStyle SFX_Cologne;
        public static readonly SoundStyle SFX_CologneClink;
        public static readonly SoundStyle SawbladeRev;
        public static readonly SoundStyle SFX_Shuriken;
        public static readonly SoundStyle TwinkleBell;
        public static readonly SoundStyle SFX_Acorn;
        public static readonly SoundStyle SFX_GrenadeThrow;
        public static readonly SoundStyle SFX_GrenadeRoll;
        public static readonly SoundStyle VINEBOOM;




        static rorAudio()
        {
            SFX_Scroll = new SoundStyle("RealmOne/Assets/Soundss/SFX_Scroll", (SoundType)0);
            ElectricPulse = new SoundStyle("RealmOne/Assets/Soundss/ElectricPulse", (SoundType)0);
            SFX_BoomGun = new SoundStyle("RealmOne/Assets/Soundss/SFX_BoomGun", (SoundType)0);
            SFX_MetalSwing = new SoundStyle("RealmOne/Assets/Soundss/SFX_MetalSwing", (SoundType)0);
            SFX_MetalClash = new SoundStyle("RealmOne/Assets/Soundss/SFX_MetalClash", (SoundType)0);
            SFX_ElectricDeath = new SoundStyle("RealmOne/Assets/Soundss/SFX_ElectricDeath", (SoundType)0);
            SFX_Porce = new SoundStyle("RealmOne/Assets/Soundss/SFX_Porce", (SoundType)0);
            SFX_Sonar = new SoundStyle("RealmOne/Assets/Soundss/SFX_Sonar", (SoundType)0);
            SFX_Toast = new SoundStyle("RealmOne/Assets/Soundss/SFX_Toast", (SoundType)0);
            aughhhh = new SoundStyle("RealmOne/Assets/Soundss/aughhhh", (SoundType)0);
            SFX_Cigarette = new SoundStyle("RealmOne/Assets/Soundss/SFX_Cigarette", (SoundType)0);
            SFX_CrossbowShot = new SoundStyle("RealmOne/Assets/Soundss/SFX_CrossbowShot", (SoundType)0);
            SFX_CrossbowImpact = new SoundStyle("RealmOne/Assets/Soundss/SFX_CrossbowImpact", (SoundType)0);
            SFX_CrossbowHit = new SoundStyle("RealmOne/Assets/Soundss/SFX_CrossbowHit", (SoundType)0);
            SFX_FlyingKnife = new SoundStyle("RealmOne/Assets/Soundss/SFX_FlyingKnife", (SoundType)0);
            SquirmoSummonSound = new SoundStyle("RealmOne/Assets/Soundss/SquirmoSummonSound", (SoundType)0);
            blunderbussShot = new SoundStyle("RealmOne/Assets/Soundss/blunderbussShot", (SoundType)0);
            SFX_CrossbowLoad = new SoundStyle("RealmOne/Assets/Soundss/SFX_CrossbowLoad", (SoundType)0);
            SFX_PumpShotgun = new SoundStyle("RealmOne/Assets/Soundss/SFX_PumpShotgun", (SoundType)0);
            OldGoldTink = new SoundStyle("RealmOne/Assets/Soundss/OldGoldTink", (SoundType)0);
            SFX_OldGoldBeam = new SoundStyle("RealmOne/Assets/Soundss/SFX_OldGoldBeam", (SoundType)0);
            OldGoldChainSound = new SoundStyle("RealmOne/Assets/Soundss/OldGoldChainSound", (SoundType)0);
            SFX_Cord = new SoundStyle("RealmOne/Assets/Soundss/SFX_Cord", (SoundType)0);
            ModMenuClick = new SoundStyle("RealmOne/Assets/Soundss/ModMenuClick", (SoundType)0);
            SquirmoDiggingMiddle = new SoundStyle("RealmOne/Assets/Soundss/SqurimoDiggingMiddle", (SoundType)0);
            SquirmoMudBubbleBlow = new SoundStyle("RealmOne/Assets/Soundss/SquirmoMudBubbleBlow", (SoundType)0);
            SquirmoMudBubblePop = new SoundStyle("RealmOne/Assets/Soundss/SquirmoMudBubblePop", (SoundType)0);
            SFX_Cologne = new SoundStyle("RealmOne/Assets/Soundss/SFX_Cologne", (SoundType)0);
            SFX_CologneClink = new SoundStyle("RealmOne/Assets/Soundss/SFX_CologneClink", (SoundType)0);
            SawbladeRev = new SoundStyle("RealmOne/Assets/Soundss/SawbladeRev", (SoundType)0);
            SFX_Shuriken = new SoundStyle("RealmOne/Assets/Soundss/SFX_Shuriken", (SoundType)0);
            TwinkleBell = new SoundStyle("RealmOne/Assets/Soundss/TwinkleBell", (SoundType)0);
            SFX_Acorn = new SoundStyle("RealmOne/Assets/Soundss/SFX_Acorn", (SoundType)0);
            SFX_GrenadeThrow = new SoundStyle("RealmOne/Assets/Soundss/SFX_GrenadeThrow", (SoundType)0);
            SFX_GrenadeRoll = new SoundStyle("RealmOne/Assets/Soundss/SFX_GrenadeRoll", (SoundType)0);
            VINEBOOM = new SoundStyle("RealmOne/Assets/Soundss/VINEBOOM", (SoundType)0);



        }
    }







}