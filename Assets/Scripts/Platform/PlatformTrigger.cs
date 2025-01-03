using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    // Collider to activate platforms
    public PlatformActivate platform;

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Debug.Log("TRIGGER");
            platform.Activate();
        }
    }
}