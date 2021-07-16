using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private bool isEnemyLaser = false;

    [SerializeField]
    private float _laserSpeed = 4.0f;

    private float upperBound = 8.0f;
    private float lowerBound = -8.0f;

    // Update is called once per frame
    void Update()
    {
        if (isEnemyLaser == false)
        {
            MoveUp();
        }

        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);


        if (transform.position.y >= upperBound)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _laserSpeed * Time.deltaTime);


        if (transform.position.y <= lowerBound)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        isEnemyLaser = true;
    }
}
