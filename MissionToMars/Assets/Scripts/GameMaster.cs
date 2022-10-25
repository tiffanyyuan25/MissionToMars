using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   public static GameMaster instance;
   public static Dictionary<ResourceItemData, int> globalAvailableResourceSlots = new Dictionary<ResourceItemData, int>(5);
   public static Dictionary<ResourceItemData, int> globalTownResourceSlots = new Dictionary<ResourceItemData, int>(5); 
   public static Dictionary<ResourceItemData, int> globalMissionResourceSlots = new Dictionary<ResourceItemData, int>(5); 

   public static int TownMorale = 100;
   public static int PopulationSize = 100;
   public static int Score = 0;

   public static int DayCounter;

   public static bool CheckAvailableValues() {
      bool result = true;

      foreach (var res in globalAvailableResourceSlots)
      {
         if (res.Value != 0)
         {
            result = false;
            break;
         }
      }

      return result;
   }

}
