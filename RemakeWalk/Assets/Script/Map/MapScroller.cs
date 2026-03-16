using UnityEngine;
using System.Collections.Generic;
public class MapScroller : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.back * speed * Time.fixedDeltaTime);
    }
}