using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [SerializeField]
    float zoomFactor = 1.0f;

    [SerializeField]
    float zoomSpeed = 5.0f;

    private float originalSize = 0.1f;

    private Camera thisCamera;

    private void Start(){
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);

        if(Player.rend.sortingOrder == 0){
            float targetSize = originalSize * zoomFactor;
                if (targetSize != thisCamera.orthographicSize) {
                    thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
                }
        }

        if(Player.rend.sortingOrder == 5){
            float targetSize = originalSize * 1;
                if (targetSize != thisCamera.orthographicSize) {
                    thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
                }
        }
    }

    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }
}
