using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Instance
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rot;
    private bool gyroActive;
    private float x;
    private float y;
    private float z;

    public GameObject completeUI;

    public void EnableGyro()
    {
        // Debug.Log("Gyro Check");
        if (gyroActive)
            return;

        if(SystemInfo.supportsGyroscope)
        {
            // Debug.Log("Gyro Found");
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = true;
        }
    }

    public void Update()
    {
        if(gyroActive)
        {
            rot = gyro.attitude;
            x = gyro.rotationRate.x;
            y = gyro.rotationRate.y;
            // z = gyro.rotationRate.z;
        }
    }

    public void HideMenu()
    {
        completeUI.SetActive(false);
    }

    public Quaternion GetGyroRotation()
    {
        return rot;
    }

    public float GetX()
    {
        return x;
    }

    public float GetY()
    {
        return y;
    }

    bool gameHasEnded = false;

    public void Restart()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            // restart();
            Invoke("CallRestart", 1);
        }
    }

    void CallRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public float GetZ()
    //{
    //    return z;
    //}
}

