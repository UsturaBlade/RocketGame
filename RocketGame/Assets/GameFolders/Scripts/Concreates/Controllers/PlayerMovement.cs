using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float _force;
    private float yatayHareket;
    public float hareketHýzý;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
 
    }

    void Update()
    {
        yatayHareket += Input.GetAxis("Horizontal");
        rb.rotation = Quaternion.Euler(0f, 0f, yatayHareket*hareketHýzý);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * _force * Time.deltaTime);
        }
    }
}
