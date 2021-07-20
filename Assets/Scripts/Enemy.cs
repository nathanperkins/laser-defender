using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject deathVFX;

    [Header("Game")]
    [SerializeField] int health;
    [SerializeField] float timeUntilShot;
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    [SerializeField] float shotSpeed;

    [Header("Audio")]
    [SerializeField] AudioClip shootSound;
    [Range(0.0f, 1.0f)] [SerializeField] float shootSoundVolume;
    [SerializeField] AudioClip deathSound;
    [Range(0.0f, 1.0f)] [SerializeField] float deathSoundVolume;

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
        AudioSource.PlayClipAtPoint(shootSound, transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (!damageDealer) { return;  }
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

    private void OnDestroy()
    {
        if (health <= 0) { 
			Die();
		}
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position, deathSoundVolume);
        if (deathVFX) { 
			Instantiate(
				deathVFX,
				transform.position,
				Quaternion.identity);
		}
	}
}
