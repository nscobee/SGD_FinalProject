using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Color newColor;

    [Header("Use this section to change currently active buttons")]
    public GameObject[] buttonsToDeactivate;
    public GameObject[] buttonsToActivate;

    [Header("Use this section to change a single instant of text")]
    public Text textToChange;
    public string text;

    public bool hasBeenClicked = false;


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
        hasBeenClicked = true;
    }

    public void NextPanelOnButtonPress() //on button press, change panel to one to the other. Assumes 1 active text box at a time
    {
        activePanel.SetActive(false);
        nextPanel.SetActive(true);
        hasBeenClicked = true;
    }

    public void ChangeImageOnButtonPress() //changes specified game object's image to specified image
    {
        imagePanel.GetComponent<Image>().sprite = newSprite;
        imagePanel.GetComponent<Image>().color = newColor;
        hasBeenClicked = true;
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
        hasBeenClicked = true;
    }

    public void doNothing() //A button that does nothing
    {
        hasBeenClicked = true;
    }

    public void changeText() //Changes text to the displayed text
    {
        textToChange.text = text;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
