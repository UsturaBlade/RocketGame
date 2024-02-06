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


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            _fuel = GetComponent<Fuel>();
        }

        void Start()
        {
            _canForceUp = true;
        }

        void Update()
        {
            yatayHareket += Input.GetAxis("Horizontal");
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
                _fuel.FuelDecrease(0.2f);
            }
            else
            {
                _fuel.FuelIncrease(0.05f);
            }

            rb.rotation = Quaternion.Euler(0f, 0f, yatayHareket * hareketHýzý);

        }
    }
}


