using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionSeno : MonoBehaviour
{
    float sinCenterX;
    [Range(0f, 3f)]
    [SerializeField] private float amplitude;

    [Range(0f, 3f)]
    [SerializeField] private float frecuency;

    [SerializeField] private bool inverted;

    void Start()
    {
        sinCenterX = transform.position.x;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        float sin = Mathf.Sin(pos.y * frecuency) * amplitude;
        if (inverted) sin *= -1;
        pos.x = sinCenterX + sin;

        transform.position = pos;
    }
}