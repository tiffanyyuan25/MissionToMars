using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    private PlayerData myData = new PlayerData();
    private static ResourceSystem tempInventory;
    
    // Update is called once per frame
    private void Start() {
        Debug.Log("[INFO] Loading in inventory...");
        SaveGameManager.LoadGame();
        myData = SaveGameManager.CurrentSaveData.playerData;
        //LoadResources(myData.inventory);
        foreach (var resource in myData.inventory){
            gameObject.GetComponent<ResourceHolder>().ResourceSystem.AddToResources(resource.ItemData, resource.NumItems);
        }
        //gameObject.GetComponent<ResourceHolder>().ResourceSystem = tempInventory;
    }

    void Update()
    {        
        //myData.PlayerPosition = transform.position;
        //myData.PlayerRotation = transform.rotation;  
        myData.inventory = RetrieveItems(gameObject.GetComponent<ResourceHolder>().ResourceSystem);        
        SaveGameManager.CurrentSaveData.playerData = myData;
    }

    private ResourceSlot[] RetrieveItems(ResourceSystem inventory){
        ResourceSlot[] tempInventory = new ResourceSlot[5];
        for(int count=0; count<=4;count++){
            tempInventory[count] = inventory.ResourceSlots[count];            
        }
        return tempInventory;
    }

    private static void LoadResources(ResourceSlot[] resources){    
        foreach(var resource in resources){
            tempInventory.AddToResources(resource.ItemData, resource.NumItems);
        }
    }
}

[System.Serializable]
public struct PlayerData
{
    //public Vector3 PlayerPosition;
    //public Quaternion PlayerRotation;
    public ResourceSlot[] inventory;    
}
