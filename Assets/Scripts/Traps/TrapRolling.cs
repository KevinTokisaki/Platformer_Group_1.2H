using UnityEngine;
using System.Collections;

public class RollingTrap : MonoBehaviour
{
    public float speed = 5f;          // 滚动速度
    public float maxDistance = 10f;  // 最大滚动距离
    public float resetDelay = 1f;    // 达到最大距离后重置的延迟时间

    private Vector3 startPos;        // 初始位置
    private bool isResetting = false; // 防止重复重置

    void Start()
    {
        startPos = transform.position; // 记录初始位置
    }

    void Update()
    {
        if (!isResetting)
        {
            // 滚动逻辑
            transform.position += transform.right * speed * Time.deltaTime;

            // 如果超出最大距离，启动重置协程
            if (Vector3.Distance(transform.position, startPos) >= maxDistance)
            {
                StartCoroutine(ResetPosition());
            }
        }
    }

    private IEnumerator ResetPosition()
    {
        isResetting = true; // 标记正在重置

        // 等待指定的延迟时间
        yield return new WaitForSeconds(resetDelay);

        // 重置位置
        transform.position = startPos;

        isResetting = false; // 重置完成，允许继续滚动
    }
}
