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
    #region Spawn Positions
    [SerializeField] private Transform initDownpos;
    [SerializeField] private Transform initSideObs;
    [SerializeField] private Transform[] randomObsSpawnPts;
    #endregion

    #region
    public int obstacleCountDown= 4;
    public int obstacleCountSide= 0;
    #endregion


    void Start()
    {
        // Call methods to spawn obstacles based on your game logic
        //SpawnDownwardObstacles();
        SpawnHorizontalObstacles();
        //SpawnRandomObstacles();
    }

    void SpawnDownwardObstacles()
    {
        float xSpawnPosition = initDownpos.position.x;
        for (int i = 0; i <= obstacleCountDown; i++)
        {    
            Vector2 spawnpos = new Vector2(xSpawnPosition, initDownpos.position.y);
            Instantiate(downwardObsPrefab,spawnpos, Quaternion.identity);
            xSpawnPosition += 4f;
        }
    }

    void SpawnHorizontalObstacles()
    {
        float ySpawnPosition = initSideObs.position.y;
        for (int i = 0; i <= obstacleCountSide; i++)
        {
            Vector2 spawnpos = new Vector2(initSideObs.position.x,ySpawnPosition);
            GameObject obstacle = Instantiate(sideObsPrefab,spawnpos, Quaternion.identity);
            ySpawnPosition -= 4f;
        }
    }

    void SpawnRandomObstacles()
    {
        
        /*for (int i = 0; i <= randomObsSpawnPts.Length; i++)
        {
            Vector2 spawnpos = new Vector2(randomObsSpawnPts[i].position.x, randomObsSpawnPts[i].position.y );
            GameObject obstacle = Instantiate(ran, spawnpos, Quaternion.identity);
            ySpawnPosition -= 4f;
        }*/
    }
}
