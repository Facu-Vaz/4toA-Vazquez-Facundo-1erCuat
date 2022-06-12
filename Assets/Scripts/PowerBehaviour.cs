using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBehaviour : MonoBehaviour
{
    bool toUp;
    public float movSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        toUp = true;
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (toUp)
        {
            transform.Translate(new Vector3(0, 0, movSpeed));
        }
        else
        {
            transform.Translate(new Vector3(0, 0, -movSpeed));
        }

        if (transform.position.z > 5)
        {
            toUp = false;
        }
        else if (transform.position.z < -5)
        {
            toUp = true;
        }
    }
}
