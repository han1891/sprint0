﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class MovAniCommand : ICommand
    {
        private Game1 myGame;

        public MovAniCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currSprite = Game1.Sprite.nonFixedAni;
        }
    }
}
