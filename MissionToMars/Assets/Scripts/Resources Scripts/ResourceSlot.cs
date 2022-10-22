using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceSlot
{
   [SerializeField] private ResourceItemData itemData;
   [SerializeField] private int numItems;

   public ResourceItemData ItemData => itemData;
   public int NumItems => numItems;

   public ResourceSlot(ResourceItemData source, int amount)
   {
      itemData = source;
      numItems = amount;
   }

   // Empty Slot
   public ResourceSlot()
   {
      ClearSlot();
   }

   public void ClearSlot()
   {
      itemData = null;
      numItems = (-1);
   }

   public void AddToStack(int amount)
   {
      numItems += amount;
   }

   public void RemoveFromStack(int amount)
   {
      numItems -= amount;
   }
}
