﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class ExitCommand : ICommand
    {
        private Game1 myGame;
        public ExitCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Exit();
        }
    }
}
