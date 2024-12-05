using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    [SerializeField] private GameObject gameOverPanel;

    public static bool isGameStarted;
    [SerializeField] private GameObject startingText;
    [SerializeField] private GameObject newRecordPanel;

    public static int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private TextMeshProUGUI newRecordText;

    public static bool isGamePaused;
    [SerializeField] private GameObject[] characterPrefabs;

    private AdManager adManager;

    private void Awake()
    {
        int index = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject go = Instantiate(characterPrefabs[index], transform.position, Quaternion.identity);
        adManager = FindObjectOfType<AdManager>();
    }

    void Start()
    {
        score = 0;
        Time.timeScale = 1;
        gameOver = isGameStarted = isGamePaused= false;
        /*
        adManager.RequestBanner();
        adManager.RequestInterstitial();
        adManager.RequestRewardBasedVideo();
        */
    }

    void Update()
    {
        //Actualiza el HUD
        gemsText.text = PlayerPrefs.GetInt("TotalGems", 0).ToString();
        scoreText.text = score.ToString();

        //Pantalla de derrota
        if (gameOver)
        {
            Time.timeScale = 0;
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                newRecordPanel.SetActive(true);
                newRecordText.text = "New \nRecord\n" + score;
                PlayerPrefs.SetInt("HighScore", score);
            }
            else
            {
                /*
                int i = Random.Range(0, 6);
                if (i == 0)
                {
                    adManager.ShowInterstitial();
                }
                else if (i == 3)
                {
                    adManager.ShowRewardBasedVideo();
                }
                */
            }
            
            gameOverPanel.SetActive(true);
            Destroy(gameObject);
        }

        //Iniciar juego
        if (Input.GetKeyDown(KeyCode.Mouse0)  && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}