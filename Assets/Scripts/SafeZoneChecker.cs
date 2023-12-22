using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Safe Zone!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("DEAAAAAAAAAAAD");
        }
    }
}
