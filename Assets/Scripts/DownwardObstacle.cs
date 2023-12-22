using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardObstacle : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move the obstacle downward
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
