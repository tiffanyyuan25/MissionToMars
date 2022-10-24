using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   public static float timeLeft = 5.0f;
   [SerializeField] private ResourceHolder resourceHolder;

   public void Update()
   {
     timeLeft -= Time.deltaTime;
     if (timeLeft <= 0.0f)
     {
        List<ResourceSlot> slots = resourceHolder.ResourceSystem.ResourceSlots;

        foreach (ResourceSlot slot in slots)
        {
            var item = slot.ItemData;
            if (item != null)
            {
                GameMaster.globalAvailableResourceSlots[item] = slot.NumItems;
            }
        }

        SceneManager.LoadScene("Scenes/Workshop");
     }
   }
}
