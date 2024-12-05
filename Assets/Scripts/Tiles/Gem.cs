using UnityEngine;

public class Gem : MonoBehaviour
{
    private PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Activar efecto visual desde el pool
            GameObject effect = ObjectPool.instance.GetPooledObject();
            if (effect != null)
            {
                effect.transform.position = transform.position;
                effect.transform.rotation = Quaternion.identity; // Rotación estándar
                effect.SetActive(true);
            }

            // Actualizar el puntaje y recolectar la gema
            playerManager.AddCoins(2);
            gameObject.SetActive(false);
        }
    }
}
