using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] Vector3 rotateVector;

    private void FixedUpdate() => transform.Rotate(rotateSpeed * Time.deltaTime * rotateVector.normalized);
}
