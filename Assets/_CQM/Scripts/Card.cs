using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CQM {
    public class Card : MonoBehaviour {
        private float _startPosX;
        private float _startPosY;
        private bool _isBeingHeld = false;

        private Camera _camera = null;

        private Camera GetMainCamera {
            get {
                if (_camera == null) 
                    _camera = Camera.main;

                return _camera;
            }
        }

        private void Update() {
            if (_isBeingHeld) {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = GetMainCamera.ScreenToWorldPoint(mousePos);

                gameObject.transform.localPosition = new Vector3(mousePos.x - _startPosX, mousePos.y - _startPosY, 0f);
            }
        }

        private void OnMouseDown() {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = GetMainCamera.ScreenToWorldPoint(mousePos);
            var localPosition = transform.localPosition;
            _startPosX = mousePos.x - localPosition.x;
            _startPosY = mousePos.y - localPosition.y;
            
            _isBeingHeld = true;
        }

        private void OnMouseUp() {
            _isBeingHeld = false;
        }
    }
}