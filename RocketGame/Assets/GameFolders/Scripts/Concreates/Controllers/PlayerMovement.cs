using RocketGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketGame.Controllers
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField] float _force;
        public float hareketHýzý;
        private float yatayHareket;
        private bool _canForceUp;
        private Fuel _fuel;
        private bool _canMove;
        private float _leftRight;

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
            _leftRight = 1;
        }

        void Update()
        {
            if (!_canMove) return;

            yatayHareket += (Input.GetAxis("Horizontal") * _leftRight);
            if (Input.GetKey(KeyCode.W) && !_fuel.IsEmpty)
            {
                _canForceUp = true;
                
            }
            else
            {
                _canForceUp = false;
                
            }



        }

        private void FixedUpdate()
        {
            if (_canForceUp)
            {
                rb.AddRelativeForce(Vector3.up * _force * Time.deltaTime);
                _fuel.FuelDecrease(0.4f);
            }
            else
            {
                _fuel.FuelIncrease(0.05f);
            }

            rb.rotation = Quaternion.Euler(0f, 0f, yatayHareket * hareketHýzý);

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
            _leftRight = 0f;
            _fuel.FuelIncrease(0f);
        }
    }
}


