using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class MouseController : IController
    {
        private List<(Rectangle, ICommand, int)> mouseMappings;

        public MouseController()
        {
            mouseMappings = new List<(Rectangle, ICommand, int)>();
        }

        public void RegisterCommand(Rectangle rectangle, ICommand command, int button)
        {
            mouseMappings.Add((rectangle, command, button));
        }

        public void Update()
        {
            var mouseState = Mouse.GetState();
            foreach (var mouse in mouseMappings)
            {
                if (mouse.Item3 == 0)
                {
                    if (mouse.Item1.Contains(mouseState.Position) && (mouseState.LeftButton == ButtonState.Pressed))
                    {
                        mouse.Item2.Execute();
                    }
                }
                if(mouse.Item3 == 1)
                {
                    if (mouse.Item1.Contains(mouseState.Position) && (mouseState.RightButton == ButtonState.Pressed))
                    {
                        mouse.Item2.Execute();
                    }
                }
            }
        }
    }
}
