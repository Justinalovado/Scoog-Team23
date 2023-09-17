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
        // �����������������ƶ�ͼƬ
        transform.position = dragStartPosition + (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        // ���������ķ���
        float dragDistance = Vector3.Distance(transform.position, initialPosition);

        // ��������ķ��ȴ��ڵ���ĳ����ֵ��ִ�г���ת��
        if (dragDistance >= 50.0f) // ������ֵΪ����Ҫ��ֵ
        {
            SceneManager.LoadScene("YourNextSceneName");
        }
        else
        {
            // ����ƽ���ؽ�ͼƬ�ص���ʼλ��
            StartCoroutine(MoveToInitialPosition());
        }
    }

    private IEnumerator MoveToInitialPosition()
    {
        float duration = 0.5f; // �ƶ�����ʼλ�õ�ʱ��
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition; // ȷ������λ�þ�ȷ
    }
}
