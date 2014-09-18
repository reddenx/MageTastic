using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MageTastic.Utility;
using MageTastic.Engines;
using MageTastic.Entities.Characters.Enemies;
using MageTastic.UI;

namespace MageTastic.World
{
    //goal of this class is to provide a dynamic experience, 
    //first iteration will keep a minimum # of enemies alive
    //on screen at once
    class Director
    {
        private TickTimer CheckTheEquationTimer;
        private Random Rand;
        public int Score;

        public Director()
        {
            CheckTheEquationTimer = new TickTimer(5000);
            Rand = new Random();
            Score = 0;
        }

        public void Update(GameTime gameTime)
        {
            CheckTheEquationTimer.Update(gameTime);
            if (CheckTheEquationTimer.IsComplete)
            {
                CheckTheEquationTimer.Reset();

                var shouldBeAlive = GetMaxEnemyAmountViaSinEquation(gameTime.TotalGameTime);
                var areActuallyAlive = WorldEngine.GetEnemyCount();

                var amountToSpawn = shouldBeAlive - areActuallyAlive;
                var player = WorldEngine.GetAllPlayers().FirstOrDefault();

                for (int i = 0; i < amountToSpawn; ++i)
                {
                    var position = player.Position + new Vector2(Rand.Next(-200, 200), Rand.Next(-200, 200));
                    WorldEngine.CreateEnemyProto(position);
                }
            }
        }

        private int GetMaxEnemyAmountViaSinEquation(TimeSpan totalTime)
        {
            return 5 + (1 * totalTime.Seconds / 3);
        }

        public void NotifyEnemyDeath(ProtoEnemy protoEnemy)
        {
            ++Score;
            protoEnemy.RemoveFromWorld = true;
        }
    }
}
