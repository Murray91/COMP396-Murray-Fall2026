using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Core.FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCStateMachine : MonoBehaviour
    {
        StateMachine stateMachine;

        private void Awake()
        {
            // Creation of the StateMachine
            stateMachine = new StateMachine();

            MeshRenderer renderer = GetComponent<MeshRenderer>();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            // Find patrol points in the scene
            GameObject patrolPoint1 = GameObject.Find("PatrolPoint1");
            GameObject patrolPoint2 = GameObject.Find("PatrolPoint2");

            // Create instances for concrete states
            PatrolState patrol = new PatrolState(
                renderer,
                agent,
                new GameObject[] { patrolPoint1, patrolPoint2 }
            );

            HarvestState harvest = new HarvestState(renderer, agent);
            RestState rest = new RestState(renderer, agent);

            // New states added below RestState
            FishingState fishing = new FishingState(renderer, agent);
            ShoppingState shopping = new ShoppingState(renderer, agent);

            // Rest -> existing states
            stateMachine.AddTransition(
                rest,
                patrol,
                new FuncPredicate(() => Keyboard.current.pKey.wasPressedThisFrame)
            );

            stateMachine.AddTransition(
                rest,
                harvest,
                new FuncPredicate(() => Keyboard.current.hKey.wasPressedThisFrame)
            );

            // Rest -> new states
            stateMachine.AddTransition(
                rest,
                fishing,
                new FuncPredicate(() => Keyboard.current.fKey.wasPressedThisFrame)
            );

            stateMachine.AddTransition(
                rest,
                shopping,
                new FuncPredicate(() => Keyboard.current.sKey.wasPressedThisFrame)
            );

            // Existing states -> Rest
            stateMachine.AddTransition(
                patrol,
                rest,
                new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame)
            );

            stateMachine.AddTransition(
                harvest,
                rest,
                new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame)
            );

            // New states -> Rest
            stateMachine.AddTransition(
                fishing,
                rest,
                new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame)
            );

            stateMachine.AddTransition(
                shopping,
                rest,
                new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame)
            );

            // Start in RestState
            stateMachine.SetState(rest);
        }

        private void Update()
        {
            stateMachine.Update();
        }
    }
}