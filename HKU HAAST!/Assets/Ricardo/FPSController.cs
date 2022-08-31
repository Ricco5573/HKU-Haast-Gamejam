using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;
    float rotationY = 0;
    public Camera playerCamera;
    CharacterController characterController;
    RaycastHit hit;
    [SerializeField]
    private Slider Health;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY += Input.GetAxis("Mouse X") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        if (Input.GetMouseButtonDown(0))
        {

            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green, 2);
            Debug.Log("Shoot!");
            Debug.Log(hit.transform.tag);
            if(hit.transform.tag == "Target")
            {
                Health.value += 0.05f;
                Target target = hit.transform.GetComponent<Target>();
                target.Perish();
            }
        }
        Health.value -= 0.0001f;
    }
}
