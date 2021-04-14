using System;
using System.Collections;
using UnityEngine;

public class EnemyBehaviourMelee : EnemyBehaviourBase
{
    [SerializeField] private int damage;
    [SerializeField] private Hitbox hitbox;

    private IEnumerator AttackCoroutine(Action resumeTrackingCallback)
    {
        hitbox.Parent = gameObject;
        hitbox.Damage = damage;

        hitbox.gameObject.SetActive(true);
        yield return new WaitForSeconds(AttackCooldown);
        hitbox.gameObject.SetActive(false);

        resumeTrackingCallback();
    }

    protected override void OnReachedTarget(Vector3 position, Action resumeTrackingCallback)
    {
        StartCoroutine(AttackCoroutine(resumeTrackingCallback));
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TrackedGameObject == null)
        {
            TrackedGameObject = other.gameObject;
            MovementController.Target = other.transform;
        }

        base.OnTriggerEnter(other);
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.gameObject == TrackedGameObject)
        {
            TrackedGameObject = null;
            MovementController.Target = null;
        }

        base.OnTriggerExit(other);
    }
}
