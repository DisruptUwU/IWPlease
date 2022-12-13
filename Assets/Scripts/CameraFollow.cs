using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform firePoint;

    float xRotation;
    float yRotation;

    private GameObject skillManager;

    private void Start()
    {
        skillManager = GameObject.FindGameObjectWithTag("SkillManager");
    }

    private void Update()
    {
        var SkillManager = skillManager.GetComponent<SkillManager>().SkillSelect;
        float mouseX;
        float mouseY;

        if (SkillManager == true)
        {
            mouseX = 0;
            mouseY = 0;
        }
        else
        {
            mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        }

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        firePoint.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
