using RocketGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RocketGame.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        

        [SerializeField] GameObject _finishFireWork;
        [SerializeField] GameObject _finishLight;

        private void OnCollisionEnter(Collision other)
        {
            
            PlayerMovement player = other.collider.GetComponent<PlayerMovement>();

            if (player == null || !player.CanMove) return;

            if(other.GetContact(0).normal.y == -1) //burada playerin finishFloora tam tepeden çarpýp çarpmadýðýna bakýyoruz
            {
                _finishFireWork.SetActive(true);
                _finishLight.SetActive(true);
                GameManager.Instance.MissionSucseed();
            }
            else
            {
                //GameOver
                GameManager.Instance.GameOver();
            }
        }
        
            
        
    }
}

