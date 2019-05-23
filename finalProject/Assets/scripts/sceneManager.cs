using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This script dictates how the game flows. This should be the only script that needs changing (outside of bug fixes)

public class sceneManager : MonoBehaviour
{
    public buttonPressManager[] buttonPressEvents;
    public int currentEventToManage = 0;
    public GameObject[][] buttonsToActivate; //because unity hates multidimensional arrays, each set will need to be manually initialized in start method (copy pasta example) 
    public GameObject[] setOne;
    private bool canTransitionButtons = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
        //To initialize a second set of buttons, copy pasta these 4 following lines of code and follow instructions
        for(int i = 0; i < setOne.Length; i++) //replace "setOne" with the name of the next array of objects
        {
            //Debug.Log("Got to the first For loop");
            //buttonsToActivate[0][i] = setOne[i]; //change the 0 the next number in the sequence (for 2 sets, it would be a 1, for 3, it would be a 2), and replace setOne as above
            //Debug.Log("Made it through");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //this block does a few things:
        //Checks if all buttons have been clicked
        //Once they have been clicked, it deactivates active buttons, then actives all the buttons in the current set
        //the bool makes sure this is only done once, and not every frame
        //it then changes the multidimentional array to get ready for the next set to be managed
        if(buttonPressEvents[currentEventToManage].allButtonsClicked && canTransitionButtons)
        {
            canTransitionButtons = false;
            DeactivateActiveButtons();
            SetActiveButtons(currentEventToManage);
            currentEventToManage++;
            canTransitionButtons = true;
        }
    }



    private void SetActiveButtons(int i)
    {
        //for(int j = 0; j < buttonsToActivate[i].Length; j++)
        //{
        //    buttonsToActivate[i][j].SetActive(true);
        //}
        for (int j = 0; j <= setOne.Length; j++)
        {
            Debug.Log(j);
            setOne[j].SetActive(true);
        }

    }

    private void DeactivateActiveButtons() //Finds all currently active buttons in the scene and deactivates them
    {        
        Button[] activeButtons = GameObject.FindObjectsOfType<Button>();
        for(int i = 0; i < activeButtons.Length; i++)
            activeButtons[i].gameObject.SetActive(false);            
    }
}
