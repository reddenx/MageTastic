using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SinglePlayerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SinglePlayerEngine.GameState
{
    abstract class GameStateBase
    {
        private readonly GameContainer Context;

        protected GameStateBase(GameContainer context)
        {
            Context = context;
        }

        protected GameStateBase(GameStateBase previousState)
        {
            Context = previousState.Context;
        }

        abstract protected void Startup(ContentManager content);
        public void StartupAsync(ContentManager content, Action callback)
        {
            GetBackgroundLoadingThread(new ParameterizedThreadStart((contentObj) =>
            {
                Startup(contentObj as ContentManager);
                callback();
            })).Start(content);
        }

        abstract protected void Shutdown(ContentManager content);
        public void ShutdownAsync(ContentManager content, Action callback)
        {
            GetBackgroundLoadingThread(new ParameterizedThreadStart((contentObj) =>
            {
                Shutdown(contentObj as ContentManager);
                callback();
            })).Start(content);
        }

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(GameTime gameTime);

        private Thread GetBackgroundLoadingThread(ParameterizedThreadStart threadStart)
        {
            var loadThread = new Thread(threadStart);
            loadThread.IsBackground = true;
            return loadThread;
        }

        protected class AsyncThreadContext
        {
            public ContentManager Content { get; private set; }
            public Action Callback { get; private set; }

            public AsyncThreadContext(ContentManager content, Action callback)
            {
                Content = content;
                Callback = callback;
            }
        }
    }
}
