using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject[] gemContainers; // Contenedores de gemas en el tile

    private void OnEnable()
    {
        // Por cada contenedor de gemas en el tile
        foreach (GameObject container in gemContainers)
        {
            int i = Random.Range(0, 3); // Aleatoriza si hay gemas o no
            bool shouldActivate = i == 0; // Activa gemas con una probabilidad

            container.SetActive(shouldActivate); // Si la probabilidad es 0, activa el contenedor
            if (shouldActivate)
            {
                // Activamos las gemas dentro del contenedor
                foreach (Transform gem in container.transform)
                {
                    gem.gameObject.SetActive(true);
                }
            }
            else
            {
                // Desactiva todas las gemas en el contenedor
                foreach (Transform gem in container.transform)
                {
                    gem.gameObject.SetActive(false);
                }
            }
        }
    }
}
