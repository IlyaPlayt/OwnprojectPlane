using System;
using UnityEngine;
using UnityEngine.Timeline;

public class AirplaneController : MonoBehaviour
{
    public float forwardSpeed;
    [SerializeField] private float horizontalAngle;
    [SerializeField] private float fallingSpeed;
    [SerializeField] private Transform defaultPosition;

    private float activeHorizontalAngle;
    private bool moovable = true;

    private void Start()
    {
        moovable = false;
    }

    void FixedUpdate()
    {
        if (!moovable) return;
        activeHorizontalAngle = Input.GetAxisRaw("Horizontal");

        transform.position += transform.forward * forwardSpeed;

        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.Euler(Input.GetAxisRaw("Lifting") + transform.rotation.eulerAngles.x,
                activeHorizontalAngle + transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z), .5f);

        var rotation = transform.rotation;
        transform.rotation = Quaternion.Lerp(rotation, Quaternion.Euler(new Vector3(rotation.eulerAngles.x,
            rotation.eulerAngles.y, -activeHorizontalAngle * horizontalAngle)), 0.03f);
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Lifting") == 0)
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rotation.eulerAngles.y, 0), 0.02f);
            transform.position += -transform.up * fallingSpeed;
        }
    }

    public void Deactivate()
    {
        moovable = false;
    }

    public void Activate()
    {
        transform.position = defaultPosition.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        moovable = true;
    }
}