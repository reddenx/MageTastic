using MageTastic.Entities.State;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MageTastic.Utility.Parsing
{
    static class ParsingUtils
    {
        public static string[] GetBetween(string str, char start, char end, int offset = 0)
        {
            var datas = new List<string>();
            var startIndex = str.IndexOf(start, offset) + 1;
            while (startIndex > 0)
            {
                var endIndex = str.IndexOf(end, offset + startIndex);
                var between = str.Substring(startIndex, endIndex - startIndex);

                datas.Add(between);

                startIndex = str.IndexOf(start, startIndex) + 1;
            }
            return datas.ToArray();
        }


        public static Dictionary<EntityStates, EntityFrame[][]> GetAnimationSetFromFile(string filename)
        {
            //syntax: [<state,direction>{(parameter1)(parameter2)(...)...}{...}...]

            var animationSetMeta = new Dictionary<EntityStates, Dictionary<Direction, List<EntityFrame>>>();

            var completeFileText = File.ReadAllText(filename);
            foreach (var animationLine in GetBetween(completeFileText, '[', ']'))
            {
                var animationMetaData = GetBetween(animationLine, '<', '>')[0].Split(',');
                var state = (EntityStates)int.Parse(animationMetaData[0]);
                var direction = (Direction)int.Parse(animationMetaData[1]);

                var frames = new List<EntityFrame>();
                foreach (var framesLine in GetBetween(animationLine, '{', '}'))
                {
                    var parameters = GetBetween(framesLine, '(', ')');

                    var bounds = parameters[0].Split(',');
                    var physics = parameters[1].Split(',');
                    var origin = parameters[2].Split(',');
                    var rightAttachPoint = parameters[3].Split(',');
                    var leftAttachPoint = parameters[4].Split(',');
                    var source = parameters[6].Split(',');
                    var time = parameters[7].Split(',');

                    frames.Add(new EntityFrame(
                        bounds.ToPoint(),
                        physics.ToRectangle(),
                        origin.ToVector2() + new Vector2(.5f), //to center on pixel
                        rightAttachPoint.ToVector2() + new Vector2(.5f),
                        leftAttachPoint.ToVector2() + new Vector2(.5f),
                        null,
                        null,
                        null,
                        source.ToRectangle(),
                        time[0].ToInt()));
                }

                if (!animationSetMeta.Keys.Contains(state))
                {
                    animationSetMeta.Add(state, new Dictionary<Direction, List<EntityFrame>>());
                }

                animationSetMeta[state].Add(direction, frames);
            }

            //TODO this is a stupid data type, make it better, maybe not so bad
            var animationSet = new Dictionary<EntityStates, EntityFrame[][]>();

            foreach (var stateSet in animationSetMeta)
            {
                var frames = new EntityFrame[][]
                {
                    stateSet.Value[(Direction)0].ToArray(),
                    stateSet.Value[(Direction)1].ToArray(),
                    stateSet.Value[(Direction)2].ToArray(),
                    stateSet.Value[(Direction)3].ToArray(),
                };
                animationSet.Add(stateSet.Key, frames);
            }

            return animationSet;
        }

        private static Vector2 ToVector2(this string[] s)
        {
            return new Vector2(s[0].ToFloat(), s[1].ToFloat());
        }

        private static Point ToPoint(this string[] s)
        {
            return new Point(s[0].ToInt(), s[1].ToInt());
        }

        private static Rectangle ToRectangle(this string[] s)
        {
            return new Rectangle(s[0].ToInt(), s[1].ToInt(), s[2].ToInt(), s[3].ToInt());
        }

        private static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        private static float ToFloat(this string s)
        {
            return float.Parse(s);
        }
    }
}
