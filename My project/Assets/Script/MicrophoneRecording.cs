using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneRecording : MonoBehaviour
{
   void Start()
    {
        
    }
    public AudioClip clipRecording;
    [SerializeField]
    //public AudioSource clipSource;
    private bool isRecording = false;
 
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            isRecording = true;
            clipRecording = Microphone.Start(Microphone.devices[0], false, 10, 44000);
            //clipSource.clip = clipRecording;
        }

    }
    public void StopRecording() {
        if (isRecording) {
            Microphone.End(Microphone.devices[0]);
            isRecording = false;
        
        }
    }
}
