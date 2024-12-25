using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float offX;
    public float moveSpeed = 5;
    public float min, max;
    public float moveDir = 1;
    public bool isMoveRight,isMoveLeft;

    public bool auto;
    void Start()
    {
        offX = transform.localPosition.x;
        min = offX - moveDir;
        max = offX + moveDir;
        isMoveRight = true;
    }

    void Update()
    {
        if (auto)
        {
            if (isMoveRight)
            {
                if (offX < max)
                {
                    offX += Time.deltaTime * moveSpeed;
                }
                else
                {
                    offX = max;
                    isMoveRight = false;
                    isMoveLeft = true;
                }
            }

            if (isMoveLeft)
            {
                if (offX > min)
                {
                    offX -= Time.deltaTime * moveSpeed;
                }
                else
                {
                    offX = min;
                    isMoveLeft = false;
                    isMoveRight = true;
                }
            }
            transform.localPosition = new Vector3(offX, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
