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
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        Debug.Log("hello world");
                        break;

                    default:
                        Debug.Log("default");
                        break;

                }

            }

            Destroy(this.gameObject);
        }
    }



}
