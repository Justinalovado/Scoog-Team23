using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterRiseEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public float fillTime = 3;
    private float parentHeight;
    private float riseSpeed; 
    private RectTransform rectTransform;

    private bool isRising = false;
    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        // Check if this GameObject has a parent
        if (transform.parent != null) {
            RectTransform parentRectTransform = transform.parent.GetComponent<RectTransform>();
            if (parentRectTransform != null) {
                this.parentHeight = parentRectTransform.rect.height;
            }
        }

        this.riseSpeed = this.parentHeight / this.fillTime;
    }

    private void Update()
    {
        if (this.isRising) {
            rise();
        }
    }

    private void resetFill() {  
        Vector2 curSize = rectTransform.sizeDelta;
        curSize.y = 0;
        rectTransform.sizeDelta = curSize;
        this.isRising = false;
    }
    
    public void rise() {
        Vector2 curSize = rectTransform.sizeDelta;
        if (curSize.y < this.parentHeight){
            curSize.y += riseSpeed * Time.deltaTime;
            rectTransform.sizeDelta = curSize;
        } else {
            resetFill();
        }
    }

    public void startFill() {
        this.isRising = true;
    }
}
