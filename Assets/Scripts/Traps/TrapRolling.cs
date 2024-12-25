using UnityEngine;
using System.Collections;

public class RollingTrap : MonoBehaviour
{
    public float speed = 5f;          // �����ٶ�
    public float maxDistance = 10f;  // ����������
    public float resetDelay = 1f;    // �ﵽ����������õ��ӳ�ʱ��

    private Vector3 startPos;        // ��ʼλ��
    private bool isResetting = false; // ��ֹ�ظ�����

    void Start()
    {
        startPos = transform.position; // ��¼��ʼλ��
    }

    void Update()
    {
        if (!isResetting)
        {
            // �����߼�
            transform.position += transform.right * speed * Time.deltaTime;

            // ������������룬��������Э��
            if (Vector3.Distance(transform.position, startPos) >= maxDistance)
            {
                StartCoroutine(ResetPosition());
            }
        }
    }

    private IEnumerator ResetPosition()
    {
        isResetting = true; // �����������

        // �ȴ�ָ�����ӳ�ʱ��
        yield return new WaitForSeconds(resetDelay);

        // ����λ��
        transform.position = startPos;

        isResetting = false; // ������ɣ������������
    }
}
