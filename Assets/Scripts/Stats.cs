using System;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField] private int baseHealth, baseArmour, baseExperience;
    
    public int MaxHealth { get { return baseHealth; } }
    public int MaxArmour { get { return baseArmour; } }
    public int Health { get; private set; }
    public int Armour { get; private set; }
    public int Experience { get; private set; }

    [Serializable]
    public class DamageEvent : UnityEvent<int> { }
    public DamageEvent DamageListener;

    private void Awake()
    {
        Health = baseHealth;
        Armour = baseArmour;
        Experience = baseExperience;
    }

    private void Start()
    {
        if (DamageListener == null) DamageListener = new DamageEvent();
        DamageListener.AddListener(OnTakeDamage);
    }

    private void OnTakeDamage(int rawDamage)
    {
        int damage = Armour > rawDamage ? 0 : (rawDamage - Armour);

        //Debug.Log($"Dealing {damage} to {gameObject.name} | Health: {Health - damage}");

        Health -= damage;
    }
}
