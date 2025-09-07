using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform PlayerTrm;

    [Header("Player")]
    public Rigidbody rb;
    public float accel = 20f;       // ���ӵ�
    public float maxSpeed = 10f;    // �ִ� �ӵ�
    public float friction = 8f;     // ������
    public float airControl = 0.5f; // ���� ���� ����
    public float jumpForce = 7f;
    public bool grounded;

    private Vector3 moveDir;

    [Header("Rotate")]
    public float mouseSpeed;
    float yRotation;
    float xRotation;
    [SerializeField] private Camera cam;

    public LayerMask groundLayer;

    void Start()
    {
        rb = PlayerTrm.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(PlayerTrm.position, Vector3.down * 1.2f);
    }

    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Vector3 dir = (z * transform.forward) + (x * transform.right);

        //rb.linearVelocity = dir.normalized;

        PlayerTrm.Translate(new Vector3(x, 0, z) * Time.deltaTime * 5);

        //if (IsGroundedCheck())
        //    GroundMove();
        //else
        //    AirMove();
    }

    public void GroundMove()
    {
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x * (1 - friction * Time.deltaTime),
            rb.linearVelocity.y,
            rb.linearVelocity.z * (1 - friction * Time.deltaTime)
        );

        Accelerate(moveDir, accel, maxSpeed);
    }

    public void AirMove()
    {
        Accelerate(moveDir, accel * airControl, maxSpeed);
    }

    void Accelerate(Vector3 wishDir, float accel, float maxSpeed)
    {
        float currentSpeed = Vector3.Dot(rb.linearVelocity, wishDir);
        float addSpeed = maxSpeed - currentSpeed;
        if (addSpeed <= 0) return;

        float accelSpeed = accel * Time.deltaTime * maxSpeed;
        if (accelSpeed > addSpeed) accelSpeed = addSpeed;

        rb.linearVelocity += wishDir * accelSpeed;
    }

    public void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;    // ���콺 X�� �Է¿� ���� ���� ȸ�� ���� ����
        xRotation -= mouseY;    // ���콺 Y�� �Է¿� ���� ���� ȸ�� ���� ����

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // ���� ȸ�� ���� -90������ 90�� ���̷� ����

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // ī�޶��� ȸ���� ����
        PlayerTrm.rotation = Quaternion.Euler(0, yRotation, 0);             // �÷��̾� ĳ������ ȸ���� ����
    }

    public void InputJump()
    {
        if (IsGroundedCheck())
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        grounded = false;
    }

    public bool IsGroundedCheck()
    {
        return Physics.Raycast(PlayerTrm.position, Vector3.down, 1.2f, groundLayer);
    }

    public void InputNosedive()
    {
        if (!IsGroundedCheck())
        {
            Nosedive();
        }
    }
    private void Nosedive()
    {
        //rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.down * 7, ForceMode.Impulse);
    }

    public void InputDash()
    {
        Dash();
    }

    private void Dash()
    {
        //Debug.Log(rb.linearVelocity);
        rb.AddForce(rb.linearVelocity * 5, ForceMode.Impulse);
    }
}
