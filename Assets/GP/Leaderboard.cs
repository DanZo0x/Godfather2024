using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private HightScoreData scoreData;
    private string _filePath = Application.persistentDataPath + "/HightScore.json";
    public int value;
    public Text _score;

    public static Leaderboard instance;

    private void Awake()
    {
        if (!System.IO.File.Exists(_filePath))
        {
            Load();
        }
    }

    private void Start()
    {
        instance = this;
    }

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
    public void Save()
    {
        int[] saveInt = scoreData.scores;
        scoreData.scores = new int[scoreData.scores.Length + 1];
        for (int i = 0;i < saveInt.Length;i++)
        { 
            scoreData.scores[i] = saveInt[i]; 
        }
        scoreData.scores[scoreData.scores.Length-1] = value;
        string save = JsonUtility.ToJson(scoreData);
        System.IO.File.WriteAllText(_filePath, save);
    }
    public void Load()
    {
        string save = System.IO.File.ReadAllText(_filePath);
        scoreData = JsonUtility.FromJson<HightScoreData>(save);
    }
}

[System.Serializable]
public class HightScoreData
{
    public int[] scores;
}
