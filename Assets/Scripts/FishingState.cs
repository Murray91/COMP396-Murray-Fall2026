using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class FishingState : BaseState
    {
        private GameObject fishingSpot;

        public FishingState(MeshRenderer renderer, NavMeshAgent agent)
            : base(renderer, agent)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // Enter: The NPC becomes a fisherman and travels to the fishing spot.
            Debug.Log("FishingState.Enter()");

            meshRenderer.material.color = Color.blue;

            fishingSpot = GameObject.FindWithTag("FishingSpot");

            if (fishingSpot != null)
            {
                agent.SetDestination(fishingSpot.transform.position);
                agent.isStopped = false;
            }
        }

        public override void Update()
        {
            base.Update();

            // Update: The NPC would fish while staying at the fishing spot.
            // Additional fishing behaviour could be added here later.
        }

        public override void Exit()
        {
            // Exit: The NPC stops fishing and prepares for another activity.
            Debug.Log("FishingState.Exit()");

            base.Exit();

            fishingSpot = null;
        }
    }
}