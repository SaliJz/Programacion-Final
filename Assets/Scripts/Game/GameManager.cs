using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private int score;
    [SerializeField] private string sceneName;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIController.Instance.UpdateScore(score);
    }

    public void IncreaseScore()
    {
        score++;
        UIController.Instance.UpdateScore(score);
    }

    public void GameOver()
    {
        GameData.score = score;
        SceneManager.LoadScene(sceneName);
    }
}
