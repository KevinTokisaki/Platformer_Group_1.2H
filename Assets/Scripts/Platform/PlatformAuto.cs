using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAuto : MonoBehaviour
{
    // For platforms activated automatically
    public enum MovingType
    {
        Disable,
        LinearX, // straight line movement
        Rotate, // rotate around centre
        LinearY,
    }

    [SerializeField] private MovingType movingType;
    private Vector3 initialPosition;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    void Start(){
        initialPosition = transform.parent.position;
    }

    private void Update()
    {
        switch(movingType)
        {
            case MovingType.LinearX:
                // blue arrow in editor
                transform.parent.position += transform.parent.forward * moveSpeed * Time.deltaTime;
                if (Vector3.Distance(transform.parent.position, initialPosition) > moveDistance)
                {
                    moveSpeed = -moveSpeed;
                }
                break;

            case MovingType.Rotate:
                // spins anticlockwise
                transform.parent.position += transform.parent.right * moveSpeed * Time.deltaTime;
                transform.parent.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
                break;

            case MovingType.LinearY:
                transform.parent.position += Vector3.down * moveSpeed * Time.deltaTime;

                if (Vector3.Distance(transform.parent.position, initialPosition) > moveDistance)
                {
                    moveSpeed = -moveSpeed;
                }
                break;

            case MovingType.Disable:
                break;
        }

    }
}
