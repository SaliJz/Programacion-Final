using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Game1
{
    public class ChangeSceneButton : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ChangeScene);
        }

        private void ChangeScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}