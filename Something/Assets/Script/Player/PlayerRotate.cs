using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public GameObject RotateTarget;

    [SerializeField]
    private float RotateSpeed;
    [SerializeField]
    private float MinLimitAngleX;
    [SerializeField]
    private float MaxLimitAngleX;

    public float _angleX = 0f;
    public float _angleY = 0f;

    public void Rotate(float mouseX, float mouseY)
    {
        _angleX -= mouseY * RotateSpeed * Time.deltaTime;
        _angleY += mouseX * RotateSpeed * Time.deltaTime;
        CheckAngle(_angleX, _angleY);
        Vector3 newAngle = new Vector3(_angleX, _angleY, 0f);

        RotateTarget.transform.rotation = Quaternion.Euler(newAngle);
    }
    
    private void CheckAngle(float angleX, float angleY)
    {
        _angleX = Mathf.Clamp(angleX, MinLimitAngleX, MaxLimitAngleX);

        if (-360f < angleY)
            angleY += 360f;
        else if (360f < angleY)
            angleY -= 360f;
    }
}