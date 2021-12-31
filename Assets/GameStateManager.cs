using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private QuestionManager _questionManager;

    private void Start()
    {
        _questionManager = GetComponent<QuestionManager>();
        _questionManager.OnGameWin += () =>  Invoke(nameof(RestartGame), 4f); 
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}