using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Hitbox : MonoBehaviour
{
    public GameObject Parent { get; set; }
    public int Damage { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        Stats enemyStats = other.GetComponent<Stats>();

        if (CompareTag(other.tag) || enemyStats == null) return;

        enemyStats.DamageListener.Invoke(Damage);
    }
}
