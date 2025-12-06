using System;
using _01_Scripts.Agent;
using UnityEngine;

namespace _01_Scripts.UI
{
    public class PlayerCoolUI : MonoBehaviour
    {
        private SpeedCompo _speedCompo;
        private SpriteRenderer _spriteRenderer;
        private Material _material;

        private void Awake()
        {
            _speedCompo = GetComponentInParent<SpeedCompo>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _material = _spriteRenderer.material;
        }

        private void Update()
        {
            //_speedCompo.SpeedCool
        }
    }
}