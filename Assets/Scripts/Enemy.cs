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
    

    // Start is called before the first frame update
    void Start()
    {
        _UIupdate = GameObject.Find("Canvas").GetComponent<UIManager>();

        transform.position = new Vector3(Random.Range(-9f, 9f), _upperBound, 0);
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
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }



        if (other.tag == "Laser")
        {
            

            Destroy(other.gameObject);
            _UIupdate.UpScore(10);

            Destroy(this.gameObject);

        }



    }

}
