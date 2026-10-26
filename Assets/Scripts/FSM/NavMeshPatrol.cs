using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Settings")]
    public float reachDistance = 0.3f;

    private NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("Missing NavMeshAgent!", this);
            enabled = false;
            return;
        }

        if (pointA == null || pointB == null)
        {
            Debug.LogError("Assign both patrol points!", this);
            enabled = false;
            return;
        }

        target = pointB;

        agent.SetDestination(target.position);
    }

    void Update()
    {
        if (agent.pathPending)
            return;

        if (!agent.hasPath)
            return;

        if (agent.remainingDistance <= reachDistance)
        {
            target = target == pointA ? pointB : pointA;

            agent.SetDestination(target.position);
        }
    }
}