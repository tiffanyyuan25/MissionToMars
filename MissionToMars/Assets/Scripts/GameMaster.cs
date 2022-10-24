using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   public static Dictionary<ResourceItemData, int> globalAvailableResourceSlots = new Dictionary<ResourceItemData, int>(5); 

   public static Dictionary<ResourceItemData, int> globalTownResourceSlots; 
   public static Dictionary<ResourceItemData, int> globalMissionResourceSlots; 

   public static int TownMorale = 100;

   public static int PopulationSize = 100;

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
