using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _downSpeed = 4f;

    private float _lowerBound = -5.5f;
    private float _upperBound = 7.5f;

    private UIManager _UIupdate;

    //handle to anim
    
    [SerializeField]
    private Animator _enemyDestruction;
    private AudioSource _audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        _UIupdate = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();

        if(_UIupdate == null)
        {
            Debug.LogError("Enemy:: _UIupdate");
        }

        transform.position = new Vector3(Random.Range(-9f, 9f), _upperBound, 0);

        
        _enemyDestruction = GetComponent<Animator>();

        if(_enemyDestruction == null)
        {
            Debug.LogError("Enemy:: _enemyDestruction");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyDownSpeed = Vector3.down* _downSpeed*Time.deltaTime;

        transform.Translate(enemyDownSpeed);

        if (transform.position.y <= _lowerBound)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, _upperBound, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = GetComponent<Enemy>();

        enemy.GetComponent<BoxCollider2D>().enabled = false;



        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            EnemyDestroyAnim();
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);
        }



        if (other.tag == "Laser")
        {
            

            Destroy(other.gameObject);
            _UIupdate.UpScore(10);
            
            EnemyDestroyAnim();
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);
        }

        

    }


    private void EnemyDestroyAnim()
    {
        _enemyDestruction.SetTrigger("OnEnemyDeath");
        _downSpeed = 0;
    }
}
