using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class TextSprite : ISprite
    {
        private Vector2 Location {  get; set; }
        private string Text { get; set; }
        private SpriteFont Font { get; set; }
        
        public TextSprite(string text, Vector2 location, SpriteFont font)
        {
            Location = location;
            Text = text;
            Font = font;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Location, Color.White);
        }
    }
}
