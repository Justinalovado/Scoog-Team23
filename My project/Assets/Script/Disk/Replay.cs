using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Replay : MonoBehaviour {
    public Record Recorder;
    private float replayTime;
    private float replayLenght;
    private float MaxReplayTime;
    private bool replayOngoing;

    public GameObject Disk;
    private Vector3 DiskDefaultAngle;
    
    public List<(float Time, int ButtonID)> Recording;
    public List<(float Time, int ButtonID)> ReplayTemplate;
    
    public List<Toggle> Buttons;

    
    public Button RecordButton;
    
    // Start is called before the first frame update
    void Start() {
        MaxReplayTime = Recorder.getMaxRecordTime();
        replayTime = 0;
        replayOngoing = false;
        DiskDefaultAngle = Disk.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (replayOngoing) {
            checkReplay();
            updateDiskRotation();
        }
    }

    public void startReplay() {
        RecordButton.interactable = false;
        diableAllButton();
        Recording = Recorder.getRecording();
        replayLenght = Recorder.getRecordTime();
        replayTime = 0;
        replayOngoing = true;
        ReplayTemplate = new List<(float Time, int ButtonID)>(Recording);
    }

    public void stopReplay() {
        replayOngoing = false;
        foreach (var button in Buttons) {
            button.isOn = false;
        }
        replayTime = 0;
        RecordButton.interactable = true;
        enableAllButton();
    }

    public void checkReplay() {
        replayTime += Time.deltaTime;
        if (ReplayTemplate.Count > 0)
        {
            // Check the first record's time
            var record = ReplayTemplate[0];

            if (record.Time < replayTime) {
                Buttons[record.ButtonID].isOn = !Buttons[record.ButtonID].isOn;
                // Remove the record from the list
                ReplayTemplate.RemoveAt(0);
            }
        } else if (replayTime > replayLenght) {
            stopReplay();
        }
    }

    public void toggleReplay() {
        if (replayOngoing) {
            stopReplay();
            updateDiskRotation();
        }
        else {
            startReplay();
        }
    }
    public void updateDiskRotation() {
        Vector3 rot = DiskDefaultAngle;
        rot.z += 360 * replayTime / MaxReplayTime;
        Disk.transform.eulerAngles = rot;
    }

    public void diableAllButton() {
        foreach (var button in Buttons) {
            button.interactable = false;
        }
    }
    public void enableAllButton() {
        foreach (var button in Buttons) {
            button.interactable = true;
        }
    }
    
}
