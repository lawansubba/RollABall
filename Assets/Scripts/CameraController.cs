using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        // offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update() {
        // Debug.Log("Update Camera");
        // transform.position = player.transform.position + offset;
        // Debug.Log(transform.position);
        // transform.Translate(Vector3.right * Time.deltaTime);
        //transform.position = new Vector3(1f + player.transform.position.x, transform.position.y, -27.3f + player.transform.position.z);

        //btransform.eulerAngles = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, 0);
        //transform.LookAt(player.transform);
        
        //Debug.Log("1" + transform.position);
        // Debug.Log("2" + player.transform.position);
    }
}

