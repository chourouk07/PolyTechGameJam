using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1.0f;
    
    private void Update()
    {
        //Character movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(moveDirection * playerSpeed * Time.deltaTime);
    }


}
