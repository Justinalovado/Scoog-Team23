using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameObject instruction = GameObject.FindGameObjectWithTag("instruction").gameObject;
        instruction.transform.GetChild(0).gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ClickInstructionButton()
    {
        //GameObject main = GameObject.FindGameObjectWithTag("main").gameObject;
        //main.transform.GetChild(0).gameObject.SetActive(true);
        

        GameObject instruction = GameObject.FindGameObjectWithTag("instruction").gameObject;
        instruction.transform.GetChild(0).gameObject.SetActive(true);

       // instruction.transform.SetAsLastSibling();
        //instruction.transform.GetChild(0).gameObject.transform.SetAsLastSibling();
    }

    public void ClickReturnButton()
    {
        //GameObject main = GameObject.FindGameObjectWithTag("main").gameObject;
        //main.transform.GetChild(0).gameObject.SetActive(true);

        GameObject instruction = GameObject.FindGameObjectWithTag("instruction").gameObject;
        instruction.transform.GetChild(0).gameObject.SetActive(false);

    }
}
