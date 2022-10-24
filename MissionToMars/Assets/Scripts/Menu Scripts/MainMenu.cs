using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    public GameObject optionsMenu;
    public GameObject helpMenu;

    public void PlayGame()
    {
        //SceneManager.LoadScene(firstLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


    //Options Menu Functions
    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptions () //back button on options menu
    {
        optionsMenu.SetActive(false);
    }


    //Help Menu Functions
    public void OpenHelp ()
    {
        helpMenu.SetActive(true);
    }

    public void CloseHelp ()
    {
        helpMenu.SetActive(false);
    }

}
