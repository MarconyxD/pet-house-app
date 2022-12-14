using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Scrolling : MonoBehaviour
{
    float speed = 2000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().cameraParada)
        {
            float moveVertical = Input.GetAxis("Mouse Y");

            transform.position += new Vector3(0.0f, -moveVertical * Time.deltaTime * speed, 0.0f);

            if (transform.position.y > 0.0f) transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            if (transform.position.y < -712.0f) transform.position = new Vector3(0.0f, -712.0f, -10.0f);
        }
        if (GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().cameraParada) transform.position = new Vector3(0.0f, 0.0f, -10.0f);
    }
}
