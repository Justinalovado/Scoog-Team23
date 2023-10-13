using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageContainer : MonoBehaviour
{
    private Transform[] images; // ������ͼƬ��Transform���
    private Vector2 initialPosition; // ��ʼλ��
    private Vector2 dragStartPosition; // ��ק��ʼλ��
    private bool isDragging; // �Ƿ�������ק

    private void Start()
    {
        // ��ȡ��ͼƬ��Transform���
        images = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            images[i] = transform.GetChild(i);
        }

        // �����ʼλ��
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isDragging)
        {
            // ������קƫ��
            Vector2 dragOffset = (Vector2)Input.mousePosition - dragStartPosition;

            // ��������������λ��
            transform.position = initialPosition + dragOffset;

            // �����ק����һ�����룬�����ͼƬλ���Ա��־���
            float threshold = 100.0f; // ���������ֵʱ��������
            float centerY = Screen.height / 2.0f;

            if (Mathf.Abs(dragOffset.y) > threshold)
            {
                // ����Ӧ�þ��е�ͼƬ����
                int centerImageIndex = dragOffset.y > 0 ? 0 : images.Length - 1;

                // �ƶ�ͼƬ�����Ա��־���ͼƬ
                transform.position = new Vector2(transform.position.x, images[centerImageIndex].position.y - centerY);
            }
        }
    }

    private void OnMouseDown()
    {
        // ��¼��ק��ʼλ��
        dragStartPosition = Input.mousePosition;
        Debug.Log("yes");
        isDragging = true;
    }

    private void OnMouseUp()
    {
        // ֹͣ��ק
        isDragging = false;
    }
}
