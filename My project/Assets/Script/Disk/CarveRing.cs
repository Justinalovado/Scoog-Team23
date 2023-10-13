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
    private float RecordTime = 0;

    private bool RecordOngoing = false;
    
    public float MaxRecordTime = 60;
    public Color myColor ;
    void Start()
    {
        Indicator = GetComponent<Image>();
        setEmpty();
        RecordOngoing = false;
        RecordTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RecordOngoing) {
            Increment();
            Indicator.fillAmount = RecordTime / MaxRecordTime;
        }
    }

    public void setEmpty() {
        Indicator.fillAmount = 0;
        Indicator.color = Color.grey;
        this.RecordOngoing = false;
        this.RecordTime = 0;
    }
    
    public void stopRecording() {
        Indicator.color = myColor;
        RecordOngoing = false;
        
    }
    public void startRecording() {
        setEmpty();
        RecordOngoing = true;
    }

    public void toggleRecording() {
        if (RecordOngoing) {
            stopRecording();
        }
        else {
            startRecording();
        }
    }
    
    public void setRecordActive(bool active) {
        if (!RecordOngoing) {
            return;
        }
        if (active) {
            Indicator.color = myColor;
            Debug.Log(myColor.ToString());
        } else {
            Indicator.color = Color.grey;
        }
    }

    public void Increment() {
        RecordTime += Time.deltaTime;
    }
    
}
