using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "Ore/Currency")]
public class Currency : ScriptableObject
{
    public string currencyName = "Ore";

    [TextArea(10, 20)]
    public string description = "Something basic that anything can be made from. Valueable to all.";

    [SerializeField]
    private long total = 0;

    /// <summary>
    /// Invoked whenever the total changes. Provides the current total for each callback
    /// </summary>
    public event Action<long> OnChange;

    /// <summary>
    /// Returns the current total of the currency.
    /// </summary>
    /// <returns>the total count</returns>
    public long GetTotal()
    {
        return total;
    }

    /// <summary>
    /// Increment the currency total by the amount.
    /// </summary>
    /// <param name="amount">The amount to increment. Defaults to 1</param>
    public void Increment(int amount = 1)
    {
        total += amount;
        OnChange?.Invoke(total);
    }

    /// <summary>
    /// ensures the amount of the currency never dips negative
    /// </summary>
    /// <param name="amount">The amount of decrement. Defaults to 1</param>
    public void Decrement(int amount = 1)
    {
        total = Math.Max(0, total - amount);
        OnChange?.Invoke(total);
    }
}
