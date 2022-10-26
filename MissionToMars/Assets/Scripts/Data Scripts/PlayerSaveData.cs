using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    public Light lightSource;
    private PlayerData myData = new PlayerData();
    private DayClockData clockData = new DayClockData();
    private static ResourceSystem tempInventory;
        
    private void Start() {
        Debug.Log("[INFO] Loading in inventory...");
        SaveGameManager.LoadGame();
        myData = SaveGameManager.CurrentSaveData.playerData;        
        foreach (var resource in myData.inventory){
            gameObject.GetComponent<ResourceHolder>().ResourceSystem.AddToResources(resource.ItemData, resource.NumItems);
        }
        clockData = SaveGameManager.CurrentSaveData.lightData;
        lightSource.transform.rotation = clockData.LightOrientation;        
    }

    // Update is called once per frame
    void Update()
    {                 
        myData.inventory = RetrieveItems(gameObject.GetComponent<ResourceHolder>().ResourceSystem);
        clockData.LightOrientation = lightSource.transform.rotation;
        SaveGameManager.CurrentSaveData.playerData = myData;   
        SaveGameManager.CurrentSaveData.lightData = clockData;     
        //Debug.Log("[INFO] Game Data saving....");
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
    public ResourceSlot[] inventory;    
}

[System.Serializable]
public struct DayClockData
{
    public Quaternion LightOrientation;
}
