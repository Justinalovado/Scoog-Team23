using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

public class Record : MonoBehaviour {

    private bool RecordOngoing = false;
    private float curTime = 0;
    public float MaxRecordTime = 10;
    
    
    public List<Toggle> Buttons;

    public List<CarveRing> Indicators;
    
    public List<(float Time, int ButtonID)> Recording = new List<(float, int)>();

    public Button ReplayButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RecordOngoing) {
            Increment();
            foreach (CarveRing indicator in Indicators) {
                indicator.setFill(curTime/MaxRecordTime);
            }
        }
        
    }

    public void stopRecording() {
        RecordOngoing = false;
        foreach (CarveRing indicator in Indicators) {
            indicator.setComplete();
        }
        // printRecording();
        foreach (var button in Buttons) {
            button.isOn = false;
        }

        ReplayButton.interactable = true;
    }
    public void startRecording() {
        ReplayButton.interactable = false;
        RecordOngoing = true;
        curTime = 0;
        foreach (CarveRing indicator in Indicators) {
            indicator.setEmpty();
        }
    }

    public void toggleRecording() {
        if (RecordOngoing) {
            stopRecording();
        }
        else {
            startRecording();
        }
    }
    
    public void lodgeRecord(int buttonID, bool isOn) {
        if (!RecordOngoing) {
            return;
        }
        Recording.Add((Time: curTime, ButtonID: buttonID));
        Indicators[buttonID].setRecordActive(isOn);
    }
    
    public void Increment() {
        curTime += Time.deltaTime;
        if (curTime > MaxRecordTime) {
            stopRecording();
        }
    }

    private void printRecording() {
        var presses = Recording;
        foreach (var press in presses)
        {
            Debug.Log($"Button {press.ButtonID} was pressed {press.Time} seconds after init.");
        }
    }

    public List<(float Time, int ButtonID)> getRecording() {
        return Recording;
    }

    public float getRecordTime() {
        return curTime;
    }

    public float getMaxRecordTime() {
        return MaxRecordTime;
    }
}
