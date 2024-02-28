using System;
using System.Collections;
using System.Collections.Generic;
using Ore.Data;
using UnityEngine;

namespace Ore.Controller
{
    public class PlanetController : MonoBehaviour
    {
        [SerializeField]
        private Planet planet = default;

        private void OnEnable()
        {
            planet.OnDepleted += HandlePlanetDepleted;
            planet.OnHealthChange += HandlePlanetOreChange;
        }

        private void Update()
        {
            planet.Regenerate(Time.deltaTime);
        }

        private void HandlePlanetDepleted()
        {
            Debug.Log($"{planet.displayName} depleted");
        }

        private void HandlePlanetOreChange(float currentHealth)
        {
            // Debug.Log($"{planet.displayName} ore change: {currentHealth}");
        }
    }
}
