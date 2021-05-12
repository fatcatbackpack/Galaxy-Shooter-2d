using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speedvariable of 8
    private float _laserSpeed = 8.0f;
    private float upperBound = 8.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //go up
        transform.Translate(Vector3.up* _laserSpeed *Time.deltaTime);

        //if position y is greater than 8
        //destroy the object
        if (transform.position.y >= upperBound)
        {
            Destroy(this.gameObject);
        }

    }
}
