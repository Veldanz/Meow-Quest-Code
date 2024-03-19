using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour //This script is used for NPC to create a dialogue function.
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject nextButton;

    public float wordSpeed;
    public bool playerIsClose;
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose) //Make the condition that if player press "E" button and player must be nearby NPC
        {
            if (dialoguePanel.activeInHierarchy)//If dialogue panel is opening.
            {
                zeroText(); //If dialogue panel is now open, use "ZeroText" function.

            }
            else
            {
                //If dialogue is closing. Open it and start showing the dialogue.
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            nextButton.SetActive(true); //If the dialogue window is using. set the next button to active.
        }
    }

    public void zeroText() //Create "ZeroText" function.
    {
        dialogueText.text = ""; //Erases any text that was displayed in the dialoguepanel.
        index = 0; //Make the index to 0.
        dialoguePanel.SetActive(false); //Close the dialogue panel.
    }

    IEnumerator Typing() //Do a typing effect for the dialogue.
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter; //Add each letter to the text of the dialogue.
            yield return new WaitForSeconds(wordSpeed); //Make it slow down when adding letters.
        }
    }

    public void NextLine() //The next line function.
    {

        nextButton.SetActive(false); //Close the next button after click on it.

        if (index < dialogue.Length - 1) //If the index is less than the length of the dialogue array minus one.
        {
            index++;
            dialogueText.text = ""; //Clear all text
            StartCoroutine(Typing()); //Show the next part of the dialogue with delay using "Typing".
        }
        else
        {
            zeroText(); //Call "ZeroText" function.
        }
    }


    private void OnTriggerEnter2D(Collider2D other) //Use the collider function to see if they hit with a collider or not. 
    {
        if (other.CompareTag("Player")) //If it's hit the object name "Player".
        {
            playerIsClose = true; //Set playerIsClose to True.
        }

    }
    private void OnTriggerExit2D(Collider2D other) //Use the collider function to see if they hit with a collider or not.
    {
        if (other.CompareTag("Player")) //If it's not hit the object name "Player".
        {
            playerIsClose = false;  //Set playerISClose to fales
            zeroText(); //Do a "ZeroText" function.

        }
    }
}