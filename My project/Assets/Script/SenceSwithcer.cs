using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject targetObject; // 游戏对象，用于判断位置
    public Transform[] draggableImages; // 5个可拖动的图片

    private Vector3[] initialPositions; // 用于存储图片的初始位置
    private bool[] isDragging; // 用于跟踪是否正在拖动每个图片
    private bool sceneChanged = false;

    void Start()
    {
        initialPositions = new Vector3[draggableImages.Length];
        isDragging = new bool[draggableImages.Length];

        // 存储每个图片的初始位置
        for (int i = 0; i < draggableImages.Length; i++)
        {
            initialPositions[i] = draggableImages[i].position;
        }
    }

    void Update()
    {
        if (sceneChanged) return;
        // 检查每个图片是否与目标对象位置相同
        for (int i = 0; i < draggableImages.Length; i++)
        {
            if (isDragging[i]) continue;

            if (Vector3.Distance(draggableImages[i].position, targetObject.transform.position) < 1f)
            {
                // 当图片靠近目标对象时，执行场景转换
                Debug.Log("切换到场景 " + i);
                sceneChanged = true; // 设置场景已经改变的标志
                return; // 立即退出Update循环，以防止再次检查
            }
        }
    }
}


