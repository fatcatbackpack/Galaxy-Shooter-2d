using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Elite : MonoBehaviour
{
    [SerializeField]
    private float _downSpeed = 1.5f;
    [SerializeField]
    private float _sideSpeed = 1.5f;
    [SerializeField]
    private float _xPos;

    private bool stillAlive = true;

    private float _lowerBound = -5.5f;
    private float _upperBound = 7.5f;
    private float _sideBoundL = -11.5f;
    private float _sideBoundR = 11.5f;
    [SerializeField]
    private int randDir;

    private UIManager _UIupdate;
    private Laser _laserScript;

    //handle to anim

    [SerializeField]
    private Animator _enemyDestruction;
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _laserSound;

    [SerializeField]
    GameObject _enemyLaserPrefab;

    private float _fireRate = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        _UIupdate = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();

        randDir = Random.Range(0, 2) * 2 - 1;

        StartCoroutine(startFiring());

        if (_UIupdate == null)
        {
            Debug.LogError("Enemy:: _UIupdate");
        }

        transform.position = new Vector3(Random.Range(-9f, 9f), _upperBound, 0);


        _enemyDestruction = GetComponent<Animator>();

        if (_enemyDestruction == null)
        {
            Debug.LogError("Enemy:: _enemyDestruction");
        }

        _xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();


        //if ((Time.time > _canFire) && (stillAlive == true))
        //{
           // _fireRate = Random.Range(3.0f, 7.0f);
           // _canFire = Time.time + _fireRate;
           // GameObject enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
           // Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
           //
           // for (int i = 0; i < lasers.Length; i++)
           // {
           //    lasers[i].AssignEnemyLaser();
           // }
        //}

    }

    IEnumerator startFiring()
    {
        _fireRate = Random.Range(2.0f, 5.0f);
        

        yield return new WaitForSeconds(_fireRate);
        GameObject enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
        Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

        for (int i = 0; i < lasers.Length; i++)
             {
                lasers[i].AssignEnemyLaser();
             }

        yield return new WaitForSeconds(.2f);

        enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
        lasers = enemyLaser.GetComponentsInChildren<Laser>();

        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].AssignEnemyLaser();
        }

        yield return new WaitForSeconds(.2f);
        enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
        lasers = enemyLaser.GetComponentsInChildren<Laser>();

        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].AssignEnemyLaser();
        }
    }

    void CalculateMovement()
    {
        Vector3 enemyDownSpeed = new Vector3(_sideSpeed * randDir, -_downSpeed, 0) * Time.deltaTime;



        transform.Translate(enemyDownSpeed);

        if (transform.position.y <= _lowerBound)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, _upperBound, 0);
        }

        if (transform.position.x < _sideBoundL)
        {
            transform.position = new Vector3(_sideBoundR, transform.position.y, 0);
        }

        if (transform.position.x > _sideBoundR)
        {
            transform.position = new Vector3(_sideBoundL, transform.position.y, 0);
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
