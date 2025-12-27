using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    [Header("Slider")]
    public SliderToolkit sliderToolkit;
    
    private void Start()
    {
        
    }
    
    [Button(nameof(OnRefreshSlider))]
    private void OnRefreshSlider()
    {
        sliderToolkit.OnRefresh();
    }
}
