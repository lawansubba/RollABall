using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    public Vector3 planeRot;

    float x = 0;
    float y = 0;

    void Start()
    {
        GameManager.Instance.EnableGyro();
        Invoke("HideLevelPanel", 1);
    }

    // Update is called once per frame
    void Update()
    {
        x = GameManager.Instance.GetX();
        y = GameManager.Instance.GetY();
        planeRot = GetComponent<Transform>().eulerAngles;
        
        if ((x > 0.2) && (planeRot.x >= 349 || planeRot.x <= 11))
        {
            
            transform.Rotate(-0.5f, 0, 0, Space.World);
        }

        if ((x < -0.2) && (planeRot.x <= 10 || planeRot.x >= 348))
        {
            transform.Rotate(0.5f, 0, 0, Space.World);
        }

        if (y > 0.2 && (planeRot.z >= 349 || planeRot.z <= 11))
        {
            transform.Rotate(0, 0, -0.5f, Space.Self);
        }

        if (y < -0.2 && (planeRot.z <= 10 || planeRot.z >= 348))
        {
            transform.Rotate(0, 0, 0.5f, Space.Self);
        }
    }

    void HideLevelPanel()
    {
        GameManager.Instance.HideMenu();
    }
}