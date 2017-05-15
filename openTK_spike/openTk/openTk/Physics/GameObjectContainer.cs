using openTk.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openTk.Physics
{
    public class GameObjectContainer
    {
        private readonly List<GameObject> EnumerableObjects;
        private readonly Dictionary<Guid, GameObject> IndexableObjects;
        private readonly QuadTree LocationableObjects;
    }
}
