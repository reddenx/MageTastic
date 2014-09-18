using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MageTastic.Utility;
using MageTastic.Engines;
using MageTastic.Entities.Characters.Enemies;

namespace MageTastic.World
{
    //goal of this class is to provide a dynamic experience, 
    //first iteration will keep a minimum # of enemies alive
    //on screen at once
    class Director
    {
        private TickTimer CheckTheEquationTimer;
        private Random Rand;
        public int Score = 0;

        public Director()
        {
            CheckTheEquationTimer = new TickTimer(5000);
            Rand = new Random();
        }

        public void Update(GameTime gameTime)
        {
            CheckTheEquationTimer.Update(gameTime);
            if (CheckTheEquationTimer.IsComplete)
            {
                CheckTheEquationTimer.Reset();

                var shouldBeAlive = GetMaxEnemyAmountViaSinEquation();
                var areActuallyAlive = WorldEngine.GetEnemyCount();

                var amountToSpawn = shouldBeAlive - areActuallyAlive;
                var player = WorldEngine.GetAllPlayers().FirstOrDefault();

                for (int i = 0; i < amountToSpawn; ++i)
                {
                    var position = player.Position + new Vector2(Rand.Next(-200,200), Rand.Next(-200,200));
                    WorldEngine.CreateEnemyProto(position);
                }
            }
        }

        private int GetMaxEnemyAmountViaSinEquation()
        {
            return 5;
        }

        public void NotifyEnemyDeath(ProtoEnemy protoEnemy)
        {
            ++Score;
            protoEnemy.RemoveFromWorld = true;
        }
    }
}
