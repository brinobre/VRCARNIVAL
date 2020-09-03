using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    //Audiosources for the gun
    private AudioSource FireAudio;

    /* Declaring all public variables*/
    [SerializeField] private GameObject impactEffect;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] private ParticleSystem ShootLight;
    [SerializeField] Camera fpsCam;
    [SerializeField] private float impactForce = 30;
    [SerializeField] private float fireRate = 15;
    [SerializeField] private float nextTimeToFire = 0f;

    [SerializeField] private int maxAmmo = 10;
    private int currentAmmo;
    [SerializeField] private float reloadTime = 1f;
    private bool isReloading = false;

    // The animations used for the gun
    private Animator shootAnim;
    private Animator reloadAnim;

    // Declaring Oculus OVR controllers


    private void Start()
    {
        shootAnim = GetComponent<Animator>();

        currentAmmo = maxAmmo;
        FireAudio = GetComponent<AudioSource>();
    }


    //Updating every frame
    void Update()
    {

        if (isReloading)
            return;

        if (currentAmmo <= 0f)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

            FireAudio.Play();

        }




    }

    //Reload method for the gun
    IEnumerator Reload()
    {
        isReloading = true;

        reloadAnim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        reloadAnim.SetBool("Reloading", false);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    // Shooting method for the gun
    void Shoot()
    {
        ShootLight.Play();

        shootAnim.SetTrigger("FireTrigg");

        currentAmmo--;
        /**
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            ShootingTarget target = hit.transform.GetComponent<ShootingTarget>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        
        }**/
    }
}
