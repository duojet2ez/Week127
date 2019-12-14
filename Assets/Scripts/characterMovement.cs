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
    #endregion

    #endregion

    #region Private Fields
    Collider2D col;
    Rigidbody2D rb;
    SpriteRenderer characterRenderer;
    [Range(0, 3)]
    [SerializeField] int maxFallDown = 1;
    [SerializeField] float maxDistance = 20f;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    bool canMoveForward = true;
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
        int side = characterRenderer.flipX ? 1 : -1;
        var hit = Physics2D.Raycast(new Vector2(transform.position.x + side * (col.bounds.extents.x + col.offset.x*0.995f),
                                    transform.position.y), -transform.up, maxDistance, groundLayer);


        if(hit)
        {
#if UNITY_EDITOR
            Debug.DrawRay(transform.position + (col.bounds.extents.x + col.offset.x) * side * transform.right, -transform.up * hit.distance, Color.cyan);
            Debug.Log(hit.collider.gameObject.name);
#endif
            if (hit.distance > col.bounds.extents.y && hit.distance > maxFallDown + col.bounds.extents.y)
            {

            }
            else
            {

            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.DrawRay(transform.position + (col.bounds.extents.x + col.offset.x) * side * transform.right, -transform.up * maxDistance, Color.red);
#endif



        }
    }

    #endregion
#endif

}

public struct onSoftEdgeArgs
{

}

public struct 