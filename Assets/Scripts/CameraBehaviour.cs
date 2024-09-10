using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Space]
    [Header("Forward Movement")]
    [SerializeField] private float speedMultiplier = 1.0f;
    [SerializeField] private float speedIncrementation = 1.0f;
    [SerializeField] private float progressiveSpeedMultiplier = 1.0f;
    [SerializeField] private float slowDownFactor = 1.0f;

    void Update()
    {
        speedMultiplier += Time.deltaTime / speedIncrementation;
        speedMultiplier = Mathf.Clamp(speedMultiplier, 3, 5);

        transform.position += Time.deltaTime * 4 * speedMultiplier * new Vector3(1, 0, 0) / slowDownFactor * progressiveSpeedMultiplier;
    }
}   
