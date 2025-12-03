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
        private bool _doDash = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_isCoolTime && Input.GetKeyDown(KeyCode.Space))
            {
                _doDash = true;
                _isCoolTime = true;
                StartCoroutine(CoolDown());
            }
        }

        private void FixedUpdate()
        {
            if (_doDash)
            {
                Debug.Log("Dash requested");
                _doDash = false;
                _rb.AddForce(Vector2.up * dashPower, ForceMode2D.Impulse);
            }
        }

        private IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(dashCooldown);
            _isCoolTime = false;
        }
    }
}