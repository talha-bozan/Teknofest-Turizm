using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{   
    public Transform playerBody;
    float yukariBak = 0f;
    float mouseSens = 100f;   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        Debug.Log(yukariBak);
        yukariBak -= mouseY;
        yukariBak = Mathf.Clamp(yukariBak, -90f, 90f);
        transform.localRotation = Quaternion.Euler(yukariBak, 0f, 0f);
        playerBody.Rotate(Vector3.up*mouseX);

    }
}
