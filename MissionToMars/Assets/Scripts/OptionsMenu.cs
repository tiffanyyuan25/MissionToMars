using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog;

    public AudioMixer audioMixer;

    // Graphics component
    // Start is called before the first frame update
    public void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
    }


    // Volume component 
    public void SetVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void saveChanges()
    {
        Screen.fullScreen = fullscreenTog.isOn;
    }


}
