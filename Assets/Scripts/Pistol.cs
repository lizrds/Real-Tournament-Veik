using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (isReloading == true)
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
        float bulletOffset = Random.Range(0, 10);
        Quaternion bulletRotation = Quaternion.Euler(0, 0, bulletOffset) * transform.rotation;

        Instantiate(bullet, transform.position, bulletRotation);
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
        isReloading=false;
    }
}
