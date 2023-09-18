using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingMicrophone : MonoBehaviour
{
    // Start is called before the first frame update
   public  void Start()
    {
        
    }

    // Update is called once per frame
    public AudioClip  clip1;
   public  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            clip1 = Microphone.Start(Microphone.devices[0], false, 10, 44000);
        
        }
        
    }
}
