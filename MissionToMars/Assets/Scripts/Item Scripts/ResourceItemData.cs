using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resource System/Resource Item")]
public class ResourceItemData : ScriptableObject
{
    public string DisplayName;
    public Sprite Icon;

    public int MoraleImpact;
    public int PopulationImpact;
}
