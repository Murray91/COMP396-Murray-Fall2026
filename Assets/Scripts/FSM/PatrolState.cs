using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class PatrolState : BaseState
    {
        private GameObject[] patrolPoints;
        private int currentPoint;

        public PatrolState(
            MeshRenderer renderer,
            NavMeshAgent agent,
            GameObject[] patrolPoints)
            : base(renderer, agent)
        {
            this.patrolPoints = patrolPoints;
            currentPoint = 0;
        }

        public override void Enter()
        {
            base.Enter();

            // Enter: The NPC begins patrolling around the village.
            Debug.Log("PatrolState.Enter()");

            meshRenderer.material.color = Color.yellow;

            if (patrolPoints != null && patrolPoints.Length > 0)
            {
                GoToNextPatrolPoint();
            }
        }

        public override void Update()
        {
            base.Update();

            // Update: The NPC moves between patrol points.
            // When it reaches a patrol point, it moves toward the next one.

            if (patrolPoints == null || patrolPoints.Length == 0)
            {
                return;
            }

            if (!agent.pathPending &&
                agent.remainingDistance <= agent.stoppingDistance)
            {
                GoToNextPatrolPoint();
            }
        }

        public override void Exit()
        {
            // Exit: The NPC stops patrolling and prepares for another activity.
            Debug.Log("PatrolState.Exit()");

            base.Exit();
        }

        private void GoToNextPatrolPoint()
        {
            if (patrolPoints[currentPoint] != null)
            {
                agent.isStopped = false;

                agent.SetDestination(
                    patrolPoints[currentPoint].transform.position
                );
            }

            currentPoint++;

            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }
    }
}