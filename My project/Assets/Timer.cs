using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float currentTime;
    public float timeLimit = 15;
    public bool record;
    public Image timeBar;

    public GameObject timeText;
    public GameObject myTimeBar;
    // Start is called before the first frame update
    void Start()
    {
        record = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (record)
        {
            currentTime = currentTime + Time.deltaTime;
            TimeBarFiller();
            timerText.text = currentTime.ToString("0S");
        }
        if(currentTime >= timeLimit)
        {
            stopRecord();
            
        }
        
    }
    void TimeBarFiller()
    {
        timeBar.fillAmount = currentTime / timeLimit;
    }
    public void startRecord() { record = true; currentTime = 0; timeText.SetActive(true); myTimeBar.SetActive(true); }

    public void stopRecord() { record = false; currentTime = 0; timeText.SetActive(false); myTimeBar.SetActive(false); }   

}
