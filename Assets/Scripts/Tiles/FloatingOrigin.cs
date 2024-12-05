using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float threshold = 100.0f; // Umbral para el cambio de origen

    void FixedUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = 0f;

        // Si la posición de la cámara excede el umbral, se reinicia el origen
        if (cameraPosition.magnitude + 10 >= threshold)
        {
            cameraPosition.z += 10;
            // Mueve todos los objetos con la capa 9
            foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (g.layer == 9)
                {
                    g.transform.position -= cameraPosition; // Ajusta la posición
                }
            }
        }
    }
}