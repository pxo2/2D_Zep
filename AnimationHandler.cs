using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
     // 문자를 해쉬값으로 변환해준다
    protected Animator animator;// Animator 컴포넌트를 참조할 변수

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }// 자식 오브젝트에서 Animator 컴포넌트를 찾음

    public void Move(Vector2 obj) // 이동 중일 때 애니메이션을 처리
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    } // obj.magnitude가 0.5f보다 크면 이동 중으로 간주하고 애니메이션을 설정
    // 이동 여부에 따라 "IsMove" 파라미터 설정
}