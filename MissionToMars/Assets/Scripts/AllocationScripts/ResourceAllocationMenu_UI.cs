using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ResourceAllocationMenu_UI : MonoBehaviour
{
    private Dictionary<ResourceItemData, int> globalAvailableResourceSlots; 
    private Dictionary<ResourceItemData, int> globalTownResourceSlots; 
    private Dictionary<ResourceItemData, int> globalMissionResourceSlots; 
    
    [SerializeField] private ResourceAllocationManager_UI townAllocator;
    [SerializeField] private ResourceAllocationManager_UI missionAllocator;

    [SerializeField] private ResourceItemData[] resources;

    [SerializeField] private Button launch;
    [SerializeField] private Button done;

    [SerializeField] private int[] minimumToLaunch;
    private Dictionary<ResourceItemData, int> minDict;

    public ResourceAllocationManager_UI TownAllocator => townAllocator;
    public ResourceAllocationManager_UI MissionAllocator => missionAllocator;

    protected void Start()
    {
        minDict = new Dictionary<ResourceItemData, int>(5);

        for (int i = 0; i < resources.Length; i++)
        {
            minDict[resources[i]] = minimumToLaunch[i];
        }

        townAllocator.AssignSlots(resources);
        missionAllocator.AssignSlots(resources);

        globalAvailableResourceSlots = GameMaster.globalAvailableResourceSlots;
        globalTownResourceSlots = GameMaster.globalTownResourceSlots;
        globalMissionResourceSlots = GameMaster.globalMissionResourceSlots;

        if (globalTownResourceSlots == null)
        {
            globalTownResourceSlots = new Dictionary<ResourceItemData, int>(5);
            foreach (ResourceItemData resource in resources)
            {
                globalTownResourceSlots [resource] = 0;
            }
        }

        if (globalMissionResourceSlots == null)
        {
            globalMissionResourceSlots = new Dictionary<ResourceItemData, int>(5);
            foreach (ResourceItemData resource in resources)
            {
                globalMissionResourceSlots [resource] = 0;
            }
        }

        AssignResources(globalMissionResourceSlots, globalTownResourceSlots);

        bool checkDone = GameMaster.CheckAvailableValues();
        bool checkLaunch = CheckReadyToLaunch();
        done.interactable = checkDone;
        launch.interactable = checkLaunch;
    }

    public void AssignResources(Dictionary<ResourceItemData, int> missionRes, Dictionary<ResourceItemData, int> townRes)
    {
        foreach (var slot in missionRes)
        {
            missionAllocator.UpdateSlot(slot.Key, slot.Value);
        }

        foreach (var slot in townRes)
        {
            townAllocator.UpdateSlot(slot.Key, slot.Value);
        }
    }

    public bool UpdateGlobalAvailable(ResourceItemData itemToUpdate, int amountToUpdate) 
    {
        if (globalAvailableResourceSlots.ContainsKey(itemToUpdate))
        {
            int num = globalAvailableResourceSlots[itemToUpdate] - amountToUpdate;

            if (num >= 0) 
            {
                globalAvailableResourceSlots[itemToUpdate] = num;
                bool checkDone = GameMaster.CheckAvailableValues();
                bool checkLaunch = CheckReadyToLaunch();
                done.interactable = checkDone;
                launch.interactable = checkLaunch;
                return true;
            } else 
            {
                return false;
            }
        } else 
        {
            globalAvailableResourceSlots[itemToUpdate] = 0;
            return false;
        }

    }

    public bool CheckReadyToLaunch() {
      bool result = true;

      foreach (var res in minDict)
      {
         if (res.Value > globalMissionResourceSlots[res.Key])
         {
            result = false;
            break;
         }
      }

      return result;
   }

}
