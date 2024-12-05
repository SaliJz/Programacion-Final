using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    public static PlayerManager Instance {  get { return instance; } }

    // Variables públicas y estáticas
    public static bool isGameStarted;
    public static int score;

    // Variables privadas serializadas
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startingText;

    // Variables privadas
    private int coinsCollected;
    private float startTime;

    private void Start()
    {
        instance = this;
        // Inicializar variables
        coinsCollected = 0;
        score = 0;
        isGameStarted = false;

        Time.timeScale = 1;
    }

    private void Update()
    {
        // Iniciar el juego con clic
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isGameStarted)
        {
            isGameStarted = true;
            startTime = Time.time; // Guardar el tiempo de inicio
            Destroy(startingText);
        }

        // Calcular y actualizar puntaje si el juego está en marcha
        if (isGameStarted)
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        // Calcular puntaje como suma de monedas recolectadas y tiempo jugado
        float timePlayed = Time.time - startTime;
        score = coinsCollected + Mathf.FloorToInt(timePlayed);
        scoreText.text = $"Score: {score.ToString()}";

        // Actualizar el texto de puntaje
        coinText.text = $"Coins: {coinsCollected.ToString()}";
    }

    // Método para agregar monedas al puntaje
    public void AddCoins(int amount)
    {
        coinsCollected += amount;
        UpdateScore();
    }
}