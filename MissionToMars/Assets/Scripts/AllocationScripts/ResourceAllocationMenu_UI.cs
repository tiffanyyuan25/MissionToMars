using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceAllocationMenu_UI : MonoBehaviour
{
    private Dictionary<ResourceItemData, int> globalAvailableResourceSlots; 
    private Dictionary<ResourceItemData, int> globalTownResourceSlots; 
    private Dictionary<ResourceItemData, int> globalMissionResourceSlots; 
    
    [SerializeField] private ResourceAllocationManager_UI townAllocator;
    [SerializeField] private ResourceAllocationManager_UI missionAllocator;

    [SerializeField] private int[] minimumToLaunch;
    [SerializeField] private ResourceItemData[] resources;

    [SerializeField] private Button launch;
    [SerializeField] private Button done;
    [SerializeField] private AllocateHotBar hotbar;

    [SerializeField] private TextMeshProUGUI population;
    [SerializeField] private TextMeshProUGUI morale;

    private Dictionary<ResourceItemData, int> minDict;

    public ResourceAllocationManager_UI TownAllocator => townAllocator;
    public ResourceAllocationManager_UI MissionAllocator => missionAllocator;

    public int resourcePadding = 5;
    public int upperExtraResources = 10;
    public int lowerExtraResources = 2;

    protected void Start()
    {   
        globalAvailableResourceSlots = GameMaster.globalAvailableResourceSlots;
        globalTownResourceSlots = GameMaster.globalTownResourceSlots;
        globalMissionResourceSlots = GameMaster.globalMissionResourceSlots;

        minDict = new Dictionary<ResourceItemData, int>(5);

        for (int i = 0; i < resources.Length; i++)
        {
            minDict[resources[i]] = minimumToLaunch[i];
        }

        townAllocator.AssignSlots(resources);
        missionAllocator.AssignSlots(resources);

        if (globalTownResourceSlots.Count == 0)
        {
            foreach (ResourceItemData resource in resources)
            {
                globalTownResourceSlots [resource] = 0;
            }
        }

        if (globalMissionResourceSlots.Count == 0)
        {
            foreach (ResourceItemData resource in resources)
            {
                globalMissionResourceSlots [resource] = 0;
            }
        } 

        AssignResources(globalMissionResourceSlots, globalTownResourceSlots);
        hotbar.AssignSlots(globalAvailableResourceSlots);
        population.text = GameMaster.PopulationSize.ToString();
        morale.text = GameMaster.TownMorale.ToString();

        bool checkDone = GameMaster.CheckAvailableValues();
        bool checkLaunch = CheckReadyToLaunch();
        done.interactable = checkDone;
        launch.interactable = checkLaunch;

        done?.onClick.AddListener(OnDoneClicked);
        launch?.onClick.AddListener(OnLaunchClicked);

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

    public bool UpdateGlobalAvailable(ResourceItemData itemToUpdate, int amountToUpdate, bool mission) 
    {
        if (globalAvailableResourceSlots.ContainsKey(itemToUpdate))
        {
            int num = globalAvailableResourceSlots[itemToUpdate] - amountToUpdate;

            if (num >= 0) 
            {
                globalAvailableResourceSlots[itemToUpdate] = num;
                hotbar.UpdateSlot(itemToUpdate, num);

                if (mission) 
                {
                    globalMissionResourceSlots[itemToUpdate] += amountToUpdate;
                } else 
                {
                    globalTownResourceSlots[itemToUpdate] += amountToUpdate;
                }

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

    public void OnDoneClicked()
    {
        foreach (var res in globalMissionResourceSlots)
        {
            if (res.Value > (minDict[res.Key] + resourcePadding))
            {
                GameMaster.PopulationSize -= res.Key.PopulationImpact;
                GameMaster.TownMorale -= res.Key.MoraleImpact;
            }
        }

        foreach (ResourceItemData resource in resources)
        {
            GameMaster.globalTownResourceSlots[resource] = globalTownResourceSlots[resource];
            GameMaster.globalMissionResourceSlots[resource] = globalMissionResourceSlots[resource];
        }

        if (GameMaster.DayCounter == 5)
        {
            SceneManager.LoadScene("Scenes/EndingScenes/NoTimeLessResources");
        } else 
        {
            GameMaster.DayCounter += 1;
            SceneManager.LoadScene("Scenes/TownDay");
        }

    }

    public void OnLaunchClicked()
    {
        string[] food = {"Cabbage", "Tomato", "Root Vegetable"};
        int extra;
        foreach (var res in resources)
        {
            extra = Random.Range(lowerExtraResources, upperExtraResources);

            if (globalMissionResourceSlots[res] < extra)
            {
                if (food.Contains(res.DisplayName))
                {
                    SceneManager.LoadScene("Scenes/EndingScenes/LessFood");
                } else 
                {
                    SceneManager.LoadScene("Scenes/EndingScenes/LessOre");
                }
            }

            if (globalMissionResourceSlots[res] > (extra*2))
            {
                SceneManager.LoadScene("Scenes/EndingScenes/TownDied");
            }
        }

        foreach (var res in globalMissionResourceSlots)
        {
            if (res.Value > (minDict[res.Key] + resourcePadding))
            {
                GameMaster.PopulationSize -= res.Key.PopulationImpact;
                GameMaster.TownMorale -= res.Key.MoraleImpact;
            }
        }

        GameMaster.Score = GameMaster.PopulationSize + GameMaster.TownMorale;

        SceneManager.LoadScene("Scenes/EndingScenes/MissionSuccess");

    }
}
