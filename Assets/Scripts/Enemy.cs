using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _downSpeed = 1f;
    [SerializeField]
    private float _sideSpeed = 1f;
    [SerializeField]
    private float _xPos;
    [SerializeField]
    private float _ramBound = -7.0f;

    private bool stillAlive = true;

    private float _lowerBound = -5.5f;
    private float _upperBound = 7.5f;

    private UIManager _UIupdate;
    private Laser _laserScript;

    //handle to anim
    
    [SerializeField]
    private Animator _enemyDestruction;
    private AudioSource _audioSource;

    [SerializeField]
    GameObject _enemyLaserPrefab;

    private float _fireRate = 3.0f;
    private float _canFire = -1.0f;

    Transform _playerVec;
    Vector3 _EnemyVec;

    Vector3 enemyDownSpeed;


    // Start is called before the first frame update
    void Start()
    {
        _UIupdate = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        _playerVec = GameObject.Find("Player").transform;


        if (_UIupdate == null)
        {
            Debug.LogError("Enemy:: _UIupdate");
        }

        transform.position = new Vector3(Random.Range(-9f, 9f), _upperBound, 0);

        
        _enemyDestruction = GetComponent<Animator>();

        if(_enemyDestruction == null)
        {
            Debug.LogError("Enemy:: _enemyDestruction");
        }

        _xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        _EnemyVec = transform.position;

        float enemyY = _EnemyVec.y;
        float playerY = _playerVec.position.y;

        CalculateMovement();

        if ((Time.time > _canFire) && (stillAlive == true && (enemyY >= playerY)))
        {
            _fireRate = Random.Range(3.0f, 7.0f);
            _canFire = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
        else if ((Time.time > _canFire) && (stillAlive == true && (enemyY < playerY)))
        {
            _fireRate = Random.Range(3.0f, 7.0f);
            _canFire = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_enemyLaserPrefab, new Vector3(transform.position.x, transform.position.y + 2.8f, 0f), Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaserUp();
            }
        }
    }

    void CalculateMovement()
    {
        
        if ((Vector3.Distance(_EnemyVec, _playerVec.position)) < _ramBound)
        {
            enemyDownSpeed = Vector3.MoveTowards(_EnemyVec, _playerVec.position, _downSpeed * Time.deltaTime);
            transform.position = enemyDownSpeed;
        }

        else if ((Vector3.Distance(_EnemyVec, _playerVec.position)) >= _ramBound)
        {
            enemyDownSpeed = new Vector3(_sideSpeed, -_downSpeed, 0) * Time.deltaTime;
            transform.Translate(enemyDownSpeed);
        }
        

        if (transform.position.y <= _lowerBound)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, _upperBound, 0);
        }

        if (transform.position.x <= (_xPos - 2))
        {
            _sideSpeed = -_sideSpeed;
        }
        if (transform.position.x >= (_xPos + 2))
        {
            _sideSpeed = -_sideSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = GetComponent<Enemy>();



        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            EnemyDestroyAnim();
            _audioSource.Play();
            enemy.GetComponent<BoxCollider2D>().enabled = false;
            stillAlive = false;
            Destroy(this.gameObject, 2.8f);
        }



        if (other.tag == "Laser")
        {
            

            Destroy(other.gameObject);
            _UIupdate.UpScore(10);
            
            EnemyDestroyAnim();
            _audioSource.Play();
            enemy.GetComponent<BoxCollider2D>().enabled = false;
            stillAlive = false;
            Destroy(this.gameObject, 2.8f);
        }

    }


    private void EnemyDestroyAnim()
    {
        _enemyDestruction.SetTrigger("OnEnemyDeath");
        _downSpeed = 0;
    }

}
