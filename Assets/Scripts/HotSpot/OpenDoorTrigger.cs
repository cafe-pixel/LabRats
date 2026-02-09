using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    public OpenDoor openDoorScript;
    [SerializeField] private int nEnemies;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCounter>(out EnemyCounter enemyN))
        {
            if (other.CompareTag("Player") && enemyN.enemyCounter >= nEnemies)
            {
                openDoorScript.PlayerInTrigger();
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<EnemyCounter>(out EnemyCounter enemyN))
        {
            if (other.CompareTag("Player") && enemyN.enemyCounter >= nEnemies)
            {
                openDoorScript.PlayerOutTrigger();
                enemyN.enemyCounter = 0;
                
                Debug.Log("La vida del player es " + enemyN.enemyCounter);
            }
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

