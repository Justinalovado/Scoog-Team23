using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneRecording : MonoBehaviour
{
    public void Start()
    {
        
    }
    public AudioClip cilpRecording;
 
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            cilpRecording = Microphone.Start(Microphone.devices[0], false, 10, 44000);
        }
    }
}
