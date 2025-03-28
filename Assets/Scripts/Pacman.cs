using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.SetDirection(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.SetDirection(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.SetDirection(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.SetDirection(Vector2.left);
        }

        RotatePacman(movement.direction);
    }

    public void ResetState()
    {
        enabled = true;
        movement.ResetState();
        gameObject.SetActive(true);
    }

    private void RotatePacman(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
}
