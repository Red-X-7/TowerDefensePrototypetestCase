using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveThreshold = 0.01f;

    private Animator animator;

    // Oyun alan� s�n�rlar� (Inspector�dan ayarlanabilir)
    public Vector3 minBounds = new Vector3(-10f, 0f, -10f);
    public Vector3 maxBounds = new Vector3(10f, 0f, 10f);

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = false;

        // Ba�lang��ta sald�r� kapal�
        animator.SetBool("Attack", false);
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;
        bool isMoving = moveDir.sqrMagnitude > moveThreshold;

        animator.SetBool("isMoving", isMoving);

        if (isMoving)
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }

    public void StartAttackAnimation()
    {
        animator.SetBool("Attack", true); // Bool tetikleme
        Invoke(nameof(StopAttackAnimation), 0.5f); // Yar�m saniye sonra s�f�rla
    }

    void StopAttackAnimation()
    {
        animator.SetBool("Attack", false);
    }

    void LateUpdate()
    {
        // Pozisyonu s�n�rla
        Vector3 clampedPos = transform.position;

        clampedPos.x = Mathf.Clamp(clampedPos.x, minBounds.x, maxBounds.x);
        clampedPos.z = Mathf.Clamp(clampedPos.z, minBounds.z, maxBounds.z);

        transform.position = clampedPos;
    }
}