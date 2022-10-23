using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ResourceHolder : MonoBehaviour
{
  [SerializeField] private int resourceSize;
  [SerializeField] protected ResourceSystem resourceSystem;

  public ResourceSystem ResourceSystem => resourceSystem;

  public static UnityAction<ResourceSystem> OnDynamicResourceDisplayRequested;

  private void Awake()
  {
    resourceSystem = new ResourceSystem(resourceSize);
  }
}
