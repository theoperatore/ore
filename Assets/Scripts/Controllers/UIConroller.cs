using System;
using Ore.Deployables;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField]
    UIDocument uiDocument = default;

    private Label oreText = default;
    private Button digButton = default;
    private VisualElement upgradeContainer = default;
    private VisualElement deployContainer = default;

    public event Action OnDig;

    // public event Action<Deployable> OnDeployable;
    // public event Action<Upgrade> OnUpgrade;

    private void Awake()
    {
        VisualElement root = uiDocument.rootVisualElement;

        oreText = root.Q<Label>("OreText");
        digButton = root.Q<Button>("DigButton");
        upgradeContainer = root.Q<VisualElement>("UpgradeListContainer");
        deployContainer = root.Q<VisualElement>("DeployableListContainer");

        // until there are values to put in here
        upgradeContainer.style.display = DisplayStyle.None;
        deployContainer.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        digButton.clicked += HandleDig;
    }

    private void OnDisable()
    {
        digButton.clicked -= HandleDig;
    }

    private void HandleDig()
    {
        OnDig?.Invoke();
    }

    public void SetOreText(long current)
    {
        oreText.text = current.ToString();
    }
}
