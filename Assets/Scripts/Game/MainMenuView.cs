using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button startButton;
    [SerializeField] private string sceneName;

    private void Awake()
    {
        startButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameData.username=usernameInputField.text;
        SceneManager.LoadScene(sceneName);
    }

}
