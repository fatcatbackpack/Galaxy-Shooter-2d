using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private float enemyWait;
    [SerializeField]
    private int currentEnemyCount;

    private bool _stopSpawning = false;

    private void Start()
    {
        currentEnemyCount = 0;
        enemyWait = 5.0f;
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        
        while (_stopSpawning == false)
        {

            Vector3 bounds = new Vector3(Random.Range(-9f, 9f), 7.5f, 0f);

            if (currentEnemyCount < 10)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab[0], bounds, Quaternion.identity);

                newEnemy.transform.parent = _enemyContainer.transform;
            }
            
            else if (currentEnemyCount >= 10 && currentEnemyCount < 20)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab[0], bounds, Quaternion.identity);

                newEnemy.transform.parent = _enemyContainer.transform;

                enemyWait = 6.0f;
            }
            else if (currentEnemyCount >= 20)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab[1], bounds, Quaternion.identity);

                newEnemy.transform.parent = _enemyContainer.transform;

                enemyWait = 4.0f;
            }
            else if (currentEnemyCount < 10)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab[1], bounds, Quaternion.identity);

                newEnemy.transform.parent = _enemyContainer.transform;

                enemyWait = 8.0f;
            }


            currentEnemyCount++;

            yield return new WaitForSeconds(enemyWait);

        }

        
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
        Vector3 boundsPU = new Vector3(Random.Range(-9f, 9f), 7.5f, 0f);

            int randomPowerUp = Random.Range(0, powerups.Length);

            yield return new WaitForSeconds(Random.Range(3, 8));

            Instantiate(powerups[randomPowerUp], boundsPU, Quaternion.identity);


        }
    }

    public void OnPLayerDeath()
    {
        _stopSpawning = true;
    }


}
