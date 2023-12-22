using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CprBehavior : MonoBehaviour
{
    public float cprMoveSpeed = 1.0f;

    private void Update()
    {
        MoveRandomly();
    }
    void MoveRandomly()
    {
        // Generate a random direction
        Vector3 randomDirection = new Vector2(Random.Range(-1f, 1f),Random.Range(-1f, 1f)).normalized;

        // Move the object in the random direction
        transform.Translate(randomDirection * cprMoveSpeed * Time.deltaTime);
    }
}
