using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speedvariable of 8
    private float _laserSpeed = 8.0f;
    private float upperBound = 8.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up* _laserSpeed * Time.deltaTime);

       
        if (transform.position.y >= upperBound)
        {
            Destroy(this.gameObject);
        }

    }
}
