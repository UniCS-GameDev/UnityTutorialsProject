using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private Stats currentStats;

    private void OnHealthUpdate(int damage)
    {
        healthSlider.value = currentStats != null ? currentStats.Health : 0;
    }

    public void SetupReferences(Stats playerStats)
    {
        currentStats = playerStats;
        healthSlider.maxValue = playerStats.MaxHealth;
        healthSlider.value = playerStats.Health;
        playerStats.DamageListener.AddListener(OnHealthUpdate);
    }

    public void TeardownReferences(Stats playerStats)
    {
        currentStats = null;
        playerStats.DamageListener.RemoveListener(OnHealthUpdate);
    }
}
