using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public GameObject objectToPool;
    public List<GameObject> pooledObjects;
    public int amountToPool = 15;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        // Pre-crear objetos en el pool
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject go = Instantiate(objectToPool);
            go.transform.rotation = objectToPool.transform.rotation;
            go.SetActive(false); // Inicialmente inactivos
            pooledObjects.Add(go);
        }
    }

    // Devuelve un objeto disponible en el pool
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i]; // Retorna el primer objeto inactivo
        }
        return null; // Si no hay objetos disponibles, retorna null
    }
}
