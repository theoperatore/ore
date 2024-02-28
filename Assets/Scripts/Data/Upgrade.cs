using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Ore/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string displayName = default;

    [TextArea(10, 20)]
    public string description = default;

    public Texture2D image = default;
}
