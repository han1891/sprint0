using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
