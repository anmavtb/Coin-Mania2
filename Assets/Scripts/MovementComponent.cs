using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    Rigidbody rigidBody = null;
    [SerializeField] LayerMask groundMask = 0;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float rotateSpeed = 100;
    [SerializeField] public float jumpHeight = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        Vector2 _movementValue = InputManager.Instance.Move.ReadValue<Vector2>();
        transform.position += transform.forward * _movementValue.y * Time.deltaTime * moveSpeed;
        transform.position += transform.right * _movementValue.x * Time.deltaTime * moveSpeed;
    }

    void Rotate()
    {
        float _rotValue = InputManager.Instance.Rotate.ReadValue<float>();
        transform.eulerAngles += transform.up * _rotValue * Time.deltaTime * rotateSpeed;
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        if (CheckIfOnGround())
            rigidBody.AddForce(transform.up * 100 * jumpHeight);
    }

    bool CheckIfOnGround()
    {
        bool _touchGround = Physics.Raycast(transform.position, -transform.up, 1f, groundMask);
        if (_touchGround) return true;
        return false;
    }
}
