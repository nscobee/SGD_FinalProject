using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonPressManager : MonoBehaviour
{
    public GameObject[] buttonsToManage;
    public bool allButtonsClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allButtonsClicked = checkForButtonsClicked();

       
    }

    public bool checkForButtonsClicked()
    {
        bool allTrue = false;

        for (int i = 0; i < buttonsToManage.Length; i++)
        {
            if (!buttonsToManage[i].GetComponent<buttonLogic>().hasBeenClicked)
            {
                return false;
            }
            else allTrue = true;

        }
        return allTrue;
    }
}
