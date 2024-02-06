using RocketGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RocketGame.Controllers
{
    public class WallController : MonoBehaviour
    {
        
        private void OnCollisionEnter(Collision other)
        {
            PlayerMovement player = other.collider.GetComponent<PlayerMovement>();

            if (player != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}


