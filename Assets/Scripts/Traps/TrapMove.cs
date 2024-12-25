using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    public enum MyEnum
    {
        X,
        Y,
        Z
    }
    public MyEnum myEnum;

    public float off;
    public float moveSpeed = 5;
    public float min, max;
    public bool isMoveRight, isMoveLeft;

    public bool auto;
    void Start()
    {
        switch (myEnum)
        {
            case MyEnum.X:
                off = transform.localPosition.x;
                break;
            case MyEnum.Y:
                off = transform.localPosition.y;
                break;
            case MyEnum.Z:  
                off = transform.localPosition.z;
                break;
            default:
                break;
        }
        isMoveRight = true;
    }

    void Update()
    {
        if (auto)
        {
            if (isMoveRight)
            {
                if (off < max)
                {
                    off += Time.deltaTime * moveSpeed;
                }
                else
                {
                    off = max;
                    isMoveRight = false;
                    isMoveLeft = true;
                }
            }

            if (isMoveLeft)
            {
                if (off > min)
                {
                    off -= Time.deltaTime * moveSpeed;
                }
                else
                {
                    off = min;
                    isMoveLeft = false;
                    isMoveRight = true;
                }
            }
           

            switch (myEnum)
            {
                case MyEnum.X:
                    transform.localPosition = new Vector3(off, transform.localPosition.y, transform.localPosition.z);
                    break;
                case MyEnum.Y:
                    transform.localPosition = new Vector3(transform.localPosition.x, off, transform.localPosition.z);
                    break;
                case MyEnum.Z:
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, off);
                    break;
                default:
                    break;
            }
        }
    }
}
