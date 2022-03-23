using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBar : MonoBehaviour
{
    public Slider counterSlider;

    private void Awake()
    {
        counterSlider = GetComponent<Slider>();
    }

    public void IncreaseBar(float value)
    {
        counterSlider.value += value;
    }

    public void DecreaseBar(float speed)
    {
        if(counterSlider.value > 0)
            counterSlider.value -= speed * Time.deltaTime;
    }

    private void Update()
    {
        DecreaseBar(0.05f);
    }
}
