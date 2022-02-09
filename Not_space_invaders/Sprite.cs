using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Not_space_invaders
{
    class Sprite
    {
        //creating the properties
        protected Texture2D spriteTexture;
        protected Color spriteColour;
        protected Rectangle spritePosition;

        private int frames;
        private float timeElapsed, timeToUpdate;
        private bool isLooping = false;

        private Vector2 origin;
        private float rotation = 0.0f;
        private float scale = 0.0f;
        private SpriteEffects spriteEffects;
        private Rectangle[] rectangles;
        private int frameIndex = 0;

        //constructer for vcreating instances of the class
        public Sprite(Texture2D inTexture, Rectangle inPosition, Color inColour)
        {
            spriteTexture = inTexture;
            spritePosition = inPosition;
            spriteColour = inColour;
        }
        public void DrawSprite(SpriteBatch inspriteBatch)
        {
            inspriteBatch.Draw(spriteTexture, spritePosition, spriteColour);
        }
        public void SetPosition(Rectangle inPosition)
        {
            spritePosition = inPosition;
        }
        public Rectangle GetPosition()
        {
            return spritePosition;
        }
    }
}
