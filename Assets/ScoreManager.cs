using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
    static ScoreManager _instance = new ScoreManager();
    public static ScoreManager Instance => _instance;
    private ScoreManager() { }

    int _score = 0;

    [SerializeField] Text _text;

    void Update()
    {
        _text.text = ScoreManager.Instance.GetScore().ToString();
    }

    public void AddScore(int score)
    {
        _score += score;
    }
    public int GetScore()
    {
        return _score;
    }
}
