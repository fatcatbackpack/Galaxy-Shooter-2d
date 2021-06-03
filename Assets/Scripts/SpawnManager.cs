using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());


    }
    

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            

            Vector3 bounds = new Vector3(Random.Range(-9f, 9f), 7.5f, 0f);

            GameObject newEnemy = Instantiate(_enemyPrefab, bounds, Quaternion.identity);

            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5.0f);
        }

    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
        Vector3 boundsPU = new Vector3(Random.Range(-9f, 9f), 7.5f, 0f);

            int randomPowerUp = Random.Range(0, 3);

            yield return new WaitForSeconds(Random.Range(3, 8));

            Instantiate(powerups[randomPowerUp], boundsPU, Quaternion.identity);


        }
    }

    public void OnPLayerDeath()
    {
        _stopSpawning = true;
    }


}
