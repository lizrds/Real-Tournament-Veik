using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public int ammo;
    public int maxAmmo;
    public int mags = 4;
    public GameObject bullet;
    public bool isReloading;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (isReloading)
        {
            return;
        }

        if (ammo <= 0)
        {
            Reload();
            return;
        }
        else
        {
            ammo -= 1;
        }

        
        float bulletOffset1 = Random.Range(0, 1);
        Quaternion bulletRotation1 = Quaternion.Euler(0, 0, bulletOffset1) * transform.rotation;
        Instantiate(bullet, transform.position, bulletRotation1);
        
        float bulletOffset2 = Random.Range(0, 1);
        Quaternion bulletRotation2 = Quaternion.Euler(0, 0, bulletOffset2) * transform.rotation;
        Instantiate(bullet, transform.position, bulletRotation2);

        float bulletOffset3 = Random.Range(0, 1);
        Quaternion bulletRotation3 = Quaternion.Euler(0, 0, bulletOffset3) * transform.rotation;
        Instantiate(bullet, transform.position, bulletRotation3);
    }
    async void Reload()
    {
        if (ammo == maxAmmo) return;
        if (isReloading) return;
        if (mags <= 0) return;
        isReloading = true;
        print("reloading");
        print(mags.ToString());
        await new WaitForSeconds(2);
        ammo = maxAmmo;
        mags -= 1;
        isReloading = false;
    }
}
