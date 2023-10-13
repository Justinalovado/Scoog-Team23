using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class CarveRing : MonoBehaviour
{
    // Start is called before the first frame update
    private Image Indicator;
    public Color myColor ;
    void Start()
    {
        Indicator = GetComponent<Image>();
        setEmpty();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setEmpty() {
        Indicator.fillAmount = 0;
        Indicator.color = Color.grey;
    }

    public void setComplete() {
        Indicator.color = myColor;
    }
    
    public void setRecordActive(bool active) {
        if (active) {
            Indicator.color = myColor;
        } else {
            Indicator.color = Color.grey;
        }
    }

    public void setFill(float fill) {
        Indicator.fillAmount = fill;
    }
}
