using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneShapeShift : MonoBehaviour
{
    public GameObject[] differentGameObjects; // Array of different GameObjects
    public float changeInterval = 2f; // Time interval to change the GameObject
    public float fadeDuration = 1.5f; // Duration of the fade effect

    private GameObject currentObject;
    private Coroutine transitionCoroutine;

    void Start()
    {
        // Start the coroutine to change GameObjects at intervals
        StartCoroutine(ChangeGameObjectCoroutine());
    }

    IEnumerator ChangeGameObjectCoroutine()
    {
        while (true)
        {
            yield return FadeOutCurrentObject();

            // Pick a random GameObject from the array
            int randomIndex = Random.Range(0, differentGameObjects.Length);
            GameObject nextObject = differentGameObjects[randomIndex];

            yield return FadeInNextObject(nextObject);

            // Assign the next object as the current object
            currentObject = nextObject;

            // Wait for the specified interval before changing the GameObject again
            yield return new WaitForSeconds(changeInterval);
        }
    }

    IEnumerator FadeOutCurrentObject()
    {
        if (currentObject != null)
        {
            Renderer renderer = currentObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color originalColor = renderer.material.color;
                Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

                float elapsedTime = 0f;

                while (elapsedTime < fadeDuration)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / fadeDuration);
                    renderer.material.color = Color.Lerp(originalColor, targetColor, t);
                    yield return null;
                }
            }

            currentObject.SetActive(false);
        }
    }

    IEnumerator FadeInNextObject(GameObject nextObject)
    {
        if (nextObject != null)
        {
            Renderer renderer = nextObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color originalColor = renderer.material.color;
                Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
                nextObject.SetActive(true);

                float elapsedTime = 0f;

                while (elapsedTime < fadeDuration)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / fadeDuration);
                    renderer.material.color = Color.Lerp(originalColor, targetColor, t);
                    yield return null;
                }
            }
        }
    }
}
