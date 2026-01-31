using UnityEngine;

public class WeaponShootPoint : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float newShoot = 0f;
    [SerializeField] private float cooldown = 3.5f;
    [SerializeField] private CameraRotation playerCamera;

    [SerializeField] private int shootKey = 0;

    private bool canShoot = false;
    //necesito una pistola, una bala, un lugar donde instanciarla y luego de ahí darle fuerza


    

    private void Update()
    {
        if (Input.GetMouseButtonDown(shootKey) && Time.time >= newShoot && canShoot)
        {
            Shoot();
            newShoot = cooldown + Time.time;
        }

        //Quaternion rot = this.transform.rotation;
        //this.transform.rotation = new Quaternion(playerCamera.transform.localRotation.x, rot.y, rot.z, rot.w);
    }

    private void Shoot()
    {
        if (playerCamera.lookPointIsNull)
        {
            Bullet b = Instantiate(bullet, shootPoint.position, playerCamera.transform.rotation).GetComponent<Bullet>();
            b.dir = playerCamera.transform.forward;
        }
        else
        {
            Bullet b = Instantiate(bullet, shootPoint.position, playerCamera.transform.rotation).GetComponent<Bullet>();
            b.dir = (playerCamera.lookPoint - shootPoint.position).normalized;
        }
        
    }
}
