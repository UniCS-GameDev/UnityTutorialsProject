using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent enemyNavMeshAgent;
    private bool isPaused = false;
    private float stoppingDistance;

    public float StoppingDistance
    {
        private get
        {
            return stoppingDistance;
        }

        set
        {
            stoppingDistance = value;
            enemyNavMeshAgent.stoppingDistance = value;
        }
    }

    public Transform Target { private get; set; }


    private void Awake()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (Target == null)
        {
            return;
        }

        if (Vector3.Distance(transform.position, Target.position) < StoppingDistance)
        {
            // face the target
            Vector3 direction = (Target.position - transform.position).normalized;
            direction.y = 0; // dont look upwards if the target is jumping or above the enemy
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime);

            if (!isPaused)
            {
                ReachedTarget?.Invoke(transform.position, Resume);
                isPaused = true;
            }
        }
        else
        {
            enemyNavMeshAgent.destination = Target.position;
        }
    }

    private void Resume()
    {
        isPaused = false;
    }


    public event Action<Vector3, Action> ReachedTarget;
}
