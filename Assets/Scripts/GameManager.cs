using System.Collections;
using System.Collections.Generic;
using Ore.Data;
using Ore.Deployables;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Currency ore = default;

    [SerializeField]
    private Planet planet = default;

    [Header("Controllers")]
    [SerializeField]
    private UIController uiController;

    // list of upgrades available
    // list of deployables available

    // [Header("Debug")]
    // list of deployables active
    // [SerializeFied]
    // private List<Deployable> activeDeployables = default;

    // list of upgrades purchased
    // [SerializeField]
    // private Dictionary<Upgrade, int> upgradesPurchased = default;

    private void Start()
    {
        // set an initial value
        uiController.SetOreText(ore.GetTotal());
    }

    private void OnEnable()
    {
        uiController.OnDig += HandleDig;
        ore.OnChange += uiController.SetOreText;
    }

    private void OnDisable()
    {
        uiController.OnDig -= HandleDig;
        ore.OnChange -= uiController.SetOreText;
    }

    private void HandleDig()
    {
        // todo: calculate dig amount
        int amountDug = planet.Dig();
        ore.Increment(amountDug);
    }
}
