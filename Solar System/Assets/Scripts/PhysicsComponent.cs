using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : MonoBehaviour
{
    [SerializeField] static HashSet<PhysicsComponent> Objects = new HashSet<PhysicsComponent>();
    [SerializeField] static float G = 1.5f;

    [SerializeField] float mass;
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 velocity;


    void Awake()
    {
        Objects.Add(this);
        position = transform.position;
    }

    void FixedUpdate()
    {
        foreach (PhysicsComponent _body in Objects)
        {
            if (_body != this)
            {
                float sqrRaduis = (_body.position - position).sqrMagnitude;
                Vector3 direction = (_body.position - position).normalized;
                Vector3 force = direction * _body.Mass * G / sqrRaduis;

                velocity += force * Time.deltaTime;
            }
        }

        position += velocity * Time.deltaTime;
        transform.position = position;
    }

    public float Mass => mass;

    public Vector3 Position => position;

    public Vector3 Velocity => velocity;
}
