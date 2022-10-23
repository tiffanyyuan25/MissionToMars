using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;

    public GameObject optionsScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    //Options Menu Fucntions
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions ()
    {
        optionsScreen.SetActive(false);
    }

    //Help Menu Functions
    public void OpenHelp ()
    {

    }

    public void CloseHelp ()
    {

    }

}
