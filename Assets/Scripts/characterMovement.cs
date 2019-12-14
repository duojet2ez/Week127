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
    Collider2D collider;

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion


    #if true
    #region Unity API

    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
 
    void FixedUpdate()
    {
        Physics2D.Raycast();
    }

    #endregion
    #endif
 
}