using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                   // プレイヤー
    public float followSpeed = 5f;             // カメラの追従速度
    public float leftMargin = 3f;              // プレイヤーがこのXを超えたら追従開始
    public float fixedY = 2.5f;                // カメラの高さ（プレイヤーに合わせて調整）
    public float fixedZ = -10f;                // カメラの奥行き

    private float minCameraX;                  // カメラが戻らないように制限

    void Start()
    {
        // 開始時のカメラXを基準にする
        minCameraX = transform.position.x;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void LateUpdate()
    {
        // TODO → Playerのカメラを2Dチックにする(マリオみたいに)
        // プレイヤーを中心ではなく若干左側に寄せてカメラを追従
        float targetX = target.position.x + leftMargin;

        // X座標の後進
        float newX = Mathf.Max(minCameraX, targetX);

        // 新しいカメラ位置
        Vector3 targetPosition = new Vector3(newX, fixedY - 2.0f, fixedZ);

        // スムーズに追従するように
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}

