using RocketGame.Managers;
using UnityEngine;

namespace RocketGame.Controllers
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float _maxFuel = 100f;
        [SerializeField] float _currentFuel;
        public ParticleSystem _particleSystem;
        

        public bool IsEmpty => _currentFuel < 1f;
         public float CurrentFuel { get { return _currentFuel; } set { _currentFuel = value; } } 

     

        private void Awake()
        {
            _currentFuel = _maxFuel;
            _particleSystem.Stop();
        }

        public void FuelIncrease(float increase)
        {
            _currentFuel += increase;
            _currentFuel = Mathf.Min(_currentFuel, _maxFuel);

            if (_particleSystem.isPlaying)
            {
                _particleSystem.Stop();
            }

            SoundManager.Instance.StopSound(0);
        }

        public void FuelDecrease(float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0f);

            if (_particleSystem.isStopped)
            {
                _particleSystem.Play();
            }

            SoundManager.Instance.PlaySound(0);
        }
    }

}

