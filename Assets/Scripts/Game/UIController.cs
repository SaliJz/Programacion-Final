using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance { get { return instance; } }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(int value)
    {
        scoreText.text = $"Score: {value}";
    }
}
