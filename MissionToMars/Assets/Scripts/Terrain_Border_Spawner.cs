using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Terrain_Border_Spawner : MonoBehaviour
{    
    public GameObject boundary;
    public int borderSize;

    void Start(){
        Debug.Log("[INFO] Generating Outer Terrain...");
        Vector3 position;
        for(int side = 0; side<4; side++)
        {
            Debug.Log("[INFO] Testing Here");
            for(int i=-borderSize; i<borderSize; i+=2)
            {
                position = generate_position(i, side);
                Instantiate(boundary, position, Quaternion.identity);
            }
        }  
        Debug.Log("[INFO] Border Generated");              
        
    }

    Vector3 generate_position(int i, int side){
        Vector3 pos;
        if(side == 0){
            pos = new Vector3(i, 0, -borderSize);
        }
        else if(side == 1){
            pos = new Vector3(-borderSize,0,i);
        }
        else if(side == 2){
            pos = new Vector3(i, 0, borderSize);
        }
        else{
            pos = new Vector3(borderSize, 0, i);
        }
        return pos;
    }   

}
