using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   public static Dictionary<ResourceItemData, int> globalAvailableResourceSlots; 

   public static Dictionary<ResourceItemData, int> globalTownResourceSlots; 
   public static Dictionary<ResourceItemData, int> globalMissionResourceSlots; 

   public static int TownMorale = 100;

   public static int PopulationSize = 100;

}
