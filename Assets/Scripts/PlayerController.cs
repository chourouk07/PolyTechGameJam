using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1.0f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private Rigidbody2D playerRb;

    private void Update()
    {
        //Character movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical);
        playerRb.velocity = (moveDirection * playerSpeed);
    }

    public void IncreasePlayerSpeed(float newSpeed)
    {
        playerSpeed += newSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            Destroy(gameObject,0.5f);
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



}
