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
                Debug.Log("Dash requested");
            }
        }

        private void FixedUpdate()
        {
            if (_doDash)
            {
                _doDash = false;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, dashPower);
            }
        }

        private IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(dashCooldown);
            _isCoolTime = false;
        }
    }
}