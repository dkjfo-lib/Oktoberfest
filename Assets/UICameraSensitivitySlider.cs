using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICameraSensitivitySlider : MonoBehaviour
{
    public Number CameraSensitivity;
    public Slider CameraSensitivitySlider;

    private void Start()
    {
        CameraSensitivitySlider.value = CameraSensitivity.value;
    }

    public void SetNewValue(float newValue)
    {
        CameraSensitivity.value = newValue;
    }
}
