using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private HighScoreData scoreData;
    private string _filePath;
    public int value;
    public Text _score;
    public Text[] scoreTexts;

    public static Leaderboard instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _filePath = Application.persistentDataPath + "/HightScore.json";
        if (System.IO.File.Exists(_filePath))
        {
            Load();
        }
        else
        {
            scoreData = new HighScoreData(); // Initialize in case file doesn't exist
            scoreData.scores = new int[0]; // Initialize empty score array
        }

        UpdateLeaderboardUI();
    }

    private void Start()
    {
        instance = this;
        _score.text = value.ToString();
    }

    //Constructeur
    public Leaderboard()
    {
        value = 0;
    }
    //Sans constructeur, la valeur initiale pourrait être indéfinie ou laissée à 0 par défaut, mais il est préférable d'être explicite.

    public void AddPoints(int points)
    {
        if (value >= 0)
        {
            value += points;
        }
        _score.text = value.ToString();
    }

    public void Reset()
    {
        value = 0;
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

        // Trie les scores en ordre décroissant
        System.Array.Sort(scoreData.scores);
        System.Array.Reverse(scoreData.scores);

        string save = JsonUtility.ToJson(scoreData);
        System.IO.File.WriteAllText(_filePath, save);

        // Met à jour l'affichage des meilleurs scores
        UpdateLeaderboardUI();
    }
    public void Load()
    {
        if (System.IO.File.Exists(_filePath))  // Check if file exists before loading
        {
            string save = System.IO.File.ReadAllText(_filePath);
            scoreData = JsonUtility.FromJson<HighScoreData>(save);
        }
        else
        {
            scoreData = new HighScoreData(); // Initialize if file doesn't exist
            scoreData.scores = new int[0];

            // Met à jour les meilleurs scores affichés après chargement
            UpdateLeaderboardUI();
        }
    }

    // Méthode pour mettre à jour l'affichage des meilleurs scores
    public void UpdateLeaderboardUI()
    {
        // Trie les scores en ordre décroissant
        System.Array.Sort(scoreData.scores);
        System.Array.Reverse(scoreData.scores);

        // Met à jour les champs de texte pour afficher les scores
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scoreData.scores.Length)
            {
                scoreTexts[i].text = (i + 1) + ". " + scoreData.scores[i].ToString();
            }
            else
            {
                scoreTexts[i].text = (i + 1) + ". ---";  // Si pas de score, affiche "---"
            }
        }
    }
}

[System.Serializable]
public class HighScoreData
{
    public int[] scores;
}
