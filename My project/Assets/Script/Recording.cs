using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recording : MonoBehaviour
{
    // public Button recordButton;
    private bool isRecording = false;
    private float recordStartTime;
    public float maxRecordTime = 5f;
    
    public GameObject audioObject;

    private AudioSource audioSource;
    // private AudioClip clip;
    private void Start() {
        // recordButton.onClick.AddListener(OnRecordButtonPressed);
        this.audioSource = this.audioObject.GetComponent<AudioSource>();
        // foreach (var device in Microphone.devices)
        // {
        //     Debug.Log("Name: " + device);
        // }
    }

    public void OnRecordButtonPressed() {
        if (!isRecording) {
            this.audioObject.SetActive(false);
            StartRecording();
        }else {
            StopRecording();
        }
    }

    void StartRecording() {
        
        isRecording = true;
        recordStartTime = Time.time;
        this.audioSource.clip = Microphone.Start(null, false, (int)maxRecordTime, 44100);
    }
    void StopRecording()
    {
        Microphone.End(null);
        isRecording = false;

        if (Time.time - recordStartTime < maxRecordTime)
        {
            int samplesRecorded = (int)((Time.time - recordStartTime) * 44100);
        
            AudioClip newClip = AudioClip.Create("RecordedClip", samplesRecorded, 1, 44100, false);
            float[] data = new float[samplesRecorded];
            audioSource.clip.GetData(data, 0);
            newClip.SetData(data, 0);
            audioSource.clip = newClip;
        }

        this.audioObject.SetActive(true);
        this.audioSource.Play();
    }
    
    void Update() {
        if (isRecording && Time.time - recordStartTime >= maxRecordTime) {
            StopRecording();
        }
    }
}
