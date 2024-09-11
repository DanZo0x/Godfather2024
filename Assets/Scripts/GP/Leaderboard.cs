using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public int value;
    public Text _score;

    //Constructeur
    public Leaderboard()
    {
        value = 0;
    }
    //Sans constructeur, la valeur initiale pourrait être indéfinie ou laissée à 0 par défaut, mais il est préférable d'être explicite.

    public void AddPoints(int points)
    {
        if (value > 0)
        {
            value += points;
        }
    }

    public void Reset()
    {
        value = 0;
    }

    private void Update()
    {
        _score.text = value.ToString();
        Debug.Log(value);
    }
}
