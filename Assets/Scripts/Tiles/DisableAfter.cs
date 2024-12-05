using UnityEngine;

public class DisableAfter : MonoBehaviour
{
    private float timer = 0f;
    public float delay = 0.7f;

    private void OnEnable()
    {
        timer = 0f; // Reinicia el temporizador cada vez que el objeto se activa
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Desactiva el objeto solo cuando el temporizador haya pasado el tiempo de retraso
        if (timer >= delay)
        {
            gameObject.SetActive(false); // Desactiva el objeto después del delay
        }
    }
}
