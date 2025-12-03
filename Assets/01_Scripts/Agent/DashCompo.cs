using System.Collections;
using UnityEngine;

namespace _01_Scripts.Agent
{
    public class DashCompo : MonoBehaviour
    {
        [Header("Dash Settings")]
        [SerializeField] private float dashPower = 12f;
        [SerializeField] private float dashCooldown = 1.2f;

        [Header("Decay / Threshold")]
        [SerializeField] private float stopThreshold = 2f; // 속도 합이 이 값 이하가 되면 감속 루프 종료
        [SerializeField] private float decayFactor = 0.85f;
        [SerializeField] private float decayStepSeconds = 0.01f;

        [Header("Optional Components")]
        [SerializeField] private TrailRenderer trail; // 할당 안하면 자동으로 자식에서 찾음
        // (원본에 있던 UI나 Player 호출을 그대로 두되 안전하게 검사합니다)

        private Rigidbody2D _rb;
        private bool _isCooling = false;
        private float _coolTimer = 0f;
        private bool _isDashing = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            if (trail == null)
                trail = GetComponentInChildren<TrailRenderer>();

            if (trail != null)
                trail.time = 0f;

            _coolTimer = dashCooldown;
        }

        private void Update()
        {
            // 쿨다운 타이머 갱신
            if (_coolTimer < dashCooldown)
            {
                _coolTimer += Time.deltaTime;
            }
            else
            {
                _isCooling = false;
                _coolTimer = dashCooldown;
            }

            // 입력 처리 (Space 누르면 대쉬)
            if (!_isCooling && !_isDashing && Input.GetKeyDown(KeyCode.Space))
            {
                // 입력된 방향을 읽어서 전달합니다.
                // 여기서는 화살표/wasd 입력을 즉시 읽어 대쉬 방향으로 사용합니다.
                Vector2 dir = Vector2.zero;
                if (Input.GetKey(KeyCode.W)) dir += Vector2.up;
                if (Input.GetKey(KeyCode.S)) dir += Vector2.down;
                if (Input.GetKey(KeyCode.A)) dir += Vector2.left;
                if (Input.GetKey(KeyCode.D)) dir += Vector2.right;
                StartCoroutine(Dash(dir.normalized));
            }
        }

        private IEnumerator Dash(Vector2 dir)
        {
            _isDashing = true;
            _isCooling = true;
            _coolTimer = 0f;

            // 트레일 켜기
            if (trail != null)
                trail.time = 0.1f;
            
            try
            {
                var playerType = typeof(Player.Player); // 컴파일 타임에 Player가 없으면 에러 발생하므로 try-catch로 안전 처리
                var instProp = playerType.GetProperty("Instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                if (instProp != null)
                {
                    var inst = instProp.GetValue(null);
                    if (inst != null)
                    {
                        var ultimateState = playerType.GetMethod("Mujuck");
                        if (ultimateState != null)
                            ultimateState.Invoke(inst, new object[] { true });
                    }
                }
            }
            catch
            {
                
            }

            // 방향 보정: 입력이 없으면(0,0) 자식의 localScale.x로 바라보는 방향 사용
            if (dir == Vector2.zero)
            {
                if (transform.childCount > 0)
                {
                    float sx = transform.GetChild(0).localScale.x;
                    dir = sx > 0 ? Vector2.right : Vector2.left;
                }
                else
                {
                    // 안전 fallback
                    dir = Vector2.right;
                }
            }

            // 즉시 속도 추가 (원본: linearVelocity += dir * dashPower)
            _rb.linearVelocity += dir * dashPower;

            // 감속 루프: 속도가 충분히 작아질 때까지 반복
            while (Mathf.Abs(_rb.linearVelocity.x) + Mathf.Abs(_rb.linearVelocity.y) > stopThreshold)
            {
                _rb.linearVelocity = _rb.linearVelocity * decayFactor;
                yield return new WaitForSeconds(decayStepSeconds);
            }

            // 트레일 끄기
            if (trail != null)
                trail.time = 0f;

            // 짧은 대기 후 상태 복구
            _isDashing = false;
            yield return new WaitForSeconds(0.15f);
            
            try
            {
                var playerType = typeof(Player.Player);
                var instProp = playerType.GetProperty("Instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                if (instProp != null)
                {
                    var inst = instProp.GetValue(null);
                    if (inst != null)
                    {
                        var ultimateState = playerType.GetMethod("Mujuck");
                        if (ultimateState != null)
                            ultimateState.Invoke(inst, new object[] { false });
                    }
                }
            }
            catch
            {
                // 무시
            }
        }

        // 외부에서 방향을 지정해 대쉬를 강제 실행하려면 이 메서드 사용
        public void RequestDash(Vector2 direction)
        {
            if (!_isCooling && !_isDashing)
            {
                StartCoroutine(Dash(direction.normalized));
            }
        }
    }
}
