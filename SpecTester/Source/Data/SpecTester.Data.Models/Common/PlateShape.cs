namespace SpecTester.Data.Models.Common
{
    using System;

    [Flags]
    public enum PlateShape
    {
        Round = 1,
        Square = 1 << 1,
        Rectangular = 1 << 2,
        Jug = 1 << 3,
    }
}
