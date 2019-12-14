/*
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

    #endregion

    #region Private Fields
    Collider2D col;
    [SerializeField] float maxDistance = 20f;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion


    #if true
    #region Unity API

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }
 
    void FixedUpdate()
    {
        var hit = Physics2D.Raycast(new Vector2(transform.position.x + (col.bounds.extents.x + col.offset.x) * transform.right.x,
                                    transform.position.y), -transform.up, maxDistance);

#if UNITY_EDITOR
        Debug.DrawRay(transform.position + (col.bounds.extents.x + col.offset.x) * transform.right, -transform.up * maxDistance, Color.red); 
#endif
        if(hit)
        {

        }
    }

    #endregion
#endif

}