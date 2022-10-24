using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ResourceAllocationMenu : MonoBehaviour
{
    
    [SerializeField] private ResourceAllocationManager_UI townAllocator;
    [SerializeField] private ResourceAllocationManager_UI missionAllocator;

    [SerializeField] private Button launch;
    [SerializeField] private Button done;


    public ResourceAllocationManager_UI TownAllocator => townAllocator;
    public ResourceAllocationManager_UI MissionAllocator => missionAllocator;



}
