using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonLogic : MonoBehaviour
{
    [Header("Use this section if you want to change a single textBox")]
    [Tooltip("If using a button to change text, make sure to set text can progress var in the text panel to false")]
    public GameObject textPanel; //The text pop up this game object affects if applicable

    [Header("Use this section if you want to transition from one text box to another (assumes active panel is already visible)")]
    public GameObject activePanel;
    public GameObject nextPanel;

    [Header("use this section if you are changing an image of a panel")]
    public GameObject imagePanel;
    public Sprite newSprite;

    [Header("Use this section to change currently active buttons")]
    public GameObject[] buttonsToDeactivate;
    public GameObject[] buttonsToActivate;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NextTextOnButtonPress() //when button is pressed, make the text progress, intended to be used when button input only moves text along
    {
        textPanel.GetComponent<textPopUps>().NextText();
    }

    public void NextPanelOnButtonPress() //on button press, change panel to one to the other. Assumes 1 active text box at a time
    {
        activePanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    public void ChangeImageOnButtonPress() //changes specified game object's image to specified image
    {
        imagePanel.GetComponent<Image>().sprite = newSprite;
    }

    public void ChangeActiveButtonsOnButtonPress() //deactives and activates buttons in respective arrays
    {
        for(int i = 0; i < buttonsToDeactivate.Length; i++)
        {
            buttonsToDeactivate[i].SetActive(false);
        }
        for (int i = 0; i < buttonsToActivate.Length; i++)
        {
            buttonsToActivate[i].SetActive(true);
        }
    }
}
