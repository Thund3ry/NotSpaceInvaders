using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Not_space_invaders
{
    class Bullet : Sprite
    {
        int xWhileShooting;

        public Bullet(Texture2D inTexture, Rectangle inPosition, Color inColour) : base(inTexture, inPosition, inColour)
        {
            //yPosition = spritePosition.Y;
            //xPosition = spritePosition.X;
        }
        public void Fire(int playerY, int playerX)
        {
            if (spritePosition.Y == playerY + 2)
            {
                xWhileShooting = spritePosition.X;
            }
            if (spritePosition.Y > 0)
            {
                spritePosition.Y -= 1;
                spritePosition.X = xWhileShooting;
            }
            else if (spritePosition.Y <= 0)
            {
                spritePosition.Y = playerY + 2;
                spritePosition.X = playerX + spriteTexture.Width / 2 - 5;
            }
        }
        public void Return(int playerY, int playerX)
        {
                spritePosition.Y = playerY + 2;
                spritePosition.X = playerX + spriteTexture.Width / 2 - 5;
        }
    }
}
