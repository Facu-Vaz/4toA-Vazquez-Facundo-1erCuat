using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigthPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float movSpeed;
    public float rotSpeed;
    public bool isBoosted;
    void Start()
    {
        isBoosted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.z < 6.75)
        {
            transform.position += new Vector3(0, 0, movSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -6.75)
        {
            transform.position += new Vector3(0, 0, -movSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.rotation.y > -0.1)
        {
            transform.Rotate(0, -rotSpeed, 0);
            Debug.Log(transform.rotation.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.rotation.y < 0.1)
        {
            transform.Rotate(0, rotSpeed, 0);
        }
    }
}
