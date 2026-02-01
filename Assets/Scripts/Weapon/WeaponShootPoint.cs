using UnityEngine;

public class WeaponShootPoint : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float newShoot = 0f;
    [SerializeField] private float cooldown = 3.5f;
    [SerializeField] private CameraRotation playerCamera;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioBullet;
    

    [SerializeField] private int shootKey = 0;

   [SerializeField] private bool canShoot;
    //necesito una pistola, una bala, un lugar donde instanciarla y luego de ahí darle fuerza


    public void NowCanShoot()
    {
        canShoot = true;
    }

    private void Update()
    {
        if (Time.timeScale == 0) {return;}
        
        if (Input.GetMouseButtonDown(shootKey) && Time.time >= newShoot && canShoot)
        {
            Shoot();
            newShoot = cooldown + Time.time;
            if (audioSource != null && audioBullet != null)
            {
                audioSource.PlayOneShot(audioBullet);
                Debug.Log("Sonido Bala");
            }
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
