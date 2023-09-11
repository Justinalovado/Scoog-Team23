using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // at start get instruction canvas as invisible
        GameObject instruction = GameObject.FindGameObjectWithTag("instruction").gameObject;
        instruction.transform.GetChild(0).gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ClickInstructionButton()
    {
        // onclick to see instructions
        GameObject instruction = GameObject.FindGameObjectWithTag("instruction").gameObject;
        instruction.transform.GetChild(0).gameObject.SetActive(true);


    }

    public void ClickReturnButton()
    {
        // onclick return to main scene
        GameObject instruction = GameObject.FindGameObjectWithTag("instruction").gameObject;
        instruction.transform.GetChild(0).gameObject.SetActive(false);

    }
}
