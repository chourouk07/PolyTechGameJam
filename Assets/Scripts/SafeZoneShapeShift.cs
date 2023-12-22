using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneShapeShift : MonoBehaviour
{   
    public GameObject[] differentGameObjects; // Array of different GameObjects
    public float changeInterval = 2f; // Time interval to change the GameObject
    private GameObject currentObject;

    void Start()
    {
        // Start the coroutine to change GameObjects at intervals
        StartCoroutine(ChangeGameObjectCoroutine());
    }

    IEnumerator ChangeGameObjectCoroutine()
    {
        while (true)
        {
            // Disable the current GameObject (if any)
            if (currentObject != null)
            {
                currentObject.SetActive(false);
            }

            // Pick a random GameObject from the array
            int randomIndex = Random.Range(0, differentGameObjects.Length);
            currentObject = differentGameObjects[randomIndex];

            // Enable the selected GameObject
            currentObject.SetActive(true);

            // Wait for the specified interval before changing the GameObject again
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
