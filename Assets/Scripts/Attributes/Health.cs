using System;

namespace Ore.Attributes
{
    // if there ever comes a time when something should share health, then turn this into a scriptable object
    interface IHealth
    {
        float GetMaximumHealth();

        float GetCurrentHealth();

        float GetCurrentHealthPercentage();

        event Action<float> OnHealthChange;
    }
}
