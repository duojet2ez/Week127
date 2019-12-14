﻿/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

[RequireComponent(typeof(Collider2D))]
public class characterMovement : MonoBehaviour
{
    #region Public Fields
    public LayerMask groundLayer;
    #endregion

    #region Private Fields
    Collider2D col;
    Rigidbody2D rb;
    SpriteRenderer characterRenderer;
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