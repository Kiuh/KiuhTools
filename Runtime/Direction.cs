using System;
using System.Collections.Generic;
using UnityEngine;

namespace KiuhTools
{
    public enum Direction
    {
        Up = 0,
        RightUp = 1,
        Right = 2,
        RightDown = 3,
        Down = 4,
        LeftDown = 5,
        Left = 6,
        LeftUp = 7,
        Center = 8,
    }

    public static class DirectionTools
    {
        public static Direction ToDirection(this Vector2Int vec)
        {
            return (vec.x, vec.y) switch
            {
                (0, 1) => Direction.Up,
                (1, 1) => Direction.RightUp,
                (1, 0) => Direction.Right,
                (1, -1) => Direction.RightDown,
                (0, -1) => Direction.Down,
                (-1, -1) => Direction.LeftDown,
                (-1, 0) => Direction.Left,
                (-1, 1) => Direction.LeftUp,
                (0, 0) => Direction.Center,
                _ => throw new ArgumentException("Invalid input vector.")
            };
        }

        public static Vector2Int ToVector2Int(this Direction dir)
        {
            return dir switch
            {
                Direction.Up => new Vector2Int(0, 1),
                Direction.RightUp => new Vector2Int(1, 1),
                Direction.Right => new Vector2Int(1, 0),
                Direction.RightDown => new Vector2Int(1, -1),
                Direction.Down => new Vector2Int(0, -1),
                Direction.LeftDown => new Vector2Int(-1, -1),
                Direction.Left => new Vector2Int(-1, 0),
                Direction.LeftUp => new Vector2Int(-1, 1),
                Direction.Center => new Vector2Int(0, 0),
                _ => throw new ArgumentException("Invalid input Direction.")
            };
        }

        public static Direction Rotate90(this Direction dir)
        {
            return (Direction)(((int)dir + 2) % 8);
        }

        public static Direction RotateMinus90(this Direction dir)
        {
            int buffer = (int)dir - 2;
            return (Direction)(buffer < 0 ? 8 + buffer : buffer);
        }

        public static Direction Rotate45(this Direction dir)
        {
            return (Direction)(((int)dir + 1) % 8);
        }

        public static Direction RotateMinus45(this Direction dir)
        {
            int buffer = (int)dir - 1;
            return (Direction)(buffer < 0 ? 8 - buffer : buffer);
        }

        public static Direction GetOpposite(this Direction dir)
        {
            return (Direction)(((int)dir + 4) % 8);
        }

        public static float GetDegrees(this Direction dir)
        {
            return (int)dir * 45;
        }

        public static IEnumerable<Direction> GetCircle90(this Direction dir)
        {
            List<Direction> list = new();
            for (int i = 0; i < 4; i++)
            {
                list.Add(dir);
                dir = dir.Rotate90();
            }
            return list;
        }

        public static IEnumerable<Direction> GetCircle45(this Direction dir)
        {
            List<Direction> list = new();
            for (int i = 0; i < 8; i++)
            {
                list.Add(dir);
                dir = dir.Rotate45();
            }
            return list;
        }
    }
}
