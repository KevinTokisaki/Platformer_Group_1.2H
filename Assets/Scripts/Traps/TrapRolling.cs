using UnityEngine;
using System.Collections;

public class RollingTrap : MonoBehaviour
{
    public float speed = 5f;          // Rolling speed
    public float maxDistance = 10f;  // Maximum rolling distance
    public float resetDelay = 1f;    // Delay time before resetting after reaching max distance

    private Vector3 startPos;        // Initial position
    private bool isResetting = false; // Prevents resetting multiple times

    void Start()
    {
        startPos = transform.position; // Record the initial position
    }

    void Update()
    {
        if (!isResetting)
        {
            // Rolling logic
            transform.position += transform.right * speed * Time.deltaTime;

            // If the maximum distance is exceeded, start the reset coroutine
            if (Vector3.Distance(transform.position, startPos) >= maxDistance)
            {
                StartCoroutine(ResetPosition());
            }
        }
    }

    private IEnumerator ResetPosition()
    {
        isResetting = true; // Mark that the trap is resetting

        // Wait for the specified delay time
        yield return new WaitForSeconds(resetDelay);

        // Reset position
        transform.position = startPos;

        isResetting = false; // Reset complete, allow rolling to continue
    }
}
