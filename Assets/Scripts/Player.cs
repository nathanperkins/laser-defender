using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        Move();    
    }

    private void Move()
    {
        float deltaX = ScaleMovement(Input.GetAxis("Horizontal"));
        float deltaY = ScaleMovement(Input.GetAxis("Vertical"));

        Vector3 pos = transform.position;
        pos.x += deltaX;
        pos.y += deltaY;
        transform.position = pos;
    }

    private float ScaleMovement(float delta)
    {
        return delta * moveSpeed * Time.deltaTime;
    }
}
