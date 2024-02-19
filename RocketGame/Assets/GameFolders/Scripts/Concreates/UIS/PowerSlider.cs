using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

namespace RocketGame.UIS
{
    public class PowerSlider : MonoBehaviour
    {
        private Slider _slider;
        void Start()
        {
           _slider =  GetComponent<Slider>();
        }

        public void SetThePowerZero()
        {
            _slider.value = 0;
        }

       
    }
}
