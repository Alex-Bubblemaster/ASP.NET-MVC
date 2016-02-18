namespace SpecTester.Data.Models.Common
{
    using System;

    [Flags]
    public enum CookingMethod
    {
        Boil = 1,
        Steam = 1 << 1,
        DeepFry = 1 << 2,
        ShallowFry = 1 << 3,
        Grill = 1 << 4,
        Roast = 1 << 5,
        ReadyToEat = 1 << 6
    }
}
