using System;
using System.Collections;
using UnityEngine;

namespace Agent
{
    public class DashCompo : MonoBehaviour
    {
        [SerializeField] private float dashPower = 5f;
        [SerializeField] private float dashCooldown = 5f;
        private bool _isCoolTime = false;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_isCoolTime && Input.GetKeyDown(KeyCode.Space))
            {
                Dash();
                Debug.Log("d");
                _isCoolTime = true;
                StartCoroutine(CoolDown());
            }
        }

        private IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(dashCooldown);
            _isCoolTime = false;
        }

        private void Dash()
        {
            _rb.AddForce(Vector2.up * dashPower);
        }
    }
}