using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections.Generic;

namespace WeeklyAtivity
{
    public class ServerData : MonoBehaviour
    {
        private string jsonUrl;

        public int[] Calories = new int[7];
        void Start()
        {
            jsonUrl = "http://n44.me/statistics.json";
            StartCoroutine(LoadTextFromServer());
        }

        IEnumerator LoadTextFromServer()
        {
            UnityWebRequest request = UnityWebRequest.Get(jsonUrl);
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

            foreach (ActData Value in AllStats.data)
            {
                Debug.Log(Value.value);
            }
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
