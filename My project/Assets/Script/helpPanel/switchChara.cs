using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class switchChara : MonoBehaviour
{
    // Start is called before the first frame update
    // modified from code in week 6 tutorial
    [SerializeField] private RectTransform[] panels;
    [SerializeField] private static int selectedChara;
    public GameObject exitButton;
    public GameObject helpButton;
    public GameObject helpPanel;

    private RectTransform _currentPanel;

    private void Awake()
    {
        // Ensure only one panel in switch group is active (first by default).
        // First deactivate all panels.
        foreach (var panel in this.panels)
            panel.gameObject.SetActive(false);

        // Then set first to the active panel (if applicable).
        _currentPanel = this.panels[0];
        _currentPanel.gameObject.SetActive(true);
        //int initialIndex = getIndex();
        //Debug.LogFormat($"index: {initialIndex}");
        //helpPanel.SetActive(false);

        
    }

    private void Start()
    {
        exitButton.SetActive(true);
        //helpPanel.transform.SetAsLastSibling();
    }

    // see next character
    public void NextChara()
    {
        /* if (!this.panels.Contains(panel))
        {
            Debug.LogWarning("Cannot switch to untracked panel.");
            return;
        }
        */
        int index;

        _currentPanel.gameObject.SetActive(false); //turn off current panel
        // lock on to next panel and display
        if(this._currentPanel){
            index = getIndex();
            
            _currentPanel = this.panels[index + 1];
            //Debug.LogFormat($"index: {index}");
            _currentPanel.gameObject.SetActive(true);
            //_currentPanel.SetAsLastSibling();
        }         
    }





    public int getIndex()
    {
        for (int i = 0; i < this.panels.Length;)
        {
            if (this.panels[i] == this._currentPanel)
            {
                return i;
            }
            i++;
        }
        return -1;
    }

    public void exitHelpPanel() {
        _currentPanel.gameObject.SetActive(false);
        exitButton.SetActive(false);
        helpPanel.SetActive(false);
        helpButton.SetActive(true);
    }


    public void openHelpPanel()
    {
        helpPanel.SetActive(true);
        exitButton.SetActive(true);
        helpButton.SetActive(false);
        Awake();
    }

}
