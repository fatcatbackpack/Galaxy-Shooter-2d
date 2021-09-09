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
    private bool pwrCatch;

    private Transform _playerVec;
    Vector3 pwrUpVec;
    Vector3 powerupDownSpeed;

    [SerializeField]
    private AudioClip PowerUpSound;

    private void Start()
    {
        _playerVec = GameObject.Find("Player").transform;
        pwrCatch = false;
    }

    // Update is called once per frame
    void Update()
    {
        pwrUpVec = transform.position;

        pwrupMovement();

        

        if (transform.position.y <= _lowerBound)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            PowerCatchTrue();
        }

    }

    private void pwrupMovement()
    {
        powerupDownSpeed = Vector3.down * _downSpeed * Time.deltaTime;

        if ((Vector3.Distance(pwrUpVec, _playerVec.position) < 5.0f) && (pwrCatch == true))
        {
            powerupDownSpeed = Vector3.MoveTowards(pwrUpVec, _playerVec.position, _downSpeed * Time.deltaTime);
            transform.position = powerupDownSpeed;
        }
        else
        {
            powerupDownSpeed = Vector3.down * _downSpeed * Time.deltaTime;
            transform.Translate(powerupDownSpeed);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D powerUpCollision)
    {
        if (powerUpCollision.tag == "Player")
        {
            Player player = powerUpCollision.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(PowerUpSound, transform.position);

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
                        player.ShieldActive();
                        break;

                    case 3:
                        player.AmmoReset();
                        break;

                    case 4:
                        player.HealthReset();
                        break;

                    case 5:
                        player.AutoShotActive();
                        break;

                    case 6:
                        player.SpeedDownActive();
                        break;

                    default:
                        Debug.Log("default");
                        break;

                }

            }

            Destroy(this.gameObject);
        }
    }

    public void PowerCatchTrue()
    {
        pwrCatch = true;
    }



}
