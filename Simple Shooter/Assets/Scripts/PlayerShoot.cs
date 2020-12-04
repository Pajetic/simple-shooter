using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject playerBullet;
    public float bulletSpeed = 10f;     // Force applied to bullet
    public float fireRate = 5f;         // Bullets per second
    public Transform bulletSpawn;

    private bool canFire = true;
    private float weaponLockoutTime;

    private void Start()
    {
        weaponLockoutTime = 1 / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire && Input.GetButton("Fire1"))
        {
            FireBullet();
            StartCoroutine(WeaponLockout());    // Wait for firing rate
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(playerBullet, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletSpawn.up * bulletSpeed, ForceMode2D.Impulse);
    }

    IEnumerator WeaponLockout()
    {
        canFire = false;
        yield return new WaitForSeconds(weaponLockoutTime);
        canFire = true;
    }
}
