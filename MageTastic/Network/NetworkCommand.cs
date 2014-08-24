using MageTastic.Entities;
using MageTastic.Entities.Characters;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Network
{
    enum NetworkCommandDestination
    {
        Director,
        Entity,
        Connection,
        PlayerMessage
    }

    [Serializable]
    class NetworkCommand
    {
        public readonly NetworkCommandDestination Destination;
        public readonly object Data;

        public NetworkCommand(NetworkCommandDestination destination, object data)
        {
            Destination = destination;
            Data = data;
        }
    }

    [Serializable]
    class EntityPayload
    {
        public readonly uint EntityId;
        public Direction? FacingDirection;
        public EntityState? AnimationState;
        public float? Health;

        public EntityPayload(uint entityId)
        {
            EntityId = entityId;
        }
    }
}
