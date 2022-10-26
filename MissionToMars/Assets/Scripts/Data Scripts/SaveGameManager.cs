using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveGameManager
{
    public static SaveData CurrentSaveData = new SaveData();
    private static ResourceSlot[] resources;

    private static ResourceSystem tempInventory;

    public const string SaveDirectory = "/SaveData/";
    public const string FileName = "SaveGame.sav";

    public static bool Save(){
        var dir = Application.persistentDataPath + SaveDirectory;

        if(!Directory.Exists(dir)){
            Directory.CreateDirectory(dir);            
        }        
        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FileName, json);
        Debug.Log("[INFO] Game Save File paths: " + dir);
                
        return true;
    }

    public static void LoadGame(){
        string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
        SaveData tempData = new SaveData();

        if(File.Exists(fullPath)){
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveData>(json);
        }
        else {
            Debug.LogError("SaveFile does not exist");
        }
        CurrentSaveData = tempData;
        //tempInventory = LoadResources(CurrentSaveData.playerData.inventory);        
    }

    private static void RetrieveResources(ResourceSystem inventory){        
        for(int count=0; count<=4;count++){
            resources[count] = inventory.ResourceSlots[count];            
        }
    }

    private static void LoadResources(ResourceSlot[] resources){    
        foreach(var resource in resources){
            tempInventory.AddToResources(resource.ItemData, resource.NumItems);
        }
    }
}
