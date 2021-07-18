using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    float xMin, xMax, yMin, yMax;

    void Start()
    {
        SetMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();    
    }

    private void SetMoveBoundaries()
    {
        Camera cam = Camera.main;
        float halfOfShipX = transform.localScale.x / 2;
        float halfOfShipY = transform.localScale.y / 2;

        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + halfOfShipX;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - halfOfShipX;
        yMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + halfOfShipY;
        yMax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - halfOfShipY;
	}

    private void Move()
    {
        float deltaX = ScaleMovement(Input.GetAxis("Horizontal"));
        float deltaY = ScaleMovement(Input.GetAxis("Vertical"));

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + deltaX, xMin, xMax);
        pos.y = Mathf.Clamp(pos.y + deltaY, yMin, yMax);
        transform.position = pos;
    }

    private float ScaleMovement(float delta)
    {
        return delta * moveSpeed * Time.deltaTime;
    }
}
