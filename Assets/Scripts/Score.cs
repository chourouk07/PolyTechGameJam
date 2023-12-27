using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0 ;

    private void Start()
    {
        score = 0 ;
    }

    private void Update()
{
    TMPro.TextMeshProUGUI textComponent = GetComponent<TMPro.TextMeshProUGUI>();
    if (textComponent != null)
    {
        textComponent.text = score.ToString();
    }
}

}
