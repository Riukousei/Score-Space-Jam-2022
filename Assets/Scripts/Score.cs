using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scorePoints,maxScorePoints;
    public int points=0;
    public float scoreM=1;
    public float MaxScorePoints;
    // Start is called before the first frame update
    public void addPoints(int p)
    {
        points = points + Mathf.RoundToInt(scoreM*p);
        updateScorepoints();
        if (points > MaxScorePoints)
        {
            MaxScorePoints = points;
            maxScorePoints.text = MaxScorePoints.ToString();
        }
    }

    public void removePoints(int p)
    {
        points = points - Mathf.RoundToInt(scoreM * p);
        updateScorepoints();
    }

    public void updateScorepoints()
    {
        scorePoints.text = points.ToString();
    }
}
