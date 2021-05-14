using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _downSpeed = 4f;

    private float _lowerBound = -5.5f;
    private float _upperBound = 7.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9f, 9f), _upperBound, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4m/s
        Vector3 enemyDownSpeed = Vector3.down* _downSpeed*Time.deltaTime;

        transform.Translate(enemyDownSpeed);
        //when off screen, respawn at top with a new random x pos

        if (transform.position.y <= _lowerBound)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, _upperBound, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is player
        if (other.tag == "Player")
        {
            Debug.Log("you got got");
            Destroy(this.gameObject);
        }



        //if other is laser
        if (other.tag == "Laser")
        {
            //destroy laser
            Destroy(other.gameObject);
            //destroy us
            Destroy(this.gameObject);

        }



    }

}
