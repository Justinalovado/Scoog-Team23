using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 lastMousePosition;
    private float deltaY;
    private float totalDistance;

    public bool blockX, blockZ;

    private Vector3[] originalPositions; // 保存每张图片的原始位置
    private Vector3 originalPosition;    // 整体容器的原始位置

    public int CurrentScene = 0;
    public float CurrentY = 0;
    public float CurrentX = 0;
    public float CurrentZ = 0;



    private void Start()
    {
        CurrentScene = PlayerPrefs.GetInt("Current Scene", 0);
        CurrentY = PlayerPrefs.GetFloat("CurrentY", 0);
        CurrentX = transform.localPosition.x;
        CurrentZ = transform.localPosition.z;

        Debug.Log(CurrentScene);
        if (CurrentScene != 0)
        {
            transform.localPosition = new Vector3(CurrentX, CurrentY, CurrentZ);
        }
        originalPosition = transform.localPosition;
      

        // 获取每张图片的原始位置
        originalPositions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            originalPositions[i] = transform.GetChild(i).localPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        deltaY = eventData.position.y - lastMousePosition.y;
        totalDistance += deltaY;
        //Debug.Log("distance" + totalDistance);

        // 阻止在X和Z轴上的位移
        float x = blockX ? 0 : transform.localPosition.x;
        float z = blockZ ? 0 : transform.localPosition.z;

        transform.localPosition = new Vector3(x, transform.localPosition.y + deltaY, z);

        lastMousePosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        
        int closestImageIndex = GetClosestImageIndex();

        float x = blockX ? 0 : transform.localPosition.x;
        float z = blockZ ? 0 : transform.localPosition.z;
        transform.localPosition = new Vector3(x, 0f- originalPositions[closestImageIndex].y, z);

        if (closestImageIndex != CurrentScene) {
            CurrentScene = closestImageIndex;
            SceneManager.LoadScene(CurrentScene);
            PlayerPrefs.SetInt("Current Scene", CurrentScene);
            PlayerPrefs.SetFloat("CurrentY", 0f - originalPositions[closestImageIndex].y);
            PlayerPrefs.Save(); // 保存PlayerPrefs数据
        }

        totalDistance = 0;
    }

    // 计算最近的图片索引
    private int GetClosestImageIndex()
    {
        float minDistance = transform.GetChild(0).position.y - 256f;
        int closestIndex = 0;

        for (int i = 0; i < originalPositions.Length; i++)
        {
            float distance = Mathf.Abs(transform.GetChild(i).position.y - 256f);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
    
}
