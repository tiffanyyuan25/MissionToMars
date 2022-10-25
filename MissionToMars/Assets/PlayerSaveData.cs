using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    private PlayerData myData = new PlayerData();
    // Update is called once per frame
    void Update()
    {
        myData.PlayerPosition = transform.position;
        myData.PlayerRotation = transform.rotation;   
        Debug.Log(transform.position);     
    }
}

[System.Serializable]
public struct PlayerData
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    //public int PlayerHealth;
}
