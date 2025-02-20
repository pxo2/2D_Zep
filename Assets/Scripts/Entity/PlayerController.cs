using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;// 카메라 변수, 마우스 위치를 월드 좌표로 변환할 때 사용

    protected override void Start()// Start 메서드에서 초기화 작업을 수행
    {
        base.Start(); // BaseController의 Start()를 호출하여 부모 클래스의 초기화 작업 수행
        camera = Camera.main; // 기본 카메라를 찾고 설정 (Main Camera)
    }

    protected override void HandleAction() // 플레이어의 이동 및 시선 방향을 처리하는 메서드
    {
        // 입력을 받아서 수평(horizontal)과 수직(vertical) 방향으로 이동할 값을 설정
        float horizontal = Input.GetAxisRaw("Horizontal");// 좌우 이동 (A, D, 화살표 좌우) 수평
        float vertial = Input.GetAxisRaw("Vertical");// 상하 이동 (W, S, 화살표 상하) 수직
        movementDirection = new Vector2(horizontal, vertial).normalized;
        // 이동 벡터를 만들어서 `movementDirection`에 저장 (이동 방향 정규화)

        Vector2 mousePosition = Input.mousePosition;// 마우스 위치를 화면 상에서 받아오기
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        // 마우스 위치를 월드 좌표로 변환 (스크린 좌표 -> 월드 좌표)
        lookDirection = (worldPos - (Vector2)transform.position);
        // 마우스와 플레이어 간의 방향 벡터 계산

        if (lookDirection.magnitude < .9f)// 마우스와 거리가 너무가까우면 시선방향을 (0,0)으로 설정
        {
            lookDirection = Vector2.zero; // 마우스와 너무 가까운 경우 시선 방향을 0으로 설정
        }
        else
        {
            lookDirection = lookDirection.normalized;
        } // 시선 방향 벡터를 정규화하여 방향만을 유지하고 크기는 1로 고정
    }
}
