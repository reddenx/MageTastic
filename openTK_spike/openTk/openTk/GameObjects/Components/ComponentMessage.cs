using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openTk.GameObjects.Components
{
    public enum ComponentMessageTypes
    {
    }

    public class ComponentMessage
    {
        public GameObject Source;
        public ComponentMessageTypes MessageType;
    }
}
