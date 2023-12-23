using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Prefabs
    [SerializeField] private GameObject downwardObsPrefab;
    [SerializeField] private GameObject sideObsPrefab;
    [SerializeField] private GameObject randomObsPrefab;
    #endregion
    #region Transforms
    [SerializeField] private Transform initDownpos;
    [SerializeField] private Transform initSideObs;
    [SerializeField] private Transform[] randomObsSpawnPts;
    #endregion
    #region Obstacles Number
    [SerializeField] private int obstacleCountDown = 4;
    [SerializeField] private int obstacleCountSide = 0;
    #endregion
    #region 
    public float spawnDelay = 8f;
    private Coroutine spawnCoroutine; 
    #endregion
    


    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnDelay(spawnDelay));
    }

    void SpawnDownwardObstacles()
    {
        float xSpawnPosition = initDownpos.position.x;
        for (int i = 0; i < obstacleCountDown; i++)
        {
            Vector2 spawnpos = new Vector2(xSpawnPosition, initDownpos.position.y);
            Instantiate(downwardObsPrefab, spawnpos, Quaternion.identity);
            xSpawnPosition += 4f;
        }
    }

    void SpawnHorizontalObstacles()
    {
        float ySpawnPosition = initSideObs.position.y;
        for (int i = 0; i < obstacleCountSide; i++)
        {
            Vector2 spawnpos = new Vector2(initSideObs.position.x, ySpawnPosition);
            Instantiate(sideObsPrefab, spawnpos, Quaternion.identity);
            ySpawnPosition -= 4f;
        }
    }

    void SpawnRandomObstacles()
    {

        for (int i = 0; i < randomObsSpawnPts.Length; i++)
        {
            Vector2 spawnpos = new Vector2(randomObsSpawnPts[i].position.x, randomObsSpawnPts[i].position.y);
            Instantiate(randomObsPrefab, spawnpos, Quaternion.identity);
        }
    }

    IEnumerator SpawnDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            SpawnObstacles();
        }
    }

    void SpawnObstacles()
    {
        int previousIndex = -1;
        int randomIndex;
            do
            {
                randomIndex = Random.Range(0, 3);
            } while (randomIndex == previousIndex);

            previousIndex = randomIndex;

            switch (randomIndex)
            {
                case 0:
                    SpawnDownwardObstacles();
                    break;

                case 1:
                    SpawnHorizontalObstacles();
                    break;
                case 2:
                    SpawnRandomObstacles();
                    break;
                default: break;
            }
    }

    public void IncreaseSpawnDelay(float newDelay)
    {
        // Stop the existing coroutine
        

        // Increase the spawn delay
        spawnDelay += newDelay;

        // Start a new coroutine with the updated delay
        
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = StartCoroutine(SpawnDelay(spawnDelay));
        }
    }

    public float GetSpawnDelay()
    {
        return spawnDelay;
    }

}
