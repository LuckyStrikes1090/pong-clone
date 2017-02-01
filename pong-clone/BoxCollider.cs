using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong_clone
{
    class BoxCollider
    {
        /// <summary>
        /// checks boundary collider of a game object and returns a distance
        /// </summary>
        
        public bool CheckBounds (Texture2D first, Vector2 firstPos, Texture2D second, Vector2 secondPos)
        {
            int firstHeight = first.Height;
            int firstWidth = first.Width;
            int secondHeight = second.Height;
            int secondWidth = second.Width;

            Rectangle firstRect = new Rectangle((int)firstPos.X, (int)firstPos.Y, firstHeight, firstWidth);
            Rectangle secondRect = new Rectangle((int)secondPos.X, (int)secondPos.Y, secondHeight, secondWidth);

            if (firstPos == secondPos)
                return true;
            else if (firstRect.Intersects(secondRect))
                return true;
            else if (secondRect.Intersects(firstRect))
                return true;
            else
                return false;
            
        }
    }
}
