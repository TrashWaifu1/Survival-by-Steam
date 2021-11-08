using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    //VARIABLES
    [SerializeField] float fire = 1;
    [SerializeField] float water = 100;
    [SerializeField] float steam = 1;

    [SerializeField] float speed;

    Vector2 destination;
    Vector2 direction;
    Rigidbody2D rb;

    //REFERENCES

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Steam", 1, 1);
    }

    private void Update()
    {
        speed = Mathf.Clamp(steam, 0, 1);
        if (Input.GetMouseButton(0))
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = Vector2.Lerp(transform.position, destination, speed / 10);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(direction);
    }

    void Steam()
    {
        if (fire > 0)
        {
            water -= fire;
            steam += fire;
        }

        steam -= 0.05f;
    }
}
