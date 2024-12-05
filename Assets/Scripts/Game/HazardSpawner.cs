using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject hazardPrefab;
    [SerializeField] private float verticalRandomOffset;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            GameObject obj = Instantiate(hazardPrefab);
            obj.transform.position = transform.position + Vector3.up * Random.Range(-verticalRandomOffset, verticalRandomOffset);
            
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
