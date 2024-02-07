using RocketGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketGame.UIS
{
    public class WinConditionPanel : MonoBehaviour
    {
        public void RestartClicked()
        {
            GameManager.Instance.LoadLevelScene();
        }

        public void GoToMenuClicked()
        {
            GameManager.Instance.LoadMenuSene();
        }

        public void NextLevelClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
        }
    }
}


