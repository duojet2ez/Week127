/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

[RequireComponent(typeof(Collider2D))]
public class characterMovement : MonoBehaviour
{
    #region Public Fields
    public LayerMask groundLayer;

    #region Events
    public static event Action<onSoftEdgeArgs> onFallableEdge;
    public static event Action<onHardEdgeArgs> onCliff;
    public static event Action<onSoftEdgeArgs> onWallHit;
    #endregion

    #endregion

    #region Private Fields
    Collider2D col;
    Rigidbody2D rb;
    SpriteRenderer characterRenderer;
    [SerializeField] float speed = 1;
    [Range(0, 3)]
    [SerializeField] int maxFallDown = 1;
    [SerializeField] float maxDistance = 20f;
    [SerializeField, Range(1, 2)] float forwardRaycastMultiplier = 1.15f;
    [SerializeField, Range(0.1f, 0.4f)] float raycastDownLeeway  = 0.2f;

    onSoftEdgeArgs fallableArgs = new onSoftEdgeArgs() { willDoSomething = false};
    onHardEdgeArgs cliffArgs = new onHardEdgeArgs() { willDoSomething = false};

    bool canMoveForward = true;
    float disabledTime;
    int currentSide = 1;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void MovePlayer()
    {
        /*
         
        1 is left
        -1 right
         
         */
        if (Input.GetAxisRaw("Horizontal") * currentSide >= 0)
        {
            if (canMoveForward && Input.GetAxisRaw("Horizontal") != 0)
            {
                rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * transform.right * currentSide);
            }
        }
        else
        {
            characterRenderer.flipX = !characterRenderer.flipX;
            currentSide = currentSide * -1;
        }
    }
    private void CheckGround()
    {
        int side = characterRenderer.flipX ? -1 : 1;
        var hit = Physics2D.Raycast(new Vector2(transform.position.x + currentSide * (col.bounds.extents.x * forwardRaycastMultiplier + col.offset.x),
                                    transform.position.y + col.bounds.extents.y), -transform.up, maxDistance, groundLayer);


        if (hit)
        {
#if UNITY_EDITOR
            Debug.DrawRay(transform.position + (col.bounds.extents.x *forwardRaycastMultiplier + col.offset.x ) * currentSide * transform.right + transform.up*col.bounds.extents.y, -transform.up * hit.distance, Color.red);
            Debug.Log(hit.collider.gameObject.name);
#endif

            if (hit.distance > col.bounds.size.y + raycastDownLeeway)
            {
                if (hit.distance < maxFallDown + col.bounds.size.y)
                {
#if UNITY_EDITOR
                    Debug.Log("onFallableGround");
#endif
                    onFallableEdge?.Invoke(fallableArgs);

                    if (fallableArgs.willDoSomething)
                    {
                        disabledTime = Time.time + fallableArgs.timeToWait;
                        fallableArgs.resetValues();
                    }


                }
                else
                {
                    canMoveForward = false;
                    onCliff?.Invoke(cliffArgs);
                    if (cliffArgs.willDoSomething)
                    {
                        disabledTime = Time.time + cliffArgs.timeToWait;
                        cliffArgs.resetValues();
                    }
                }
            }
            else
            {
                canMoveForward = true; 
            }

        }
        else
        {
#if UNITY_EDITOR
            Debug.DrawRay(transform.position + transform.up * col.bounds.extents.y+ (col.bounds.extents.x * forwardRaycastMultiplier + col.offset.x) * currentSide * transform.right, -transform.up * maxDistance, Color.red);
#endif
            canMoveForward = false;
            onCliff?.Invoke(cliffArgs);
            if (cliffArgs.willDoSomething)
            {
                disabledTime = Time.time + cliffArgs.timeToWait;
                cliffArgs.resetValues();
            }

        }
    }
    #endregion


    #if true
    #region Unity API

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }
 
    void FixedUpdate()
    {
        if (disabledTime < Time.time)
        {
            CheckGround();
            MovePlayer();
        }
    }





    #endregion
#endif

}

public class onSoftEdgeArgs
{
    public RaycastHit2D hit;
    public float timeToWait;
    public bool willDoSomething = false;

    public void resetValues()
    {
        timeToWait = 0;
        willDoSomething = false;
    }
}

public class onHardEdgeArgs
{
    public float timeToWait;
    public bool willDoSomething = false;
    public RaycastHit2D hit;

    public void resetValues()
    {
        timeToWait = 0;
        willDoSomething = false;
    }
}