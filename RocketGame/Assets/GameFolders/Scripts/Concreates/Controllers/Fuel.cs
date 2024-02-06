using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketGame.Controllers
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float _maxFuel = 100f;
        [SerializeField] float _currentFuel;
        public ParticleSystem _particleSystem;

        public bool IsEmpty => _currentFuel < 1f;

        private void Awake()
        {
            _currentFuel = _maxFuel;
            if (_particleSystem != null)
            {
                _particleSystem.Play();
            }
        }

        public void FuelIncrease(float increase)
        {
            _currentFuel += increase;
            _currentFuel = Mathf.Min(_currentFuel, _maxFuel);

            _particleSystem.Stop();


        }

        public void FuelDecrease(float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0f);
            _particleSystem.Play();


        }
    }

}

