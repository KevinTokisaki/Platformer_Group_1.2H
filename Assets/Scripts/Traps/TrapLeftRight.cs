using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLeftRight : MonoBehaviour
{
    public float minAngle = -45;
    public float maxAngle = 45;
    public bool isMin, isMax;
    public float rotate;
    public float rotateSpeed = 10;
    public bool auto;
    void Start()
    {
        isMax = true;
        rotate = transform.eulerAngles.y;
    }

    void Update()
    {
        if (auto)
        {
            if (isMax)
            {
                if (rotate < maxAngle)
                {
                    rotate += Time.deltaTime * rotateSpeed;
                }
                else
                {
                    rotate = maxAngle;
                    isMax = false;
                    isMin = true;
                }
            }
            if (isMin)
            {
                if (rotate > minAngle)
                {
                    rotate -= Time.deltaTime * rotateSpeed;
                }
                else
                {
                    rotate = minAngle;
                    isMax = true;
                    isMin = false;
                }
            }
            transform.eulerAngles = new Vector3(rotate,90,0);
        }
    }
}
