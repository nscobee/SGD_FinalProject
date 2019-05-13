using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textPopUps : MonoBehaviour
{
    //Place this script on the panel that the text is on (the textbox that is visible to the players)
    //This script is intended to allow the text to scroll, as well as handle a single instance of a text box and its possible messages

    [Header("UI Objects")]
    [Tooltip("The panel in which all text objects are held")]
    public GameObject textPanel; //The panel in which the text is to be held in
    [Tooltip("The text item within the panel")]
    public Text UIText;
    [Tooltip("Any text that will be displayed by this text Panel")]

    [Header("Messages Displayed")]
    public string[] chatBoxText;
    
    [Header("Other editable vars")]
    [Tooltip("Duration of time it takes for the text to type itself out")]
    public float timeLapse = 0.1f;
    [Tooltip("Messages are displayed in order, starting with specified index. Should not be changed unless testing specific messages")]
    public int startingIndex = 0;
    [Tooltip("Manually set to false if this text requires some trigger or other action to activate")]
    public bool textCanProgress = true;
    [Tooltip("If true, sets current panel inactive when the last text field is reached and button is pressed")]
    public bool inactiveAfterLastText = false;

    

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(BuildText(index)); //test on start
        StartCoroutine(BuildText(startingIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && textCanProgress) //progress to next text on key press, if allowed to by textCanProgress bool
        {
            if((startingIndex + 1) < chatBoxText.Length) //checks if reached the last entry or not
                StartCoroutine(BuildText(++startingIndex));
            if ((startingIndex + 1) >= chatBoxText.Length && inactiveAfterLastText) //sets the game object inactive if var is true and last message has been reached
                this.gameObject.SetActive(false);
        }
    }



    private IEnumerator BuildText(int index) //Causes the text to 'type' itself into existance
    {
        UIText.text = "";

        //typing = true;
        for (int i = 0; i < chatBoxText[index].Length; i++)
        {
            UIText.text = string.Concat(UIText.text, chatBoxText[index][i]);
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSeconds(timeLapse);
        }


    }
    public void TextProgressToggle() //Toggles whether on not text can progress on button press
    {
        textCanProgress = !textCanProgress;
    }

    public void NextText()
    {
        startingIndex++;
        StartCoroutine(BuildText(startingIndex));
    }


}
