using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace WeeklyAtivity
{

    public class StatisticsChart : MonoBehaviour
    {
        [SerializeField]
        public ServerData m_serverData;
        
        int[] calories = new int[7];
        Slider[] sliders = new Slider[7];

        int lenght = 0;

        void Start()
        {
            sliders = GetComponentsInChildren<Slider>();

            if (m_serverData != null)
            {
                m_serverData.OnResponseDataEvent.AddListener((data) =>
                {
                    for(int i = 0; i < data.Count; i++)
                    {
                        if (i < calories.Length)
                        {
                            calories[i] = data[i].value;    
                        }
                    }
                    
                    WithoutMax(); 
                });
                
                m_serverData.LoadData();
            }
        }

        void WithoutMax()
        {
            int max = calories.Max();

            for (int i = 0; i < sliders.Length; i++)
            {
                sliders[i].maxValue = max;
                sliders[i].value = calories[i];                
            }
        }
        
        void WithMax()
        {
            for (int i = 0; i < sliders.Length; i++, lenght++)
                sliders[lenght].value = calories[lenght];
        }
    }
}
