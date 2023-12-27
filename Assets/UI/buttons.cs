using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoard;
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void ShowScoreBoard()
    {
        scoreBoard.SetActive(true);
    }

    public void BackToMain()
    {
        scoreBoard.SetActive(false);
    }
}
