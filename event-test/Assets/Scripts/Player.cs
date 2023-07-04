using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;

    private Vector3 moveVector = Vector3.zero;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveVector.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + moveVector * speed * Time.fixedDeltaTime);
    }
}
