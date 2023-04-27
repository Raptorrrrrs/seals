using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
        public float sensX;
        public float sensY;

        public Transform orientation;
        public Transform flashlight;
        public Transform hand;

        float xRotation;
        float yRotation;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            flashlight.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            hand.rotation = Quaternion.Euler(xRotation, yRotation, yRotation);

            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
}
