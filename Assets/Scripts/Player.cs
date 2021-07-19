using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed;
    [SerializeField] int health;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float shotSpeed;
    [SerializeField] float shotInterval;

    Coroutine firingCoroutine;

    float xMin, xMax, yMin, yMax;

    void Start()
    {
        SetMoveBoundaries();
    }

    void Update()
    {
        Move();
        Fire();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return;  }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0) {
            Destroy(gameObject);
		}
	}

    private void Fire()
    {
		if (Input.GetButtonDown("Fire1") && firingCoroutine == null)
		{
            firingCoroutine = StartCoroutine(FireContinuously());
		}
        else if (Input.GetButtonUp("Fire1") && firingCoroutine != null)
		{
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
		}
	}

    private IEnumerator FireContinuously()
	{
        while (true)
        {
            // Start from tip of ship.
            Vector3 pos = transform.position;
            pos.y += transform.localScale.y;

            GameObject laser = Instantiate(
                laserPrefab, pos, Quaternion.identity);

            var body = laser.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(0, shotSpeed);
            yield return new WaitForSeconds(shotInterval);
        }
	}

    private float ScaleMovement(float delta)
    {
        return delta * moveSpeed * Time.deltaTime;
    }
}
