using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelScript : MonoBehaviour
{
    public int SceneIndex;
    void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(SceneIndex);    
    }
}
