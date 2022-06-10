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
        else if (Input.GetKey(KeyCode.A) && transform.rotation.y > -0.1 && !isBoosted)
        {
            transform.Rotate(0, -rotSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D) && transform.rotation.y < 0.1 && !isBoosted)
        {
            transform.Rotate(0, rotSpeed, 0);
        }
    }

    public void PowerUp()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0.3f, 1, 3);
        isBoosted = true;
        if (transform.position.z < -6.25)
        {
            transform.position = new Vector3(-13.5f, 0.5f, -6.25f);
        }
        if (transform.position.z > 6.25)
        {
            transform.position = new Vector3(-13.5f, 0.5f, 6.25f);
        }
    }

    public void PowerDown()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0.3f, 1, 2);
        isBoosted = false;
    }
}
