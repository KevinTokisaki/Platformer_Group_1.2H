using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveZ : MonoBehaviour
{
    public float offZ; 
    public float moveSpeed = 5;
    public float min, max;
    public float moveDir = 1;
    public bool isMoveForward, isMoveBackward; // Variables to control forward and backward movement

    public bool auto;

    void Start()
    {
        offZ = transform.localPosition.z; // Initialize the current Z position
        min = offZ - moveDir; 
        max = offZ + moveDir; 
        isMoveForward = true; // Initialize to move forward
    }

    void Update()
    {
        if (auto)
        {
            if (isMoveForward) // Forward movement logic
            {
                if (offZ < max)
                {
                    offZ += Time.deltaTime * moveSpeed;
                }
                else
                {
                    offZ = max;
                    isMoveForward = false;
                    isMoveBackward = true;
                }
            }

            if (isMoveBackward) // Backward movement logic
            {
                if (offZ > min)
                {
                    offZ -= Time.deltaTime * moveSpeed;
                }
                else
                {
                    offZ = min;
                    isMoveBackward = false;
                    isMoveForward = true;
                }
            }

            // Update the Z position
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, offZ);
        }
    }
}
