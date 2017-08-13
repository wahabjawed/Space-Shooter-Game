using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceMaverick
{

    class SoundHandler
    {
        public static AudioEngine engine;
        public static SoundBank soundBank;
        public static WaveBank waveBank;
        public static Cue backgroundSound;
        public static Cue Sound;
        public static Cue PSound;
        public static Cue RSound;
        

        public static void Initailise()
        {
            engine = new AudioEngine("Content\\game_sound.xgs");
            soundBank = new SoundBank(engine, "Content\\Sound Bank.xsb");
            waveBank = new WaveBank(engine, "Content\\Wave Bank.xwb");
         

            

        }

        public static void playBackGround(Cue s)
        {
            backgroundSound = s;
            backgroundSound.Play();
      
        }

        public static void playSound(Cue s)
        {
            Sound = soundBank.GetCue(s.Name);
            
            Sound.Play();
        }

        public static void pauseSound(Cue s)
        {
            PSound = s;
           PSound.Pause();
        }

        public static void resumeSound(Cue s)
        {
            RSound = s;
            RSound.Resume();
        }
    }
}