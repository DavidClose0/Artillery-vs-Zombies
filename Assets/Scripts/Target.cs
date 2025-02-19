using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            this.transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            this.transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            this.transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        }

        float xPos = Mathf.Clamp(this.transform.position.x, -18, 16);
        float zPos = Mathf.Clamp(this.transform.position.z, -12, 12);

        this.transform.position = new Vector3(xPos, 0, zPos);
    }
}
