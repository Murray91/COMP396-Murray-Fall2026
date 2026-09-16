using UnityEngine;
using System.Collections.Generic;

public class Vectors : MonoBehaviour
{
    [SerializeField] private Transform _player, _enemy;
    [SerializeField] private Vector3 _v1, _v2, _v3;
    [SerializeField] private float _k; // _ prefix
    [SerializeField] private Dictionary<int, Vector3> _matrix = new Dictionary<int, Vector3>();

    public float k; // camelCase
    public static float s_k = 0f; // s_ initial -> Every start, increase by 0.1f
    public const float K = 3.4f; // CAPITAL CASE

    private void Start()
    {
        // ---------------------------------------------------------
        // INITIAL VECTOR VALUES
        // ---------------------------------------------------------

        _v1 = _player.position;
        _v2 = _enemy.position;
        _v3 = new Vector3(2, 4, -8);

        _k = 1.5f;
        k = 1.5f;
        s_k += 0.1f;

        print($"Initial Values => v1 = {_v1}, v2 = {_v2}, v3 = {_v3}, _k = {_k}, k = {k}, s_k = {s_k}");

        // ---------------------------------------------------------
        // VECTOR DICTIONARY / MATRIX
        // ---------------------------------------------------------

        _matrix.Add(0, _player.position);
        _matrix.Add(1, _enemy.position);

        print($"Matrix[0] = {_matrix[0]}");
        print($"Matrix[1] = {_matrix[1]}");

        // ---------------------------------------------------------
        // ORIGINAL DOT PRODUCT
        // ---------------------------------------------------------

        float dot = Vector3.Dot(_v1, _v1 - _v2);
        print($"Dot Value from Player and Enemy = {dot}");

        // ---------------------------------------------------------
        // VECTOR MULTIPLICATION
        // ---------------------------------------------------------

        // Component-by-component multiplication
        var v1_times_v2 = new Vector3(
            _v1.x * _v2.x,
            _v1.y * _v2.y,
            _v1.z * _v2.z
        );

        // Vector multiplied by a scalar
        var v1_times_k = _v1 * k;

        // ---------------------------------------------------------
        // VECTOR ADDITION / SUBTRACTION
        // ---------------------------------------------------------

        var v1_plus_v2 = _v1 + _v2;
        var v1_minus_v2 = _v1 - _v2;

        print($"v1_times_v2 = {v1_times_v2}");
        print($"v1_times_k = {v1_times_k}");
        print($"v1_plus_v2 = {v1_plus_v2}");
        print($"v1_minus_v2 = {v1_minus_v2}");

        // ---------------------------------------------------------
        // NORMALIZE
        // ---------------------------------------------------------

        Vector3 normalizedV1 = _v1.normalized;

        print($"Normalized V1 = {normalizedV1}");

        // ---------------------------------------------------------
        // MAGNITUDE
        // ---------------------------------------------------------

        float magnitudeV1 = _v1.magnitude;

        print($"Magnitude V1 = {magnitudeV1}");

        // ---------------------------------------------------------
        // SQUARED MAGNITUDE
        // ---------------------------------------------------------

        float sqrMagnitudeV1 = _v1.sqrMagnitude;

        print($"SqrMagnitude V1 = {sqrMagnitudeV1}");

        // ---------------------------------------------------------
        // CROSS PRODUCT
        // ---------------------------------------------------------

        Vector3 crossProduct = Vector3.Cross(_v1, _v2);

        print($"Cross Product V1 x V2 = {crossProduct}");

        // ---------------------------------------------------------
        // DOT PRODUCT
        // ---------------------------------------------------------

        float dotProduct = Vector3.Dot(_v1, _v2);

        print($"Dot Product V1 · V2 = {dotProduct}");

        // ---------------------------------------------------------
        // DISTANCE
        // ---------------------------------------------------------

        float distance = Vector3.Distance(_v1, _v2);

        print($"Distance Between V1 and V2 = {distance}");
    }

    private void OnDisable()
    {
        s_k = 0f; // Resetting Static Variables
    }
}

