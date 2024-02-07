using RocketGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketGame.UIS
{
    public class WinConditionObject : MonoBehaviour
    {
        [SerializeField] GameObject _winConditionPanel;

        private void Awake()
        {
            if (_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(false);
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnMissionSucced += HandleOnMissionSucced;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnMissionSucced -= HandleOnMissionSucced;
        }

        private void HandleOnMissionSucced()
        {
            if (!_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(true);
            }
        }
    }
}


