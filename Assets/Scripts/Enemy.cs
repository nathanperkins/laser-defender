using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int health;
    [SerializeField] float timeUntilShot;
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    [SerializeField] float shotSpeed;

    void Update()
    {
		CountDownAndShoot();
    }

    private void CountDownAndShoot() {
        timeUntilShot -= Time.deltaTime;

		if (timeUntilShot <= 0)
        {
            Fire();
            timeUntilShot = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        // Start from bottom of ship.
        Vector3 pos = transform.position;
        pos.y -= transform.localScale.y;

        GameObject projectile = Instantiate(
            projectilePrefab, pos, Quaternion.identity);

        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -shotSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
