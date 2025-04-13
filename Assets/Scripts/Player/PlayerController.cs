using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;    // 移動速度
    public float jumpForce = 5f;    // ジャンプ力←必要？(一応入れた)
    private Rigidbody rb;           // リジットボディ
    private bool isGrounded = true; // 多段ジャンプを防ぐ

    /// <summary>
    /// 開始メソッド
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;   // 回転を固定して転がらないようにする
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        //　TODO → 座標に値を入れてるだけだからPlayerがガタガタ動く
        //  井戸がプロトタイプ版までに修正
        float horizontal = Input.GetAxisRaw("Horizontal"); // Aキー・Dキーによる左右移動入力

        Vector3 move = Vector3.right * horizontal * moveSpeed; // 移動方向ベクトル
        rb.velocity = new Vector3(move.x, rb.velocity.y, rb.velocity.z); // Rigidbodyの速度を更新

        // TODO → ブロックに触れているときもジャンプができないの
        // 井戸がプロトタイプ版までに修正
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // スペースキーが押され、かつ地面にいるとき
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ジャンプ
            isGrounded = false;                                     // 空中にいるのでジャンプ不可に設定
        }
    }

    /// <summary>
    /// 地面との接触判定
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 接触した相手のタグが "Ground" のとき
        {
            isGrounded = true;                         // 地面に接しているのでジャンプ可能にする
        }
    }
}
