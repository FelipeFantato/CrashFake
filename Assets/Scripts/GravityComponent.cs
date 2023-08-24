using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComponent : MonoBehaviour
{
    private const float gravity = -9.81f;
    [SerializeField] private float gravityScale = 3f;
    Vector3 gravityVelocity;

    private void FixedUpdate()
    {
        gravityVelocity.y += gravity * gravityScale * Time.deltaTime;
      //  transform.Translate(gravityVelocity);
    }
}
