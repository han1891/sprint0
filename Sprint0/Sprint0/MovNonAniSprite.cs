using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class MovNonAniSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location;

        public MovNonAniSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = location;
        }
        public void Update()
        {
            // update location of sprite, reset when reaches end of frame
            if (Location.Y >= 240 && Location.Y <= 480)
            {
                Location.Y++;
            }
            else
            {
                Location.Y = 240;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }
    }
}
