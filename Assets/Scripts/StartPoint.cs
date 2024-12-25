using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        if (player != null)
        {
            // ����ҵ�λ������Ϊ StartPoint ��λ��
            player.transform.position = transform.position + new Vector3(1f, 0f, 0f); ;

            // ������ҵĳ���Ϊ StartPoint ����ת
            player.transform.rotation = transform.rotation;


        }
    }
}
