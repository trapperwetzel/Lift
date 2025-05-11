using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraPan : MonoBehaviour 
{
    [SerializeField] private float panSpeed = 2f;
    [SerializeField] private float panDistance = 5f;
    [SerializeField] private bool reverse = false;

    private Vector3 startPosition;
    private float timer;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime * panSpeed;
        float offset = Mathf.Sin(timer) * panDistance;

        Vector3 newPosition = startPosition + new Vector3(offset, 0, 0);

        if (reverse)
            newPosition = startPosition - new Vector3(offset, 0, 0);

        transform.position = newPosition;
    }
}