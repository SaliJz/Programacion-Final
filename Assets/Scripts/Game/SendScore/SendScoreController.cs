using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

namespace Proyecto_final
{
    public class SendScoreController : MonoBehaviour
    {

        public void Execute(string username, int score, Action<MessageModel> OnCallback)
        {
            StartCoroutine(SendRequest(username, score, OnCallback));
        }

        private IEnumerator SendRequest(string username, int score, Action<MessageModel> OnCallback)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("score", score);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Programacion_promedio_3/Proyecto_final/insert_score.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ProtocolError
                    || www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error!");
                }
                else
                {
                    OnCallback?.Invoke(JsonUtility.FromJson<MessageModel>(www.downloadHandler.text));
                }
            }
        }

    }

}