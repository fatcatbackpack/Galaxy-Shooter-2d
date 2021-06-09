using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    private float speedBoost = 10f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _TripleShotPrefab;
    [SerializeField]
    private float _fireRate = .15f;
    private float _canFire = -1.0f;

    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnmanager;
    
    private bool _isTripleShotActive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldActive = false;

    [SerializeField]
    GameObject _shield;

    [SerializeField]
    private int _score;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _spawnmanager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        
        if (_spawnmanager == null)
        {
            Debug.LogError("spawn not working");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }


    }


    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        if (_isSpeedBoostActive == true)
        {
            transform.Translate(direction * speedBoost * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
            _canFire = Time.time + _fireRate;

        if (_isTripleShotActive == true)
        {
            Instantiate(_TripleShotPrefab, transform.position + new Vector3(-1.25f, -1.05f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }   

    }

    public void Damage()
    {
        if (_isShieldActive == true)
        {
            StopCoroutine(PowerDownRoutine());
            _isShieldActive = false;
            _shield.SetActive(false);
            return;
        }

        
        
         _lives--;

         if (_lives < 1)
            {
                _spawnmanager.OnPLayerDeath();

                Destroy(this.gameObject);
            }
        
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        
        StartCoroutine (PowerDownRoutine());

    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;

        StartCoroutine(PowerDownRoutine());

    }

    public void ShieldActive()
    {
        _isShieldActive = true;

        StartCoroutine(PowerDownRoutine());
        _shield.SetActive(true);
    }

    IEnumerator PowerDownRoutine()
    {
        while (_isTripleShotActive == true)
        {
            yield return new WaitForSeconds(5.0f);
            _isTripleShotActive = false;

        }
        while (_isSpeedBoostActive == true)
        {
            yield return new WaitForSeconds(5.0f);
            _isSpeedBoostActive = false;
        }
        while (_isShieldActive == true)
        {
            yield return new WaitForSeconds(5.0f);
            _isShieldActive = false;
            _shield.SetActive(false);
        }

    }


}
