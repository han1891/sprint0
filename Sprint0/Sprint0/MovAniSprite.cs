using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class MovAniSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public int currFrame;
        public int totalFrames;
        public Vector2 Location;

        public MovAniSprite(Texture2D texture, Vector2 location, int rows, int cols)
        {
            Texture = texture;
            Rows = rows;
            Cols = cols;
            Location = location;
            currFrame = 0;
            totalFrames = Rows * Cols;
        }

        public void Update()
        {
            // update location of sprite, reset when reaches end of frame
            if (Location.X >= 427 && Location.X <= 854)
            {
                Location.X++;
            }
            else
            {
                Location.X = 427;
            }

            // update frame of sprite to next frame
            currFrame++;
            if (currFrame == totalFrames)
            {
                currFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Cols;
            int height = Texture.Height / Rows;
            int row = currFrame / Cols;
            int column = currFrame % Cols;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
