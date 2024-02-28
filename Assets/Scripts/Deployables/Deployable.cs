using System;
using Ore.Attributes;
using UnityEngine;

namespace Ore.Deployables
{
    /// <summary>
    /// deployables provide added automation / incrementers of currencies
    /// must be Tick'ed by some controller
    /// ideas:
    ///   - deployables can stimulate planets to grow ore faster, increasing mining
    ///   - deployables have health and each tick will remove health until they "fail" and need to be deployed again
    ///   - deployables can rejuvinate the planet prompting ore or other currency to grow
    ///   - deployables can create other deployables
    /// </summary>
    [CreateAssetMenu(fileName = "Deployable", menuName = "Ore/Deployable")]
    public class Deployable : ScriptableObject, IIncrementor, IHealth
    {
        public string displayName = default;

        [TextArea(10, 20)]
        public string description = default;
        public Texture2D buttonImage = default;

        // this should maybe go in an implementing class
        [Header("Deployable configuration")]
        public Currency currencyToModify = default;
        public int baseCurrencyPerTick = 1;

        [SerializeField]
        private float maxHealth = 10.0f;
        private float currentHealth = 10.0f;

        [Header("Debug")]
        public DeployableState state = DeployableState.IDLE;

        public event Action<Deployable, DeployableState> OnStateChange;
        public event Action<float> OnHealthChange;

        public void Tick()
        {
            if (state == DeployableState.ACTIVE && currentHealth > 0)
            {
                currentHealth -= Time.deltaTime;
                // too expensive to call on every tick?
                OnHealthChange?.Invoke(currentHealth);
                currencyToModify.Increment(baseCurrencyPerTick);

                if (currentHealth <= 0)
                {
                    SetState(DeployableState.DESTROYED);
                }
            }
        }

        public void SetState(DeployableState newState)
        {
            state = newState;
            OnStateChange?.Invoke(this, state);
        }

        public float GetMaximumHealth()
        {
            return maxHealth;
        }

        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public float GetCurrentHealthPercentage()
        {
            return currentHealth / maxHealth;
        }
    }

    /// <summary>
    /// IDLE: Default state. unit is paused
    /// DEPLOYING: unit is enroute to target, not ticking yet
    /// ACTIVE: unit is ticking
    /// DEACTIVATED: unit has reached end of life and is no longer functional
    /// </summary>
    public enum DeployableState
    {
        IDLE,
        DEPLOYING,
        ACTIVE,
        DESTROYED
    }
}
