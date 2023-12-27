using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShiftController : MonoBehaviour
{
    public GameObject[] differentGameObjects;
    [SerializeField] private GameObject nextObject;
    public float changeInterval = 2f;

    [SerializeField]private GameObject currentObject;
    [SerializeField] private Animator currentAnimator;

    private const int RectangleIndex = 0;
    private const int CircleIndex = 1;
    private const int PolygonIndex = 2;
    int randomIndex;
    int previousIndex;

    private void Start()
    {
        currentObject = differentGameObjects[0];
        currentObject.SetActive(true);
        InvokeRepeating("ChangeGameObject", 0f, changeInterval);
    }

    private void ChangeGameObject()
    {

        
        previousIndex = -1;
        do
        {
            randomIndex = Random.Range(0, 3);
        } while (randomIndex == previousIndex);
        
        
        nextObject = differentGameObjects[randomIndex];

         // Play the appropriate animation based on the random index
         if (randomIndex == RectangleIndex)
         {
             currentAnimator.Play("SquareToCircle");
         }
         else if (randomIndex == CircleIndex)
         {
             currentAnimator.Play("CircleToSquare");
         }
         else if (randomIndex == PolygonIndex)
         {
             currentAnimator.Play("SquareToPoly");
         }
    }


    public void EnableNextObject()
    {
        nextObject.SetActive(true);
        currentObject = nextObject;
    }
}
