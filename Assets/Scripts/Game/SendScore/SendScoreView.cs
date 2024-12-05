using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Proyecto_final
{
    public class SendScoreView : MonoBehaviour
    {

        [SerializeField] private Button sendScoreButton;
        private SendScoreController controller;

        private void Awake()
        {
            controller = GetComponent<SendScoreController>();
            sendScoreButton.onClick.AddListener(Execute);
        }

        private void Execute()
        {
            controller.Execute(GameData.username, GameData.score, OnCallback);
        }

        private void OnCallback(MessageModel model)
        {
            GetComponent<GetRankingView>().Execute();
        }
    }

}