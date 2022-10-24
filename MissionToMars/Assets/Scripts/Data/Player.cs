using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    List<int> inventoryList;    
    //[SerializeField] private int resourceSize;
    //[SerializeField] protected ResourceSystem resourceSystem;
//
    //public ResourceSystem ResourceSystem => resourceSystem;

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);        
    }

    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        
    }
}
