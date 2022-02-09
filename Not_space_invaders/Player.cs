using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Not_space_invaders
{
    class Player : Sprite
    {
        public Player(Texture2D inTexture, Rectangle inPosition, Color inColour): base(inTexture, inPosition, inColour)
        {
            
        }
        public bool Collided()
        {
            return true;
        }
    }
}
