using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;    // �ړ����x
    public float jumpForce = 5f;    // �W�����v�́��K�v�H(�ꉞ���ꂽ)
    private Rigidbody rb;           // ���W�b�g�{�f�B
    private bool isGrounded = true; // ���i�W�����v��h��

    /// <summary>
    /// �J�n���\�b�h
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;   // ��]���Œ肵�ē]����Ȃ��悤�ɂ���
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    void Update()
    {
        //�@TODO �� ���W�ɒl�����Ă邾��������Player���K�^�K�^����
        //  ��˂��v���g�^�C�v�ł܂łɏC��
        float horizontal = Input.GetAxisRaw("Horizontal"); // A�L�[�ED�L�[�ɂ�鍶�E�ړ�����

        Vector3 move = Vector3.right * horizontal * moveSpeed; // �ړ������x�N�g��
        rb.velocity = new Vector3(move.x, rb.velocity.y, rb.velocity.z); // Rigidbody�̑��x���X�V

        // TODO �� �u���b�N�ɐG��Ă���Ƃ����W�����v���ł��Ȃ���
        // ��˂��v���g�^�C�v�ł܂łɏC��
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // �X�y�[�X�L�[��������A���n�ʂɂ���Ƃ�
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // �W�����v
            isGrounded = false;                                     // �󒆂ɂ���̂ŃW�����v�s�ɐݒ�
        }
    }

    /// <summary>
    /// �n�ʂƂ̐ڐG����
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // �ڐG��������̃^�O�� "Ground" �̂Ƃ�
        {
            isGrounded = true;                         // �n�ʂɐڂ��Ă���̂ŃW�����v�\�ɂ���
        }
    }
}
