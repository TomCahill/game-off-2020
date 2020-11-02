using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Transform background1;
    public Transform background2;

    private float size;

    public float interpolationTime = 0.2f;

    void Start() {
        size = background1.GetComponent<BoxCollider2D>().size.y;
    }

    void FixedUpdate() {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z - 10);

        transform.position = Vector3.Lerp(transform.position, targetPos, interpolationTime);

        if (transform.position.y >= background2.position.y) {
            background1.position = new Vector3(background1.position.x, background2.position.y + size, background1.position.z);
            FlipBackgrounds();
        }

        if (transform.position.y < background1.position.y) {
            background1.position = new Vector3(background2.position.x, background1.position.y - size, background2.position.z);
            FlipBackgrounds();
        }
    }

    private void FlipBackgrounds() {
        Transform temp = background1;
        background1 = background2;
        background2 = temp;
    }

}
