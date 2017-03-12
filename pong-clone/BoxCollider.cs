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

        /// <summary>
        ///  checks for boundary collision and returns a bounce
        /// </summary>
        /// <param name="target">object that is collided with Texture2D</param>
        /// <param name="targetPos">collided target position</param>
        /// <param name="collider">the collider of the object Texture2D</param>
        /// <param name="colliderPos">the position of the collider object</param>
        /// <returns>returns the new position of the collider</returns>
       public Vector2 BoundaryCollision (Texture2D target, Vector2 targetPos, Texture2D collider, Vector2 colliderPos)
       {
            int firstHeight = target.Height;
            int firstWidth = target.Width;
            int secondHeight = collider.Height;
            int secondWidth = collider.Width;

            Rectangle firstRect = new Rectangle((int)targetPos.X, (int)targetPos.Y, firstHeight, firstWidth);
            Rectangle secondRect = new Rectangle((int)colliderPos.X, (int)colliderPos.Y, secondHeight, secondWidth);

            if (firstRect.Intersects(secondRect))
            {
                return new Vector2(colliderPos.X + 10, colliderPos.Y + 10);
            }    
            else
            {
                return new Vector2(colliderPos.X, colliderPos.Y);
            }
       }
    }
}
