using System;
using System.Collections;
using UnityEngine;

namespace _01_Scripts.Agent
{
    public class SpeedCompo : MonoBehaviour
    {
        private MoveCompo _moveCompo;
        [SerializeField] private float addSpeed;
        [SerializeField] private float speedTime;
        [field:SerializeField] public float SpeedCool { get; private set; }
        private bool _isCoolTime = false;
        
        private void Awake()
        {
            _moveCompo = GetComponent<MoveCompo>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_isCoolTime)
                StartCoroutine(SpeedCoroutine());
        }

        private IEnumerator SpeedCoroutine()
        {
            _moveCompo.Speed += addSpeed;
            _isCoolTime = true;
            yield return new WaitForSeconds(speedTime);
            _moveCompo.Speed -= addSpeed;
            StartCoroutine(CoolTime());
        }

        private IEnumerator CoolTime()
        {
            yield return new WaitForSeconds(SpeedCool);
            _isCoolTime = false;
        }
    }
}
