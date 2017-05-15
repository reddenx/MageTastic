using openTk.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openTk.Physics
{
    public class QuadTree
    {
        private int MaxItems;
        private Rectangle Bounds;
        private List<GameObject> Items;

        private QuadTree NW;
        private QuadTree NE;
        private QuadTree SW;
        private QuadTree SE;

        //efficiency testing reveals 1 item max to be the best.....

        public QuadTree(int maxItems, Rectangle bounds)
        {
            MaxItems = maxItems;
            Bounds = bounds;
        }

        public List<GameObject> Query(Rectangle query)
        {
            var results = new List<GameObject>();
            Query(query, results);
            return results;
        }

        private void Query(Rectangle query, List<GameObject> results)
        {
            if (!Bounds.IntersectsWith(query))
                return;

            foreach (var item in Items)
            {
                if (GetCollisionRectangleFromGameObject(item).IntersectsWith(query))
                {
                    results.Add(item);
                }
            }

            if (NW == null)
                return;

            NW.Query(query, results);
            NE.Query(query, results);
            SW.Query(query, results);
            SE.Query(query, results);
        }

        public bool Insert(GameObject obj)
        {
            //TODO
            throw new NotImplementedException();
        }





        private Rectangle GetCollisionRectangleFromGameObject(GameObject obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
