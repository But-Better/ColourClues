﻿using System;
using DefaultNamespace;
using Mirror;
using UnityEngine;
public class ColorButton : MonoBehaviour {

    [SerializeField] private ColorClue activatableColor;
    [SerializeField] private ActivatableObject activatableObject;

    private ColorOwner currentActivator;

    private void OnCollisionEnter2D(Collision2D other) {
        other.gameObject.TryGetComponent(out ColorOwner collidedColorOwner);

        if(collidedColorOwner == null) {
            return;
        }

        if(currentActivator == null && collidedColorOwner.ColorClue != activatableColor) {
            return;
        }

        currentActivator = collidedColorOwner;
        activatableObject.Activate(collidedColorOwner);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.TryGetComponent(out ColorOwner collidedColorOwner);

        if(collidedColorOwner == null) {
            return;
        }

        if(currentActivator == null) {
            return;
        }

        if(currentActivator != collidedColorOwner) {
            return;
        }

        activatableObject.Deactivate(currentActivator);
        currentActivator = null;
    }
}