using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class NonMovNonAniCommand : ICommand
    {
        private Game1 myGame;

        public NonMovNonAniCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currSprite =  Game1.Sprite.fixedNonAni;
        }
    }
}
