using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    private void OnMouseDown()
    {
        Debug.Log("yes");
        // ���������ʱ����¼��������֮���ƫ��
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseUp()
    {
        // �ɿ���갴ťʱֹͣ��ק
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            // ��������ƶ������¶����λ��
            Vector2 newPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = newPosition;
        }
    }
}
