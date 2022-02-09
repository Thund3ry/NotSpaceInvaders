using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Not_space_invaders
{
    class Enemy : Sprite
    {
        private bool isDrawn;
        public Enemy(Texture2D inTexture, Rectangle inPosition, Color inColour, bool isDrawn, Sprite inSprite) : base(inTexture, inPosition, inColour)
        {

        }
        public void MoveLeft()
        {
            spritePosition.X -= 1;
        }
        public void MoveRight()
        {
            spritePosition.X += 1;
        }
        public bool IsDrawn
        {
            get { return isDrawn; }
            set { isDrawn = value; }
        }
        public void InitializeEnemyShips()
        {

        }
    }
}
