using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   
    public float scoreValue = 0f;
    public float pointIncreasedPerSec = 1f;
    public GameObject playerPrefab;
    public GameObject gameOverUI;
    private bool isScoreActive = true;
    public Animator scoreAnim;
    #region externals
    [SerializeField] private PlayerController characterController;
    [SerializeField] private SpawnManager spawnManager;
    public TextMeshProUGUI ScoreValueText;
    public GameObject[] Stars;
    #endregion

    #region varibles
    [SerializeField] private float speedIncreaseInterval = 10f;
    [SerializeField] private float speedIncreaseAmount = 0.5f;
    [SerializeField] private float delayIncreaeAmount = 0.5f;
    private float timer = 0;
    #endregion


    void FixedUpdate()
    {
        ScoreValueText.text = ((int)scoreValue).ToString();
        if (isScoreActive)
        {
            scoreValue += pointIncreasedPerSec * Time.fixedDeltaTime;
        }
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
            if (spawnManager.GetSpawnDelay() > 3)
            {
                spawnManager.IncreaseSpawnDelay(-1f);
            }
        }

        if (IsPlayerDestroyed())
        {
            isScoreActive = false;
            StartCoroutine(GameOverDelay());
        }
    }

    private bool IsPlayerDestroyed()
    {
       
        return GameObject.FindGameObjectWithTag("Player") == null;
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverUI.SetActive(true);
        spawnManager.SetIsGameRunning(false);
        scoreAnim.Play("ScoreAnimation");
        
        if (scoreValue < 100)
        {
            Stars[0].SetActive(true);
        }
        if (scoreValue<200 && scoreValue >100)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
        }
        if (scoreValue > 200)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
            Stars[2].SetActive(true);   
        }
    }

    public void RestartLevelAfterDelay()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene("Test03");
    }
}

