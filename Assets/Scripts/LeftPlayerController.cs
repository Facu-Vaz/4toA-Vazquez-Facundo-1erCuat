using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerController : MonoBehaviour
{
    public float movSpeed;
    public float rotSpeed;
    public bool isBoosted;
    // Start is called before the first frame update
    void Start()
    {
        isBoosted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.z < 6.75)
        {
            transform.position += new Vector3 (0, 0, movSpeed);
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.z > -6.75)
        {
            transform.position += new Vector3(0, 0, -movSpeed);
        }
        else if (Input.GetKey(KeyCode.A) && transform.rotation.y > -0.1)
        {
            transform.Rotate(0, -rotSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D) && transform.rotation.y < 0.1)
        {
            transform.Rotate(0, rotSpeed, 0);
        }
    }

    public void PowerUp()
    {
        
    }

    public void PowerDown()
    {
        
    }
}
