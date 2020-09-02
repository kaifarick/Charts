using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace WeeklyAtivity
{

    public class StatisticsChart : MonoBehaviour
    {
        int[] calories = new int[7];
        Slider[] sliders = new Slider[7];

        int lenght = 0;

        void Start()
        {
            sliders = GetComponentsInChildren<Slider>();

            RandomData();
            WithMax();
        }

        void WithoutMax()
        {
            int max = calories.Max();

            for (int i = 0; i < sliders.Length; i++, lenght++)
            {
                sliders[lenght].maxValue = max;
                sliders[lenght].value = calories[lenght];
                
            }
            
        }
        void WithMax()
        {
            for (int i = 0; i < sliders.Length; i++, lenght++)
                sliders[lenght].value = calories[lenght];
        }

        void RandomData()
        {
            for (int i = 0; i < calories.Length; i++)
                calories[i] = Random.RandomRange(0, 5000);;
        }
    }
}
