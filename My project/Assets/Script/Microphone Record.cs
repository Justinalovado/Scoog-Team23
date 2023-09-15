using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneRecorder : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public AudioClip clips;
    public AudioSource recoreded_sound;
    // Update is called once per frame
    public void Update()
    {
    }
    
    public void Record()
    {
        clips = Microphone.Start(Microphone.devices[0], false, 10, 44000);
        recoreded_sound.clips = clips;
    }
}
