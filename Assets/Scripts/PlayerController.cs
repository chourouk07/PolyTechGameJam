using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1.0f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator animator;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject deathVfx;
    private bool isInSafeZone = true;
    private bool leftSafeZone = false;


    private void Update()
    {
        //Character movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical);
        playerRb.velocity = (moveDirection * playerSpeed);
        
        if (!isInSafeZone)
        {
            //wait 1 second before turning the isSafeZone false
            //if the 1second passes and player still outside the safe zone than setdeath

            StartCoroutine(DeathDelay());
            if (leftSafeZone)
            {
                SetDeath();
            }
        }
    }

    public void IncreasePlayerSpeed(float newSpeed)
    {
        playerSpeed += newSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            collision.gameObject.SetActive(false);
            SetDeath();
        }
        else if (collision.CompareTag("SafeZone"))
        {
            isInSafeZone = true;
        }
    }
    #region getters and setters
    public float GetSpeed()
    {
        return playerSpeed;
    }
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
    #endregion

    public void SetDeath()
    {
        //animator.Play("DeathAnim");
        Instantiate(deathVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(0.1f);
        if (!isInSafeZone)
        {
           
            leftSafeZone = true;
        }
        else { leftSafeZone = false; }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SafeZone"))
        {
            isInSafeZone = false;
        }
    }


}
