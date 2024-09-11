using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Space]
    [Header("Forward Movement")]
    [Range(0.0f, 1.0f)]
    [SerializeField] private float speedIncrementation = 1.0f;
    [SerializeField] private float progressiveSpeedMultiplier = 1.0f;
    [SerializeField] private float slowDownFactor = 1.0f;
    
    private float _speedMultiplier = 1.0f;

    void Update()
    {
        _speedMultiplier += Time.deltaTime / speedIncrementation;
        _speedMultiplier = Mathf.Clamp(_speedMultiplier, 3, 5);

        transform.position += Time.deltaTime * 4 * _speedMultiplier * new Vector3(1, 0, 0) / slowDownFactor * progressiveSpeedMultiplier;
    }
}
