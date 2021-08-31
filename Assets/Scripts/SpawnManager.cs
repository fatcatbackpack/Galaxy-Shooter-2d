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
    int randomPowerUp;

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
        while (_stopSpawning == false)
        {

        Vector3 boundsPU = new Vector3(Random.Range(-9f, 9f), 7.5f, 0f);

            yield return new WaitForSeconds(Random.Range(3, 8));
            int random = Random.Range(0, 101);
            
            //3shot 0
            if (random < 11)
            {
                randomPowerUp = 0;
            }
            //speed 1
            else if (random >= 11 && random < 26)
            {
                randomPowerUp = 1;
            }
            //shield 2
            else if (random >= 26 && random < 41)
            {
                randomPowerUp = 2;
            }
            //ammo 3
            else if (random >= 41 && random < 66)
            {
                randomPowerUp = 3;
            }
            //health 4
            else if (random >= 66 && random < 81)
            {
                randomPowerUp = 4;
            }
            //autoshot 5
            else if (random >= 81 && random < 91)
            {
                randomPowerUp = 5;
            }
            //slow 6
            else if (random >= 91 && random < 101)
            {
                randomPowerUp = 6;
            }

            Instantiate(powerups[randomPowerUp], boundsPU, Quaternion.identity);


        }
    }

    public void OnPLayerDeath()
    {
        _stopSpawning = true;
    }


}
