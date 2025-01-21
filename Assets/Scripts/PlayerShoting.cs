using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;

    public float bulletDamage = 5;
    public int damagemultiplayer = 2;
    // Start is called before the first frame update
    void Update()
    {
        RotateBulletSpawnPointTowardsMouse();


        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void RotateBulletSpawnPointTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - firePointRotation.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        firePointRotation.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();

        rb.velocity = firePointRotation.right * bulletSpeed;
        bulletScript.damage = bulletDamage;

        Destroy(bullet, 3f);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StrengthRing"))
        {
            bulletDamage *= damagemultiplayer;
        }
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            HealthScriptForOthers others = GetComponent<HealthScriptForOthers>();
            others.othershp -= bulletDamage;
            Debug.Log("HP TAKEN");
        }
    }
}
