using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;
    // Start is called before the first frame update
    void Update()
    {
        RotateBulletSpawnPointTowardsMouse();


        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if(Input.GetKey(KeyCode.X))
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

        rb.velocity = firePointRotation.right * bulletSpeed;

        Destroy(bullet, 3f);

    }
}