using System;
using System.Collections;
using UnityEngine;

namespace _01_Scripts.Agent
{
    public class SpeedCompo : MonoBehaviour
    {
        private MoveCompo _moveCompo;
        private TrailRenderer _trailRenderer;
        [SerializeField] private float addSpeed;
        [SerializeField] private float speedTime;
        [field:SerializeField] public float SpeedCool { get; private set; }
        private bool _isCoolTime = false;
        
        private void Awake()
        {
            _trailRenderer = GetComponentInChildren<TrailRenderer>();
            _moveCompo = GetComponent<MoveCompo>();
        }

        private void Start()
        {
            _trailRenderer.enabled = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_isCoolTime)
                StartCoroutine(SpeedCoroutine());
        }

        private IEnumerator SpeedCoroutine()
        {
            _trailRenderer.enabled = true;
            _moveCompo.Speed += addSpeed;
            _isCoolTime = true;
            yield return new WaitForSeconds(speedTime);
            _trailRenderer.enabled = false;
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
