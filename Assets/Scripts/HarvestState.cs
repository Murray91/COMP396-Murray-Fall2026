using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class HarvestState : BaseState
    {
        private GameObject harvestArea;

        public HarvestState(MeshRenderer renderer, NavMeshAgent agent)
            : base(renderer, agent)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // Enter: The NPC begins harvesting resources for the village.
            Debug.Log("HarvestState.Enter()");

            meshRenderer.material.color = Color.cyan;

            harvestArea = GameObject.FindWithTag("HarvestArea");

            if (harvestArea != null)
            {
                agent.SetDestination(harvestArea.transform.position);
                agent.isStopped = false;
            }
        }

        public override void Update()
        {
            base.Update();

            // Update: The NPC travels toward the harvest area
            // and would collect resources once it arrives.
        }

        public override void Exit()
        {
            // Exit: The NPC finishes harvesting and leaves the resource area.
            Debug.Log("HarvestState.Exit()");

            base.Exit();

            harvestArea = null;
        }
    }
}
