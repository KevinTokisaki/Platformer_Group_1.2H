using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    [SerializeField] private float force = 20;

    void Start(){
        GetComponent<Rigidbody>().drag = 0.5f;
    }

    private void OnTriggerStay(Collider other){
        if (other.tag == "Sea"){
            GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Force);
        }
    }
}
