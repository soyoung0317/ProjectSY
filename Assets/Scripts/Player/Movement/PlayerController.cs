using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isDashing;
    private float move_Speed = 3.0f;
    private float dash_Speed = 10.0f;

    public Vector2 moveDir;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();  
        animator = GetComponent<Animator>();
        moveDir = Vector2.zero;
        isDashing = false;
    }
    private void FixedUpdate()
    {
        if(!isDashing)
        {
            Vector2 nextMove = moveDir * move_Speed * Time.fixedDeltaTime;
            rigidBody.MovePosition(rigidBody.position + nextMove);
        }
    }
    private void Update()
    {
    }

    private void LateUpdate()
    {
        if (!isDashing && moveDir.x != 0 )
        {
            float localScale = Mathf.Sign(moveDir.x);
            transform.localScale = new Vector3(localScale, 1, 1);
        }
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 input = inputValue.Get<Vector2>();

        if (input.magnitude < 0.1f)
            moveDir = Vector2.zero;
        else
            moveDir = input;

        animator.SetFloat("Speed", moveDir.magnitude);
    }

    void OnDash(InputValue inputValue)
    {
       if (inputValue.isPressed && !isDashing && moveDir != Vector2.zero)
        {
            StartCoroutine(DashRoutine());
        }
    }
    IEnumerator DashRoutine()
    {
        isDashing = true;

        float dashDuration = 0.2f;
        float startTime = 0f;

        while (startTime < dashDuration)
        {
            startTime += Time.fixedDeltaTime;
            rigidBody.MovePosition(rigidBody.position + moveDir * dash_Speed * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }

        isDashing = false;
    }
}
