using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
     // ���ڸ� �ؽ������� ��ȯ���ش�
    protected Animator animator;// Animator ������Ʈ�� ������ ����

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }// �ڽ� ������Ʈ���� Animator ������Ʈ�� ã��

    public void Move(Vector2 obj) // �̵� ���� �� �ִϸ��̼��� ó��
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    } // obj.magnitude�� 0.5f���� ũ�� �̵� ������ �����ϰ� �ִϸ��̼��� ����
    // �̵� ���ο� ���� "IsMove" �Ķ���� ����
}