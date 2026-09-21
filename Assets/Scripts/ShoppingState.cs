using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class ShoppingState : BaseState
    {
        private GameObject shop;

        public ShoppingState(MeshRenderer renderer, NavMeshAgent agent)
            : base(renderer, agent)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // Enter: The NPC decides to visit the village shop.
            Debug.Log("ShoppingState.Enter()");

            meshRenderer.material.color = Color.magenta;

            shop = GameObject.FindWithTag("Shop");

            if (shop != null)
            {
                agent.SetDestination(shop.transform.position);
                agent.isStopped = false;
            }
        }

        public override void Update()
        {
            base.Update();

            // Update: The NPC would browse the shop and purchase supplies.
            // More detailed shopping behaviour could be added here later.
        }

        public override void Exit()
        {
            // Exit: The NPC finishes shopping and leaves the store.
            Debug.Log("ShoppingState.Exit()");

            base.Exit();

            shop = null;
        }
    }
}