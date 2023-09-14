using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject targetObject; // ��Ϸ���������ж�λ��
    public Transform[] draggableImages; // 5�����϶���ͼƬ

    private Vector3[] initialPositions; // ���ڴ洢ͼƬ�ĳ�ʼλ��
    private bool[] isDragging; // ���ڸ����Ƿ������϶�ÿ��ͼƬ
    private bool sceneChanged = false;

    void Start()
    {
        initialPositions = new Vector3[draggableImages.Length];
        isDragging = new bool[draggableImages.Length];

        // �洢ÿ��ͼƬ�ĳ�ʼλ��
        for (int i = 0; i < draggableImages.Length; i++)
        {
            initialPositions[i] = draggableImages[i].position;
        }
    }

    void Update()
    {
        if (sceneChanged) return;
        // ���ÿ��ͼƬ�Ƿ���Ŀ�����λ����ͬ
        for (int i = 0; i < draggableImages.Length; i++)
        {
            if (isDragging[i]) continue;

            if (Vector3.Distance(draggableImages[i].position, targetObject.transform.position) < 1f)
            {
                // ��ͼƬ����Ŀ�����ʱ��ִ�г���ת��
                Debug.Log("�л������� " + i);
                sceneChanged = true; // ���ó����Ѿ��ı�ı�־
                return; // �����˳�Updateѭ�����Է�ֹ�ٴμ��
            }
        }
    }
}


