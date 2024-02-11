using RocketGame.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RocketGame.Controllers
{
    public class MoverWallController : WallController
    {
        [SerializeField] Vector3 _direction;
        [SerializeField] float _factor;
        [SerializeField] float _speed;


        Vector3 _startPosition;
        private const float FULL_CIRCLE = Mathf.PI * 2f;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            float cycle = Time.time / _speed;
            float sinWave = Mathf.Sin(cycle * FULL_CIRCLE);

            _factor = Mathf.Abs(sinWave);

            Vector3 offset = _direction * _factor;
            transform.position = offset + _startPosition;

        }
    }
}


