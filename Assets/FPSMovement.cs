using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float sprintMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveBy = transform.right * x + transform.forward * y;
        float actualSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed *= sprintMultiplier;
        }
        rb.MovePosition(transform.position + moveBy.normalized * actualSpeed * Time.deltaTime);
    }
}
