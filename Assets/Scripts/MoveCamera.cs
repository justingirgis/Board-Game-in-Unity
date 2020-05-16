using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float cameraSpeed = 0;
    private float currentZoom;
    private float zoomFactor=10f;
    [SerializeField]
    private float zoomLerpSpeed = 10f;
    void Start()
    {
        currentZoom = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= mouseScrollWheel * zoomFactor;
        currentZoom = Mathf.Clamp(currentZoom, 5f, 40f);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, currentZoom, Time.deltaTime * zoomLerpSpeed);
        getInput();
    }
    private void getInput()
    {   
        //this work's better than a switch or else if statement because it allows for diagonal movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);

        }

    }
    
}
