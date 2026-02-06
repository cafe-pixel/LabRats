using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Vector3 initialPosition;
    private Vector3 finalPosition;

    public float zFinalDistance = 2f;
    public float speed = 2f;

    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
        initialPosition = transform.localPosition;
        finalPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z + zFinalDistance);
    }

    void Update()
    {
        if (isOpening)
            OpeningDoor();

        if (isClosing)
            ClosingDoor();
    }

    private void OpeningDoor()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, finalPosition, speed * Time.deltaTime);
    }

    private void ClosingDoor()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, speed * Time.deltaTime);
    }

    public void PlayerInTrigger()
    {
        isOpening = true;
        isClosing = false;
    }

    public void PlayerOutTrigger()
    {
        isClosing = true;
        isOpening = false;
    }
}