using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _downSpeed = 3f;

    private float _lowerBound = -5.5f;

    //id for powerups
    //0 for 3shot
    //1 for speed
    //2 for shields
    [SerializeField]
    private int powerupID;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 powerupDownSpeed = Vector3.down * _downSpeed * Time.deltaTime;

        transform.Translate(powerupDownSpeed);

        if (transform.position.y <= _lowerBound)
        {
            Destroy(this.gameObject);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D powerUpCollision)
    {
        if (powerUpCollision.tag == "Player")
        {
            Player player = powerUpCollision.transform.GetComponent<Player>();

            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.TripleShotActive();
                }
                else if (powerupID == 1)
                {
                    Debug.Log("hello world");
                }
                else if (powerupID == 2)
                {
                    Debug.Log("hello world");
                }

            }

            Destroy(this.gameObject);
        }
    }



}
