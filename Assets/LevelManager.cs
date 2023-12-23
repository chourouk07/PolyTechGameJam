using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region externals
    [SerializeField] private PlayerController characterController;
    [SerializeField] private SpawnManager spawnManager;
    #endregion

    #region varibles
    [SerializeField] private float speedIncreaseInterval = 10f;
    [SerializeField] private float speedIncreaseAmount = 0.5f;
    [SerializeField] private float delayIncreaeAmount = 0.5f;
    private float timer = 0;
    #endregion

    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>= speedIncreaseInterval)
        {
            if (characterController.GetSpeed() <= characterController.GetMaxSpeed())
            {
                characterController.IncreasePlayerSpeed(speedIncreaseAmount);
                timer = 0;
                
            }
            if (spawnManager.GetSpawnDelay() > 1)
            {
                spawnManager.IncreaseSpawnDelay(-1f);
            }
        }
    }
}
