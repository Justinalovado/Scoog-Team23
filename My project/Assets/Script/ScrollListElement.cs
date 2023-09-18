using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScrollListElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 initialPosition;
    private Vector3 dragStartPosition;
    private bool isDragging = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        dragStartPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 根据鼠标或触摸输入来移动图片
        transform.position = dragStartPosition + (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        // 计算拉动的幅度
        float dragDistance = Vector3.Distance(transform.position, initialPosition);

        // 如果拉动的幅度大于等于某个阈值，执行场景转换
        if (dragDistance >= 50.0f) // 调整阈值为您需要的值
        {
            SceneManager.LoadScene("YourNextSceneName");
        }
        else
        {
            // 否则，平滑地将图片回到初始位置
            StartCoroutine(MoveToInitialPosition());
        }
    }

    private IEnumerator MoveToInitialPosition()
    {
        float duration = 0.5f; // 移动到初始位置的时间
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition; // 确保最终位置精确
    }
}
