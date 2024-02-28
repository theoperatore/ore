using System;
using Ore.Attributes;
using UnityEngine;

namespace Ore.Data
{
    [CreateAssetMenu(fileName = "Planet", menuName = "Ore/Planet")]
    public class Planet : ScriptableObject, IHealth
    {
        public string displayName = default;

        [TextArea(10, 20)]
        public string description = default;

        [Tooltip("Amount of ore naturally ocurring on this planet without any intervention")]
        public float startingOre = 100;

        [SerializeField]
        [Tooltip("Should be initialized to starting ore")]
        private float currentOre = 100;

        [Tooltip(
            "The rate (in seconds) at which this planet naturally regenerates ore. e.g. 0.1 means regenerate 1/10th of a single ore every second or 1 ore every 10 seconds."
        )]
        public float regenerationRate = 0.1f;

        public event Action<float> OnHealthChange;
        public event Action OnDepleted;

        private float regenerationCount = 0.0f;

        public float GetCurrentHealth()
        {
            return currentOre;
        }

        public float GetCurrentHealthPercentage()
        {
            return currentOre / startingOre;
        }

        public float GetMaximumHealth()
        {
            return startingOre;
        }

        // call this function on every tick to regenerate some ore
        public void Regenerate(float deltaTime)
        {
            regenerationCount += deltaTime;

            if (regenerationCount >= 1)
            {
                var prevOre = currentOre;
                // don't naturally regen more than starting ore
                currentOre = Mathf.Min(startingOre, currentOre + regenerationRate);
                if (prevOre != currentOre)
                {
                    OnHealthChange?.Invoke(currentOre);
                }

                regenerationCount = 0.0f;
            }
        }

        public int Dig(float amount = 1.0f)
        {
            int amountDug = Mathf.FloorToInt(MathF.Min(currentOre, amount));
            currentOre -= amountDug;
            currentOre = Mathf.Max(0, currentOre);
            OnHealthChange?.Invoke(currentOre);

            if (currentOre < 1)
            {
                OnDepleted?.Invoke();
            }

            return amountDug;
        }
    }
}
