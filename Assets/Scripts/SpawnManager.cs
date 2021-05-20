using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //Spawn enemies every 5 seconds
    //create a coroutine IEnumerator -- yield events
    //while loop

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            

            Vector3 bounds = new Vector3(Random.Range(-9f, 9f), 7.5f, 0f);

            GameObject newEnemy = Instantiate(_enemyPrefab, bounds, Quaternion.identity);

            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5.0f);
        }

    }

    public void OnPLayerDeath()
    {
        _stopSpawning = true;
    }


}
