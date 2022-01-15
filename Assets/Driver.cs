using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 120f;
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostedSpeed = 20f;
    [SerializeField] float timer;

    float actualSpeed;

    // Start is called before the first frame update
    void Start()
    {
        actualSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            actualSpeed = normalSpeed;
        }

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; ;
        float acceleration = Input.GetAxis("Vertical") * actualSpeed * Time.deltaTime;
        transform.Translate(0, acceleration, 0);

        if (acceleration != 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            actualSpeed = boostedSpeed;
            timer = 4f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        actualSpeed = slowSpeed;
        timer = 1f;
    }
}
