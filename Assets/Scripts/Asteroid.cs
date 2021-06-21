using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private float _zRot = 3.0f;

    private SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate on z
        MovementAst();
    }

    private void MovementAst()
    {
       
        transform.Rotate(Vector3.forward * _zRot * Time.deltaTime);
    }

    //check for laser coll
    private void OnTriggerEnter2D(Collider2D ExplColl)
    {
        if (ExplColl.tag == "Laser")
        {

            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(ExplColl.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);

        }
    }
    
}
