using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    public float rotateSpeed = 5;
    public float offY;

    public bool isAuto;
    private void Awake()
    {
        offY = 0;
    }

    void Update()
    {
        if (isAuto)
        {
            offY += Time.deltaTime * rotateSpeed;
            transform.eulerAngles = new Vector3(0,offY,0);
        }
    }
}
