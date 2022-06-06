using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerController : MonoBehaviour
{
    public float movSpeed;
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
            transform.Translate(0, 0, movSpeed);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z > -6.75)
        {
            transform.Translate(0, 0, -movSpeed);
        }
    }
}
