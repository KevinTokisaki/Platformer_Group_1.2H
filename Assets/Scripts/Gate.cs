using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private bool open = false;
    private Vector3 initialPosition;
    private int moveDistance = 6;

    void Start(){
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other){
        int numKeys = GameCtrl.instance.GetKeys(); 
        if (other.tag == "Player"){
            if (numKeys > 0){
                open = true;
                GameCtrl.instance.SetKeys(-1); 
            }
        }
    }

    private void Update(){
        if (open){
            transform.parent.position += Vector3.up * 3 * Time.deltaTime;
            if (Vector3.Distance(transform.parent.position, initialPosition) > moveDistance)
                {
                    open = false;
                }
        }
    }

}
