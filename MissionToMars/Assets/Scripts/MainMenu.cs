using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    public GameObject optionsMenu;

    public void PlayGame()
    {
        //SceneManager.LoadScene(firstLevel);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Scenes/TownDay");
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

    }

    public void CloseHelp ()
    {

    }

}
