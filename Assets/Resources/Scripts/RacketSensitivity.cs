using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacketSensitivity : MonoBehaviour
{
    public static int sensitivity;
    Slider slider;

    public IEnumerator Start()
    {
        yield return null;
        slider = GetComponentInChildren<Slider>();
        slider.value = 400;
    }
    public void GetSensitivity()
    {
        sensitivity = (int)slider.value;
    }
}
