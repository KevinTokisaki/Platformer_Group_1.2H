using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivate : MonoBehaviour
{
    // Script for platforms that are activated on player contact

    public enum PlatformType
    {
        Disable, // set to not use script
        Disappearing, // Sink very quickly
        Sinking, // Sink slowly
        Floating, // Sink upwards
        Linear, // Straight line and back
    }

    [SerializeField] private PlatformType platformType; // Set this in the editor
    [SerializeField] private float activationDelay = 0.5f;
    private Vector3 initialPosition;
    private bool resetting = false;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveDistance = 5f;
    private bool sinking = false;
    private bool linear = false;


    void Start(){
        initialPosition = transform.position;
    }

    public void Activate()
    {

        switch(platformType)
        {
            case PlatformType.Disappearing:
                moveSpeed = 4f;
                Invoke("Sink", activationDelay);
                break;

            case PlatformType.Sinking:
                moveSpeed = 1f;
                Invoke("Sink", activationDelay);
                break;

            case PlatformType.Floating:
                moveSpeed = -1f;
                Invoke("Sink", activationDelay);
                break;

            case PlatformType.Linear:
                Invoke("Linear", activationDelay);
                break;
                

            case PlatformType.Disable:
                break;
        }
    }

    private void Update()
    {
        if (sinking)
        {
            Sink();
        }
        if (resetting){
            ResetPlatform();
        }
        if(linear){
            Linear();
        }
    }

    void ResetPlatform(){
        resetting = true;
        transform.position += Vector3.down * -moveSpeed * Time.deltaTime;
        
        if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
        {
            resetting = false;
        }
    }

    void Sink(){
        sinking = true;
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, initialPosition) > moveDistance)
        {
            sinking = false;
            Invoke("ResetPlatform", activationDelay);
        }
    }

    void Linear(){
        linear = true;
        // blue arrow in editor
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, initialPosition) > moveDistance)
        {
            moveSpeed = -moveSpeed;
        }

    }
}
