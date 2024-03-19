using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverScene : MonoBehaviour //This scipt was used in Main Menu script.
{
    public void ReTry() //Create a function to go back to start scene.
    {
        SceneManager.LoadScene("InSide"); //Load scene name "InSide".
    }
    public void QuitGame() //Create a function to quit the game.
    {
        Application.Quit(); //Quit this game.
    }
    public void MainMenu() //Create a function to return to main menu from any other scenes.
    {
        SceneManager.LoadScene("MainMenu"); //Load scene name "MainMenu".
    }
}
