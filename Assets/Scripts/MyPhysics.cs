using UnityEngine;
using UnityEngine.InputSystem;

public class MyPhysics : MonoBehaviour
{
    [SerializeField] private GameObject _canonBallPrefab;
    [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;
    [SerializeField] private Vector3 _force = new Vector3(0f, 15f, 25f);

    private Rigidbody _canonBody;

    void Start()
    {
        SpawnCanonBall();
    }

    private void Update()
    {
        // Left mouse button launches the cannonball
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            LaunchCanonBall();
        }

        // R resets the cannonball
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetCanonBall();
        }
    }

    private void SpawnCanonBall()
    {
        _canonBody = Instantiate(_canonBallPrefab, transform)
            .GetComponent<Rigidbody>();

        Debug.Log(
            $"Cannonball spawned. Force = {_force}, ForceMode = {_forceMode}"
        );
    }

    private void LaunchCanonBall()
    {
        _canonBody.AddForce(_force, _forceMode);

        Debug.Log(
            $"Cannonball launched! Force = {_force}, ForceMode = {_forceMode}"
        );
    }

    private void ResetCanonBall()
    {
        Destroy(_canonBody.gameObject);

        SpawnCanonBall();

        Debug.Log("Cannonball reset.");
    }
}

