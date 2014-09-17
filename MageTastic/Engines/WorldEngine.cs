using MageTastic.Entities;
using MageTastic.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MageTastic.Entities.Characters;
using MageTastic.Entities.Characters.Players;
using MageTastic.Entities.Characters.Enemies;
using Microsoft.Xna.Framework;
using MageTastic.Utility;
using MageTastic.Entities.Projectiles;
using MageTastic.Entities.Characters.Skills;

namespace MageTastic.Engines
{
    //provides global access to the instance of the world and it's methods
    class WorldEngine
    {
        private static WorldEngine Instance;

        private Level CurrentLevel;
        private Random Random;
        private uint ObjectIdCounter;

        private WorldEngine()
        {
            Random = new Random();
            ObjectIdCounter = 0;
        }

        public static void Instantiate()
        {
            if (Instance == null)
            {
                Instance = new WorldEngine();
            }
        }

        public static void SetLevel(Level level)
        {
            Instance.CurrentLevel = level;
        }

        private static void AddEntityToWorld(Entity entity)
        {
            Instance.CurrentLevel.AddEntity(entity);
        }

        public static IEnumerable<Entity> GetAllPlayers()
        {
            return Instance.CurrentLevel.GetEntitiesOfTeam(EntityTeam.Players);
        }

        public static int GetEnemyCount()
        {
            return Instance.CurrentLevel.GetEntitiesOfTeam(EntityTeam.Enemies).Count(uu => uu.State.CurrentState != EntityState.Dead);
        }

        public static Random Rand { get { return Instance.Random; } }

        public static uint GetNextEntityId()
        {
            return Instance.ObjectIdCounter++;
        }

        //TODO create identification criteria, probably enum with parameters regarding level etc.
        public static void CreateEnemyProto(Vector2 location)
        {
            var enemy = new ProtoEnemy(Assets.CharacterAnimationSet, Assets.PlayerKnight, location);
            AddEntityToWorld(enemy);
        }

        //TODO this is proto code
        public static PlayerProto CreatePlayerProto()
        {
            var player = new PlayerProto(new Vector2(2000));
            AddEntityToWorld(player);
            return player;
        }

        public static void CreateProjectileProtoBlueOrd(Vector2 location, Vector2 velocity, int timeToLive, SkillBase skillUsed)
        {
            var orb = new ProjectileProtoBlueOrb(
            Assets.BlueMagicProjectileAnimationSet,
            Assets.BlueMagicProjectile,
            location,
            velocity,
            timeToLive,
            skillUsed);
            AddEntityToWorld(orb);
        }
    }
}
