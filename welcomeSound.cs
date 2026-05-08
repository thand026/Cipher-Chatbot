using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;     //import to allow audio player

namespace ChatBot_Application___Cipher
{
    internal class AudioManager
    {
        private SoundPlayer _player;
        public void PlayWav(string filePath)
        {
            _player = new SoundPlayer("Boot up sound effect.wav");
            _player.Play();
        }
    }
}
