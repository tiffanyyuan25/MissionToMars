using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTester : MonoBehaviour
{    
    //public void SaveGame(){        
    //    SaveGameManager.Save();
    //}

    public void LoadGame(){        
        SaveGameManager.LoadGame();        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Save Data: "+ SaveGameManager.CurrentSaveData);
        SaveGameManager.Save();
    }
}
