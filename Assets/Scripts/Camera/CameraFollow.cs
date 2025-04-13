using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                   // �v���C���[
    public float followSpeed = 5f;             // �J�����̒Ǐ]���x
    public float leftMargin = 3f;              // �v���C���[������X�𒴂�����Ǐ]�J�n
    public float fixedY = 2.5f;                // �J�����̍����i�v���C���[�ɍ��킹�Ē����j
    public float fixedZ = -10f;                // �J�����̉��s��

    private float minCameraX;                  // �J�������߂�Ȃ��悤�ɐ���

    void Start()
    {
        // �J�n���̃J����X����ɂ���
        minCameraX = transform.position.x;
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    void LateUpdate()
    {
        // TODO �� Player�̃J������2D�`�b�N�ɂ���(�}���I�݂�����)
        // �v���C���[�𒆐S�ł͂Ȃ��኱�����Ɋ񂹂ăJ������Ǐ]
        float targetX = target.position.x + leftMargin;

        // X���W�̌�i
        float newX = Mathf.Max(minCameraX, targetX);

        // �V�����J�����ʒu
        Vector3 targetPosition = new Vector3(newX, fixedY - 2.0f, fixedZ);

        // �X���[�Y�ɒǏ]����悤��
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}

