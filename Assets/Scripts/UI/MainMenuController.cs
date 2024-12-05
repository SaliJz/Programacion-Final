using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class MainMenuController : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelPanel;

    [Header("Botones")]
    [SerializeField] private TMP_InputField usernameInputField;

    [SerializeField] private Button startButton;

    [SerializeField] private Button normalLevelButton;
    [SerializeField] private string normalName;

    [SerializeField] private Button hardLevelButton;
    [SerializeField] private string hardName;

    [SerializeField] private Button backButton;
    [SerializeField] private Button quitButton;

    [Header("Fuente")]
    [SerializeField] private AudioSource fxSource;

    [Header("Sonido")]
    [SerializeField] private AudioClip clickSound;

    private void Awake()
    {
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        startButton.onClick.AddListener(StartGame);

        normalLevelButton.onClick.AddListener(ChargeNormalLevel);
        hardLevelButton.onClick.AddListener(ChargeHardLevel);

        backButton.onClick.AddListener(BackButton);
        quitButton.onClick.AddListener(QuitGame);
    }
    private void StartGame()
    {
        PlaySoundButton();
        menuPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    private void ChargeNormalLevel()
    {
        PlaySoundButton();
        GameDataUsers.username = usernameInputField.text;
        SceneManager.LoadScene(normalName);
    }

    private void ChargeHardLevel()
    {
        PlaySoundButton();
        GameDataUsers.username = usernameInputField.text;
        SceneManager.LoadScene(hardName);
    }

    private void BackButton()
    {
        PlaySoundButton();
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    private void QuitGame()
    {
        PlaySoundButton();
        Application.Quit();
    }

    private void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
}