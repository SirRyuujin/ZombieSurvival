using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [Header("Customization")]
    public int ScoreAmountForOneSurvivalPoint = 20;
    public float ScoreMultiplierPerMinuteSurvived = 0.1f;

    [Header("References")]
    public IntVariable SessionsSurvivalPoints;
    public IntVariable SessionsScore;
    public IntVariable HighScore;
    public IntVariable SurvivalPoints;
    public FloatVariable Playtime;
    
    [Header("Events")]
    public GameEvent OnChangeScoreEvent;
    public GameEvent OnDisplaySessionSurvivalPointsEvent;

    [Header("Preview")]
    [SerializeField] private float _scoreMultiplier = 0;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;

    private void Start()
    {
        SetSessionScore(0);
        SessionsSurvivalPoints.Value = 0;
    }

    private void SetSessionScore(int value)
    {
        SessionsScore.Value = value;
        OnChangeScoreEvent.Raise();
    }

    public void ChangeScore(EnemyBaseStats enemy)
    {
        SessionsScore.Value += enemy.Score;
        OnChangeScoreEvent.Raise();
    }

    private int CalculateSurvivalPoints()
    {
        return SessionsScore.Value / ScoreAmountForOneSurvivalPoint;
    }

    private void SetScoreMultiplier()
    {
        _scoreMultiplier = 1 + (ScoreMultiplierPerMinuteSurvived * (int)(Playtime.Value / 60));
    }

    public void SetSurvivalPoints()
    {
        SetScoreMultiplier();
        SetSessionScore((int)(SessionsScore.Value * _scoreMultiplier));
        SessionsSurvivalPoints.Value = CalculateSurvivalPoints();
        SurvivalPoints.Value += SessionsSurvivalPoints.Value;
        if (_saveLoadSystem == null)
            _saveLoadSystem = FindObjectOfType<SaveLoadSystem>();

        OnDisplaySessionSurvivalPointsEvent.Raise();
        TrySetNewHighScore();
        _saveLoadSystem.SaveData();
    }

    private void TrySetNewHighScore()
    {
        if (HighScore.Value < SessionsScore.Value)
            HighScore.Value = SessionsScore.Value;
    }
}