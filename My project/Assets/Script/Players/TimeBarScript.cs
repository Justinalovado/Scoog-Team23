using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public Image timeBar;
    float my_time, maxTime = 100;

    void Start()
    {
        my_time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        TimeBarFiller();
    }

    void TimeBarFiller()
    {
        timeBar.fillAmount = my_time / maxTime;
    }
    
    public void startRecord()
    {
        if(my_time > 0 ) { }
    }
}
