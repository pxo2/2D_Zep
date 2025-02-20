using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;// Rigidbody2D 컴포넌트 (물리 이동을 담당)

    [SerializeField] private SpriteRenderer characterRenderer;
    // 캐릭터의 스프라이트 렌더러 (플립X를 이용해 방향을 반전)
    protected Vector2 movementDirection = Vector2.zero; // 현재 이동 방향 (기본값: (0,0))
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }//현재바라보는 방향(기본값: (0,0))

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    { // Awake(): 게임 오브젝트가 생성될 때 한 번 실행됨 (가장 먼저 실행)
        _rigidbody = GetComponent<Rigidbody2D>();
        // Rigidbody2D 컴포넌트를 가져와서 _rigidbody에 저장
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()// Start(): 게임이 시작될 때 한 번 실행됨
    {

    }

    protected virtual void Update()// Update(): 매 프레임마다 실행됨 (입력 및 회전 처리)
    {
        HandleAction(); // 캐릭터의 키입력시 행동 처리
        Rotate(lookDirection); // 캐릭터 회전 처리
    }

    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movment(Vector2 direction)
    {// Movment(): 캐릭터 이동 처리 (Rigidbody2D의 velocity를 변경)
        direction = direction * 5;// 기본 이동 속도 적용 (속도를 5배 증가)

        _rigidbody.velocity = direction;// Rigidbody2D의 velocity를 설정하여 이동 적용
        animationHandler.Move(direction); // direction 방향
    }

    private void Rotate(Vector2 direction) // Rotate(): 캐릭터 회전 처리
    {
        if (direction == Vector2.zero) return;// 방향이 0,0이면 회전하지 않음

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 방향을 이용해 회전 각도 계산

        bool isLeft = Mathf.Abs(rotZ) > 90f;
        // 캐릭터가 왼쪽을 바라볼지 판단 (90도 이상이면 왼쪽)

        characterRenderer.flipX = isLeft;// 캐릭터의 스프라이트 방향 반전
    }
}
