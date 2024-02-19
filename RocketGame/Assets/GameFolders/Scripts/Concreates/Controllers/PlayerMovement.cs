using RocketGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RocketGame.Controllers
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] GameObject _yoke;
        [SerializeField] Slider _powerSlider;
        Rigidbody rb;
        [SerializeField] float _force;
        public float hareketHýzý;
        private float yatayHareket;
        private bool _canForceUp;
        private Fuel _fuel;
        private bool _canMove;

        public bool CanMove => _canMove;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            _fuel = GetComponent<Fuel>();
        }

        void Start()
        {
            _canForceUp = true;
            _canMove = true;

        }

        void Update()
        {
            if (!_canMove) return;

            //gameObject.transform.rotation = new Quaternion(_yoke.transform.rotation.x, _yoke.transform.rotation.y, _yoke.transform.rotation.z, -_yoke.transform.rotation.w);




              yatayHareket += (Input.GetAxis("Horizontal") );    
            
            
            if (Input.GetKey(KeyCode.W) && !_fuel.IsEmpty)       
            {
                _canForceUp = true;
                
            }
            else
            {
                _canForceUp = false;
                
            }
            
            /*
            if(_powerSlider.value > 0 && !_fuel.IsEmpty)
            {
                _canForceUp = true;
            }
            else
            {
                _canForceUp = false;
            }
            */



        }

        private void FixedUpdate()
        {
            if (_canForceUp)
            {
                //rb.AddRelativeForce(Vector3.up * _force * Time.deltaTime);

                rb.AddRelativeForce(0f, _force * Time.deltaTime, 0f);

                
                _fuel.FuelDecrease(_powerSlider.value);
            }
            else
            {
                _fuel.FuelIncrease(0.05f);
            }

             rb.rotation = Quaternion.Euler(0f, 0f, yatayHareket * hareketHýzý);   //  YATAY HAREKET WASD   artýk yoke ile döndürdüðümüz için gerek yok

        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnEventTriggered;
            GameManager.Instance.OnMissionSucced += HandleOnEventTriggered;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnEventTriggered;
            GameManager.Instance.OnMissionSucced -= HandleOnEventTriggered;
        }

        private void HandleOnEventTriggered()
        {
            _canMove = false;
            _canForceUp = false;
            _fuel.FuelIncrease(0f);
        }
    }
}


