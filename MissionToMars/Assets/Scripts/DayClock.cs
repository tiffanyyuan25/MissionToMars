using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayClock : MonoBehaviour
{
    public Light lightSource;
    public float xAngle, yAngle, zAngle;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[INFO] Current Orientation for light source: " + lightSource);
    }

    // Update is called once per frame
    void Update()
    {
        lightSource.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //Debug.Log("[INFO] Directional Light Orientation: " + lightSource.transform.rotation);
        if(lightSource.transform.localRotation.y == 0.64531){
            Debug.Log("[INFO] Game Over --- Day Ended");
        }
        else if(lightSource.transform.localRotation.y == -130){
            Debug.Log("[INFO] Day Starting");
        }
    }
}
