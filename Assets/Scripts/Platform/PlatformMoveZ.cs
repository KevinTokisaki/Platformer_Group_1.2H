using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveZ : MonoBehaviour
{
    public float offZ; // 原来是 offX，现在改为 offZ
    public float moveSpeed = 5;
    public float min, max;
    public float moveDir = 1;
    public bool isMoveForward, isMoveBackward; // 改为控制前后移动的变量

    public bool auto;

    void Start()
    {
        offZ = transform.localPosition.z; // 初始化为 Z 轴的当前位置
        min = offZ - moveDir; // 计算最小位置
        max = offZ + moveDir; // 计算最大位置
        isMoveForward = true; // 初始化为向前移动
    }

    void Update()
    {
        if (auto)
        {
            if (isMoveForward) // 向前移动逻辑
            {
                if (offZ < max)
                {
                    offZ += Time.deltaTime * moveSpeed;
                }
                else
                {
                    offZ = max;
                    isMoveForward = false;
                    isMoveBackward = true;
                }
            }

            if (isMoveBackward) // 向后移动逻辑
            {
                if (offZ > min)
                {
                    offZ -= Time.deltaTime * moveSpeed;
                }
                else
                {
                    offZ = min;
                    isMoveBackward = false;
                    isMoveForward = true;
                }
            }

            // 将 Z 轴的位置更新
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, offZ);
        }
    }
}
