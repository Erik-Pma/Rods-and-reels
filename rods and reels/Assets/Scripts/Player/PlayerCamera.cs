using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Camera cam;

    public Vector3 positionOffset = Vector3.zero;
    public Vector3 rotationOffset = Vector3.zero;

    Vector3 currentPos;
    Vector3 nextPos = Vector3.zero;
    float elapsedTime = 0f;
    float desiredDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cam.transform.rotation = Quaternion.Euler(rotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z + positionOffset.z);

        nextPos = transform.position + positionOffset;
        nextPos.x = 0;

        //cam.transform.position = Vector3.Lerp(currentPos, nextPos, Mathf.SmoothStep(0, 1, Time.deltaTime));
        cam.transform.position = nextPos;
        cam.transform.rotation = Quaternion.Euler(rotationOffset);
    }


}
