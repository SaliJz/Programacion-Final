using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proyecto_final
{
    public class GetRankingView : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private GameObject dataContainerPrefab;
        private GetRankingController controller;

        private void Awake()
        {
            controller = GetComponent<GetRankingController>();
        }

        public void Execute()
        {
            controller.Execute(OnCallback);
        }

        private void OnCallback(UserDataModel model)
        {
            foreach(Transform t in container.GetComponentInChildren<Transform>())
            {
                if (t != container.transform)
                {
                    Destroy(t.gameObject);
                }
            }

            foreach(UserModel user in model.data)
            {
                GameObject obj = Instantiate(dataContainerPrefab, container.transform);
                obj.GetComponent<DataContainer>().SetText($"{user.username} -  {user.score}");
            }
        }



    }

}