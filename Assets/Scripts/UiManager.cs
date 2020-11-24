using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text lives;
    public Text time;
    public Text score;

    private float t = 0;
    private int points = 0;

    private void Start()
    {
        UpdateScore();
    }

    private void Update()
    {
        t += Time.deltaTime;
        time.text = t.ToString("0.00");
    }

    public void AddPoint(int n)
    {
        points += n;

        UpdateScore();
    }

    private void UpdateScore()
    {
        score.text = points.ToString("0");
    }
}
