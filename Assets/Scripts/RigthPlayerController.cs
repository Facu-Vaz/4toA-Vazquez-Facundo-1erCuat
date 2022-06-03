using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigthPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float movSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.z < 6.75)
        {
            transform.Translate(0, 0, movSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -6.75)
        {
            transform.Translate(0, 0, -movSpeed);
        }
    }
}
