using RocketGame.Controllers;
using RocketGame.Managers;
using UnityEngine;

namespace RocketGame.Abstracts.Controllers
{
    public abstract class WallController : MonoBehaviour
    {
        
        private void OnCollisionEnter(Collision other)
        {
            PlayerMovement player = other.collider.GetComponent<PlayerMovement>();

            if (player != null && player.CanMove)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}


