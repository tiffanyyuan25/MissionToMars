using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    public GameObject terrainTexture;
    public Material terrainMaterial;
    public int x_origin;
    public int y_origin;

    public GameObject[] terrainList;
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        for(int i=-2; i<3; i++){            
            terrainList[count] = Instantiate(terrainTexture,new Vector3(i*128, 0, -256), Quaternion.identity);
            //terrainList[count].
            count += 1;            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
