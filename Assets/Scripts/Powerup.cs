using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _downSpeed = 3f;

    private float _lowerBound = -5.5f;
    private float _upperBound = 7.5f;

    

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
                player.TripleShotActive();
            }

            Destroy(this.gameObject);
        }
    }



}
