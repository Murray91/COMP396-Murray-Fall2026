using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class RestState : BaseState
    {
        public RestState(MeshRenderer renderer, NavMeshAgent agent)
            : base(renderer, agent)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // Enter: The NPC stops working and takes a break in the village.
            Debug.Log("RestState.Enter()");

            meshRenderer.material.color = Color.green;

            agent.isStopped = true;
        }

        public override void Update()
        {
            base.Update();

            // Update: The NPC remains still while resting.
            // The StateMachine checks for a key press to begin another activity.
        }

        public override void Exit()
        {
            // Exit: The NPC finishes resting and prepares to begin a new activity.
            Debug.Log("RestState.Exit()");

            base.Exit();

            agent.isStopped = false;
        }
    }
}