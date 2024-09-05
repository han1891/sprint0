using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class NonMovNonAniSprite : ISprite
    {
        public Texture2D Texture {  get; set; }
        public Vector2 Location { get; set; }

        public NonMovNonAniSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = location;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }
    }
}
