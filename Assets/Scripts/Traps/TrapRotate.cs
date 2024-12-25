using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotate : MonoBehaviour
{
    public enum MyEnum
    {
        X,
        Y,
        Z
    }
    public MyEnum myEnum;
    
    public float rotateSpeed = 5;
    public float offRotate;

    public bool isAuto;
    private void Awake()
    {
        offRotate = 0;
    }

    void Update()
    {
        if (isAuto)
        {
            offRotate += Time.deltaTime * rotateSpeed;

            switch (myEnum)
            {
                case MyEnum.X:
                    transform.eulerAngles = new Vector3(offRotate, 0, 0);
                    break;
                case MyEnum.Y:
                    transform.eulerAngles = new Vector3(0, offRotate, 0);
                    break;
                case MyEnum.Z:
                    transform.eulerAngles = new Vector3(0, 0, offRotate);
                    break;
                default:
                    break;
            }
           
        }
    }
}
