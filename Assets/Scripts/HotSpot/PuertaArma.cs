using UnityEngine;

public class PuertaArma : MonoBehaviour
{
    private bool openDoor = false;

    [SerializeField] private Transform door;
    [SerializeField] private Transform initialPoint;
    [SerializeField] private Transform finalPoint;

    [SerializeField] private float velocity;



    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<WeaponShootPoint>(out WeaponShootPoint weapon))
        {
            Debug.Log("no puedo abrirme peor pillo el trigger");
            if (weapon.canOpenDoor)
            {
                openDoor = true;
                DoorInitialMovement();
                Debug.Log("Me abro");
            }
            
        
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<WeaponShootPoint>(out WeaponShootPoint weapon))
        {
            if (weapon.canOpenDoor)
            {
                openDoor = false;

           
                door.position = initialPoint.position;
            }
            
            
        }
    }

//si transform position no es el que quieres que lo mueva, si son no haces nada
    private void DoorInitialMovement()
    {
        //

        if (door.transform.position.x >= finalPoint.transform.position.x)
        
            door.position = Vector3.MoveTowards(door.transform.position, finalPoint.transform.position, velocity *Time.deltaTime);
        //transform.Translate(Vector3.back * velocity);
        else
        {
            door.transform.position = finalPoint.position;
        }
        
    }

}
