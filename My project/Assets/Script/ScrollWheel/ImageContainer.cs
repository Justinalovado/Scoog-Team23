using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageContainer : MonoBehaviour
{
    private Transform[] images; // 保存子图片的Transform组件
    private Vector2 initialPosition; // 初始位置
    private Vector2 dragStartPosition; // 拖拽开始位置
    private bool isDragging; // 是否正在拖拽

    private void Start()
    {
        // 获取子图片的Transform组件
        images = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            images[i] = transform.GetChild(i);
        }

        // 保存初始位置
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isDragging)
        {
            // 计算拖拽偏移
            Vector2 dragOffset = (Vector2)Input.mousePosition - dragStartPosition;

            // 设置整体容器的位置
            transform.position = initialPosition + dragOffset;

            // 如果拖拽超过一定距离，则调整图片位置以保持居中
            float threshold = 100.0f; // 超过这个阈值时触发居中
            float centerY = Screen.height / 2.0f;

            if (Mathf.Abs(dragOffset.y) > threshold)
            {
                // 计算应该居中的图片索引
                int centerImageIndex = dragOffset.y > 0 ? 0 : images.Length - 1;

                // 移动图片容器以保持居中图片
                transform.position = new Vector2(transform.position.x, images[centerImageIndex].position.y - centerY);
            }
        }
    }

    private void OnMouseDown()
    {
        // 记录拖拽开始位置
        dragStartPosition = Input.mousePosition;
        Debug.Log("yes");
        isDragging = true;
    }

    private void OnMouseUp()
    {
        // 停止拖拽
        isDragging = false;
    }
}
