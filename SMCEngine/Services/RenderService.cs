using Microsoft.Xna.Framework;
using SMCEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCEngine.Services
{
    public class RenderService
    {
        //camera lives here

        public static void Update(GameTime gameTime)
        {
            //udpate camera
            throw new NotImplementedException();
        }

        public static void RenderEntity(Entity entity)
        {
            //draw all the entities
            throw new NotImplementedException();
        }

        public static Vector2 TranslateWindowsToWorldSpace(Point windowsSpace)
        {
            //convert through the camera transform
            throw new NotImplementedException();
        }

        public static void DrawDevDot(Vector2 position)
        {
            //draw dev square
            throw new NotImplementedException();
        }

        public static void DrawDevLine(Vector2 start, Vector2 end)
        {
            //draw line from start to end
            throw new NotImplementedException();
        }

        public static void PointCamera(Vector2 position)
        {
            //move camera to position
            throw new NotImplementedException();
        }

        public static void LockEntity(Entity entity)
        {
            //set current camera target to entity
            throw new NotImplementedException();
        }
    }
}
