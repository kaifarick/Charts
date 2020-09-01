using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class data : MonoBehaviour
{
    int[] calories = new int[7];
    private Slider[] sliders = new Slider[7];
    int lenght = 0;

    void Start()
    {
        sliders = GetComponentsInChildren<Slider>();

        for (int i = 0; i < calories.Length; i++)  //имитирую полученные данные
        calories[i] = Random.RandomRange(0, 1500);

        WithoutMax();
    }

    void WithoutMax()
    {
        for (int i = 0; i < sliders.Length; i++, lenght++)
        {
            sliders[lenght].maxValue = calories.Max();
            sliders[lenght].value = calories[lenght];
        }
    }
    void WithMax()
    {
        for (int i = 0; i < sliders.Length; i++, lenght++)
            sliders[lenght].value = calories[lenght];
    }
}
