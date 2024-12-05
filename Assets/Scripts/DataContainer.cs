using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dataText;

    public void SetText(string data)
    {
        dataText.text = data;
    }
}
