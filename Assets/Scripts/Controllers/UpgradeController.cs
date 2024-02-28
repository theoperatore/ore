using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeController : MonoBehaviour
{
    // [SerializeField]
    // UIDocument uiDocument = default;

    // need some way to access the current allowed upgrades. some scriptable object?
    // private ScrollView list = default;

    private void Awake()
    {
        // VisualElement root = uiDocument.rootVisualElement;

        // list = root.Q<ScrollView>("UpgradeList");
        // var img = new ImageButton("test", imageTest, id => Debug.Log($"Clicked {id}"));
        // list.Add(img.GetElement());

        // in order to add an element, I'll need to make a class that represents the ImageButton
        // so I can add it to the list and listen to click handlers
    }
}
