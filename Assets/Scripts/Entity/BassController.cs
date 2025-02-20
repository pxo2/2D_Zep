using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;// Rigidbody2D ������Ʈ (���� �̵��� ���)

    [SerializeField] private SpriteRenderer characterRenderer;
    // ĳ������ ��������Ʈ ������ (�ø�X�� �̿��� ������ ����)
    protected Vector2 movementDirection = Vector2.zero; // ���� �̵� ���� (�⺻��: (0,0))
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }//����ٶ󺸴� ����(�⺻��: (0,0))

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    { // Awake(): ���� ������Ʈ�� ������ �� �� �� ����� (���� ���� ����)
        _rigidbody = GetComponent<Rigidbody2D>();
        // Rigidbody2D ������Ʈ�� �����ͼ� _rigidbody�� ����
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()// Start(): ������ ���۵� �� �� �� �����
    {

    }

    protected virtual void Update()// Update(): �� �����Ӹ��� ����� (�Է� �� ȸ�� ó��)
    {
        HandleAction(); // ĳ������ Ű�Է½� �ൿ ó��
        Rotate(lookDirection); // ĳ���� ȸ�� ó��
    }

    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movment(Vector2 direction)
    {// Movment(): ĳ���� �̵� ó�� (Rigidbody2D�� velocity�� ����)
        direction = direction * 5;// �⺻ �̵� �ӵ� ���� (�ӵ��� 5�� ����)

        _rigidbody.velocity = direction;// Rigidbody2D�� velocity�� �����Ͽ� �̵� ����
        animationHandler.Move(direction); // direction ����
    }

    private void Rotate(Vector2 direction) // Rotate(): ĳ���� ȸ�� ó��
    {
        if (direction == Vector2.zero) return;// ������ 0,0�̸� ȸ������ ����

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // ������ �̿��� ȸ�� ���� ���

        bool isLeft = Mathf.Abs(rotZ) > 90f;
        // ĳ���Ͱ� ������ �ٶ��� �Ǵ� (90�� �̻��̸� ����)

        characterRenderer.flipX = isLeft;// ĳ������ ��������Ʈ ���� ����
    }
}
