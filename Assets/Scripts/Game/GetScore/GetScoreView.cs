using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Proyecto_final
{
    public class GetScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI usernameText;
        [SerializeField] private TextMeshProUGUI oldScoreText;
        [SerializeField] private TextMeshProUGUI newScoreText;
        private GetScoreController controller;

        private void Awake()
        {
            controller = GetComponent<GetScoreController>();
            controller.Execute(GameData.username, OnCallback);
            newScoreText.text = $"New Score: {GameData.score}";
            usernameText.text = $"Username: {GameData.username}";
        }

        private void OnCallback(ScoreModel model)
        {
            if (model.message == "success")
            {
                oldScoreText.text = $"Old Score: {model.score}";
            }
            else
            {
                oldScoreText.text = $"Old Score: -";
            }

        }
    }
}