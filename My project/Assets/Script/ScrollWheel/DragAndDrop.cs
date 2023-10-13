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
        // 当点击对象时，记录鼠标与对象之间的偏移
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseUp()
    {
        // 松开鼠标按钮时停止拖拽
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            // 随着鼠标移动，更新对象的位置
            Vector2 newPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = newPosition;
        }
    }
}
