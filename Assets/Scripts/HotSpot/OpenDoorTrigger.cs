using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    public OpenDoor openDoorScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoorScript.PlayerInTrigger();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoorScript.PlayerOutTrigger();
        }
    }
}







/*  [SerializeField] private int nEnemies;
  private bool openDoor = false;

  [SerializeField] private Transform door;
  [SerializeField] private Transform initialPoint;
  [SerializeField] private Transform finalPoint;

  [SerializeField] private float velocity;



  private void OnTriggerStay(Collider other)
  {
      if (other.TryGetComponent<EnemyCounter>(out EnemyCounter enemyN))
      {
          if (enemyN.enemyCounter == nEnemies) openDoor = true;
          DoorInitialMovement();

      }
  }



  private void OnTriggerExit(Collider other)
  {
      if (other.TryGetComponent<EnemyCounter>(out EnemyCounter enemyN))
      {
          if (enemyN.enemyCounter == nEnemies)
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
*/

