using System;
using UnityEngine;

namespace KiuhTools.Direction9
{
    public static class Transforms
    {
        public static Direction9 ToDirection(this Vector2Int vec)
        {
            return (vec.x, vec.y) switch
            {
                (0, 1) => Direction9.Up,
                (1, 1) => Direction9.RightUp,
                (1, 0) => Direction9.Right,
                (1, -1) => Direction9.RightDown,
                (0, -1) => Direction9.Down,
                (-1, -1) => Direction9.LeftDown,
                (-1, 0) => Direction9.Left,
                (-1, 1) => Direction9.LeftUp,
                (0, 0) => Direction9.Center,
                _ => throw new ArgumentException("Invalid input vector.")
            };
        }

        public static Vector2Int ToVector2Int(this Direction9 dir)
        {
            return dir switch
            {
                Direction9.Up => new Vector2Int(0, 1),
                Direction9.RightUp => new Vector2Int(1, 1),
                Direction9.Right => new Vector2Int(1, 0),
                Direction9.RightDown => new Vector2Int(1, -1),
                Direction9.Down => new Vector2Int(0, -1),
                Direction9.LeftDown => new Vector2Int(-1, -1),
                Direction9.Left => new Vector2Int(-1, 0),
                Direction9.LeftUp => new Vector2Int(-1, 1),
                Direction9.Center => new Vector2Int(0, 0),
                _ => throw new ArgumentException("Invalid input Direction.")
            };
        }
    }
}
