using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class DigButtonController : MonoBehaviour
{
    [SerializeField]
    UIDocument uiDocument = default;

    [SerializeField]
    Mineable mineable = default;

    private Label oreText = default;
    private Button digButton = default;

    private void Awake()
    {
        VisualElement root = uiDocument.rootVisualElement;

        // demo
        root.Q<Button>("Upgrade1-Button").SetEnabled(false);

        oreText = root.Q<Label>("OreText");
        digButton = root.Q<Button>("DigButton");

        oreText.text = mineable.GetTotal().ToString();
    }

    private void OnEnable()
    {
        digButton.clicked += HandleDig;
        mineable.OnChange += HandleMineableChange;
    }

    private void OnDisable()
    {
        digButton.clicked -= HandleDig;
        mineable.OnChange -= HandleMineableChange;
    }

    private void HandleDig()
    {
        mineable.Increment();
    }

    private void HandleMineableChange(long current)
    {
        oreText.text = current.ToString();
    }
}
