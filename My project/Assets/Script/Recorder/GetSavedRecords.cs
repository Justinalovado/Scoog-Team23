using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSavedRecords : MonoBehaviour
{

    string cachePath = Application.temporaryCachePath;

    string audioFilePath = Path.Combine(cachePath, "myAudio.clip");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
