using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    public float timeBeTweenShooting, spread, range, reloadTime, timeBetweenShot;
    public int magazineSize, bulletPerTap;
    public bool allowButtonHold;
    int bulltsLeft, bulletsShot;

    //bools
    bool shooting, readToShoot, realoading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulltsLeft < magazineSize && !realoading && bulltsLeft > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readToShoot = false;

        //Raycast
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                            }
        }

        bulltsLeft--;
        Invoke("ResetShot", timeBeTweenShooting);
    }

    private void ResetShot()
    {
        readToShoot = true;
    }
}
