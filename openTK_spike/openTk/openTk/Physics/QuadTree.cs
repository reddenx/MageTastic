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

        public bool Insert(GameObject item)
        {
            var newItemBounds = GetCollisionRectangleFromGameObject(item);
            //check if it fits in me
            if (!Bounds.Contains(newItemBounds))
            {
                return false;
            }

            //if it does, check if I'm at my capacity, if not, add and finish, otherwise split and continue
            if (Items.Count < MaxItems)
            {
                Items.Add(item);
                return true;
            }
            else
            {
                Split();
            }

            //now that things are all prepped, lets put it in a child
            if (NW.Insert(item))
                return true;
            if (NE.Insert(item))
                return true;
            if (SW.Insert(item))
                return true;
            if (SE.Insert(item))
                return true;

            //if we're here, it didn't fit in any children and has to go here :(
            Items.Add(item);
            return true;
        }

        private void Split()
        {
            if (NW == null && Bounds.Width > 1 && Bounds.Height > 1)
            {
                var newWidth = Bounds.Width / 2;
                var newHeight = Bounds.Height / 2;
                NW = new QuadTree(MaxItems, new Rectangle(Bounds.X, Bounds.Y, newWidth, newHeight));
                NE = new QuadTree(MaxItems, new Rectangle(Bounds.X + newWidth, Bounds.Y, newWidth, newHeight));
                SW = new QuadTree(MaxItems, new Rectangle(Bounds.X, Bounds.Y + newHeight, newWidth, newHeight));
                SE = new QuadTree(MaxItems, new Rectangle(Bounds.X + newWidth, Bounds.Y + newHeight, newWidth, newHeight));
            }
        }

        public List<Rectangle> GetDebugRectangles()
        {
            var results = new List<Rectangle>();
            GetDebugRectangles(results);
            return results;
        }

        private void GetDebugRectangles(List<Rectangle> results)
        {
            results.Add(Bounds);

            if (NW == null)
                return;

            NW.GetDebugRectangles(results);
            NE.GetDebugRectangles(results);
            SW.GetDebugRectangles(results);
            SE.GetDebugRectangles(results);
        }

        private Rectangle GetCollisionRectangleFromGameObject(GameObject obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
