using System;
using UnityEngine;
using UnityEngine.UI;

namespace _01_Scripts.UI
{
    public class DeathCinema : MonoBehaviour
    {
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
    }
}