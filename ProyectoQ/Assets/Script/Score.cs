using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int points = 0;
    TextMeshProUGUI score;

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = "Score: " + points;

    }
}
