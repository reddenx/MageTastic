using MageTastic.Entities.State;
using MageTastic.World;
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


        public static Dictionary<EntityState, EntityFrame[][]> GetAnimationSetFromFile(string filename)
        {
            //syntax: [<state,direction>{(parameter1)(parameter2)(...)...}{...}...]

            var animationSetMeta = new Dictionary<EntityState, Dictionary<Direction, List<EntityFrame>>>();

            var completeFileText = File.ReadAllText(filename);
            foreach (var animationLine in GetBetween(completeFileText, '[', ']'))
            {
                var animationMetaData = GetBetween(animationLine, '<', '>')[0].Split(',');
                var state = (EntityState)int.Parse(animationMetaData[0]);
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

            var animationSet = new Dictionary<EntityState, EntityFrame[][]>();

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

        public static Tile[,] GetLevelFromImage(string filename)
        {
            var bitmap = new System.Drawing.Bitmap(filename);
            var mapData = new int[bitmap.Width, bitmap.Height];

            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    var pixel = bitmap.GetPixel(x, y);

                    switch (pixel.Name)
                    {
                        case "ff0000ff": //blue water 0
                            mapData[x, y] = 0;
                            break;
                        case "ffffff00":
                            mapData[x, y] = 1;
                            break;
                        case "ff00ff00":
                            mapData[x, y] = 2;
                            break;
                        default:
                            mapData[x, y] = 1;
                            break;
                    }
                }
            }

            return GetLevelFromData(mapData);
        }

        //TODO THIS IS A FUCKING WRECK, clean it up, get the data in a file, present algorithm better
        public static Tile[,] GetLevelFromData(int[,] data)
        {
            //again too lazy today to make it a real parser, but here's where it would parse

            var map = new Tile[data.GetLength(0), data.GetLength(1)];

            for (int y = 0; y < data.GetLength(1); ++y)
            {
                for (int x = 0; x < data.GetLength(0); ++x)
                {
                    //calculate what tile it is based on number here

                    int fg = data[x, y];
                    int bg = fg;

                    if (x != 0 && x < data.GetLength(0) - 1 && y != 0 && y < data.GetLength(1) - 1)
                    {
                        bg = GetBGFromMap(new Point(x, y), data, fg);

                        if (fg == bg)
                        {
                            map[x, y] = new Tile(Assets.TileMapTexture, Assets.BlendedTileSet[fg][bg][0], new Rectangle(x * 16, y * 16, 16, 16));
                        }
                        else
                        {
                            int id = data[x + 1, y] != fg ? GetIdFromKnownMap(1, 0) : 0;
                            id += data[x, y + 1] != fg ? GetIdFromKnownMap(0, 1) : 0;
                            id += data[x - 1, y] != fg ? GetIdFromKnownMap(-1, 0) : 0;
                            id += data[x, y - 1] != fg ? GetIdFromKnownMap(0, -1) : 0;

                            if (id == 0)
                            {
                                id = data[x + 1, y + 1] != fg ? GetIdFromKnownMap(1, 1) : 0;
                                id += data[x - 1, y + 1] != fg ? GetIdFromKnownMap(-1, 1) : 0;
                                id += data[x - 1, y - 1] != fg ? GetIdFromKnownMap(-1, -1) : 0;
                                id += data[x + 1, y - 1] != fg ? GetIdFromKnownMap(1, -1) : 0;
                            }
                            //add cross
                            //if 15 add corners

                            map[x,y] = new Tile(Assets.TileMapTexture, Assets.BlendedTileSet[bg][fg][id], new Rectangle(x * 16, y * 16, 16, 16));
                        }
                    }
                    else
                    {
                        map[x,y] = new Tile(Assets.TileMapTexture, Assets.BlendedTileSet[bg][fg][0], new Rectangle(x * 16, y * 16, 16, 16));
                    }



                }
            }

            return map;
        }

        private static int GetBGFromMap(Point p, int[,] data, int fg)
        {
            if (data[p.X + 1, p.Y] < fg)
            {
                return data[p.X + 1, p.Y];
            }
            if (data[p.X - 1, p.Y] < fg)
            {
                return data[p.X - 1, p.Y];
            }
            if (data[p.X, p.Y + 1] < fg)
            {
                return data[p.X, p.Y + 1];
            }
            if (data[p.X + 1, p.Y + 1] < fg)
            {
                return data[p.X + 1, p.Y + 1];
            }
            if (data[p.X - 1, p.Y + 1] < fg)
            {
                return data[p.X - 1, p.Y + 1];
            }
            if (data[p.X, p.Y - 1] < fg)
            {
                return data[p.X, p.Y - 1];
            }
            if (data[p.X + 1, p.Y - 1] < fg)
            {
                return data[p.X + 1, p.Y - 1];
            }
            if (data[p.X - 1, p.Y - 1] < fg)
            {
                return data[p.X - 1, p.Y - 1];
            }

            return fg;
        }

        private static int GetIdFromKnownMap(int y, int x)
        {
            ++x;
            ++y;
            var map = new int[][]
            {
                new int[] {5,1,7},
                new int[] {8,0,2},
                new int[] {10,4,11}
            };

            var id = map[x][y];

            return id;
        }

        public static Rectangle[][][] GetTileSetFromFile(string filename)
        {
            //too lazy, gonna hardcode till I get some more assets

            //var rectangles = new Dictionary<int, Rectangle>();
            //var completeFileText = File.ReadAllText(filename);

            //foreach (var entry in GetBetween(completeFileText, '[', ']'))
            //{
            //    var key = GetBetween(entry, '<', '>').First().ToInt();
            //    var rectangleToks = GetBetween(entry, '(', ')').First().Split(',');
            //    var value = new Rectangle(rectangleToks[0].ToInt(), rectangleToks[1].ToInt(), rectangleToks[2].ToInt(), rectangleToks[3].ToInt());

            //    rectangles.Add(key, value);
            //}

            //var maxId = rectangles.Keys.Max();
            //var rectangleList = new List<Rectangle>();

            //for (int i = 0; i < maxId; ++i)
            //{
            //    if (rectangles.ContainsKey(i))
            //    {
            //        rectangleList.Add(rectangles[i]);
            //    }
            //    else
            //    {
            //        rectangleList.Add(new Rectangle(0, 0, 1, 1));
            //    }
            //}

            var rectangles = new Rectangle[3][][];
            var tileSize = 16;

            //3x3 conversion, would work for any amount
            for (int backgroundIndex = 0; backgroundIndex < 3; ++backgroundIndex)
            {
                rectangles[backgroundIndex] = new Rectangle[3][];

                for (int foregroundIndex = 0; foregroundIndex < 3; ++foregroundIndex)
                {
                    rectangles[backgroundIndex][foregroundIndex] = new Rectangle[18];

                    var xOff = 5 * tileSize * foregroundIndex;
                    var yOff = 3 * tileSize * backgroundIndex;

                    //lol could have easily put this in a file ^_^ ... too late...
                    rectangles[backgroundIndex][foregroundIndex][0] = new Rectangle(xOff + tileSize * 1, yOff + tileSize * 1, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][1] = new Rectangle(xOff + tileSize * 1, yOff + tileSize * 0, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][2] = new Rectangle(xOff + tileSize * 2, yOff + tileSize * 1, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][3] = new Rectangle(xOff + tileSize * 2, yOff + tileSize * 0, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][4] = new Rectangle(xOff + tileSize * 1, yOff + tileSize * 2, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][5] = new Rectangle(xOff + tileSize * 4, yOff + tileSize * 1, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][6] = new Rectangle(xOff + tileSize * 2, yOff + tileSize * 2, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][9] = new Rectangle(xOff + tileSize * 0, yOff + tileSize * 0, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][8] = new Rectangle(xOff + tileSize * 0, yOff + tileSize * 1, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][7] = new Rectangle(xOff + tileSize * 3, yOff + tileSize * 1, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][10] = new Rectangle(xOff + tileSize * 4, yOff + tileSize * 0, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][11] = new Rectangle(xOff + tileSize * 3, yOff + tileSize * 0, tileSize, tileSize);
                    rectangles[backgroundIndex][foregroundIndex][12] = new Rectangle(xOff + tileSize * 0, yOff + tileSize * 2, tileSize, tileSize);



                    rectangles[backgroundIndex][foregroundIndex][16] = new Rectangle(xOff + tileSize * 4, yOff + tileSize * 2, tileSize, tileSize);


                    rectangles[backgroundIndex][foregroundIndex][17] = new Rectangle(xOff + tileSize * 3, yOff + tileSize * 2, tileSize, tileSize);

                    //80x48
                }
            }

            return rectangles;
        }

        private static Vector2 ToVector2(this string[] s)
        {
            return new Vector2(s[0].ToFloat(), s[1].ToFloat());
        }

        private static Point ToPoint(this string[] s)
        {
            return new Point(s[2].ToInt(), s[3].ToInt());
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
