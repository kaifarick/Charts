using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace WeeklyAtivity
{
    public class ResponseDataEvent : UnityEvent<List<ServerData.ActData>>
    {}

    public class ServerData : MonoBehaviour
    {
        public ResponseDataEvent OnResponseDataEvent = new ResponseDataEvent();
        
        [SerializeField]
        private string m_jsonUrl = "http://n44.me/statistics.json";

        public void LoadData()
        {
            StartCoroutine(LoadTextFromServer());
        }

        protected IEnumerator LoadTextFromServer()
        {
            UnityWebRequest request = UnityWebRequest.Get(m_jsonUrl);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                JsonData(request.downloadHandler.text);
            }
        }

        void JsonData(string json)
        {
            AllStatistic AllStats = JsonUtility.FromJson<AllStatistic>(json);
            
            OnResponseDataEvent.Invoke(AllStats.data);
        }


        [System.Serializable]
        public class AllStatistic
        {
            public int previous;
            public int current;
            public int total;

            public List<ActData> data;
        }

        [System.Serializable]
        public class ActData
        {
            public int value;
        }
    }
}