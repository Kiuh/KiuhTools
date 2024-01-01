using System.Collections.Generic;

namespace KiuhTools.Direction9
{
    public static class Extensions
    {
        public static Direction9 Rotate90(this Direction9 dir)
        {
            return (Direction9)(((int)dir + 2) % 8);
        }

        public static Direction9 RotateMinus90(this Direction9 dir)
        {
            int buffer = (int)dir - 2;
            return (Direction9)(buffer < 0 ? 8 + buffer : buffer);
        }

        public static Direction9 Rotate45(this Direction9 dir)
        {
            return (Direction9)(((int)dir + 1) % 8);
        }

        public static Direction9 RotateMinus45(this Direction9 dir)
        {
            int buffer = (int)dir - 1;
            return (Direction9)(buffer < 0 ? 8 - buffer : buffer);
        }

        public static Direction9 GetOpposite(this Direction9 dir)
        {
            return (Direction9)(((int)dir + 4) % 8);
        }

        public static float GetDegrees(this Direction9 dir)
        {
            return (int)dir * 45;
        }

        public static IEnumerable<Direction9> GetCircle90(this Direction9 dir)
        {
            List<Direction9> list = new();
            for (int i = 0; i < 4; i++)
            {
                list.Add(dir);
                dir = dir.Rotate90();
            }
            return list;
        }

        public static IEnumerable<Direction9> GetCircle45(this Direction9 dir)
        {
            List<Direction9> list = new();
            for (int i = 0; i < 8; i++)
            {
                list.Add(dir);
                dir = dir.Rotate45();
            }
            return list;
        }
    }
}
