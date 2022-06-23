using System.Collections.Generic;
using UnityEngine;

namespace Components {
    [RequireComponent(typeof(Camera))]
    public class LevelCamera : MonoBehaviour {

        [SerializeField] private float sizeChangeSpeed = 1;
        [SerializeField] private float minSize = 3;
        [SerializeField] private Vector2 cameraOffset = new Vector2(0, 0);

        private List<ColorOwner> focusTargets = new List<ColorOwner>();
        private Camera camera;

        private void Awake() {
            camera = GetComponent<Camera>();
        }

        private void Update() {
            var averagePosition = new Vector3();
            foreach(var player in focusTargets) {
                averagePosition += player.transform.position;
            }
            averagePosition /= focusTargets.Count;

            var targetCameraPosition = new Vector2(averagePosition.x, averagePosition.y);

            var biggestDistance = 0f;
            foreach(var player in focusTargets) {
                Vector2 playerPosition = player.transform.position;
                var playerDistance = Vector2.Distance(playerPosition, targetCameraPosition);

                if(biggestDistance < playerDistance) {
                    biggestDistance = playerDistance;
                }
            }

            var targetSize = biggestDistance / 2 + minSize;

            if(Vector2.Distance(transform.position, targetCameraPosition) > 1) {
                var direction = targetCameraPosition - (Vector2) transform.position + cameraOffset;
                transform.position += (Vector3) direction * Time.deltaTime;
            }


            var cameraSizeDistance = Mathf.Abs(camera.orthographicSize - targetSize);
            if(cameraSizeDistance < 0.1) {
                return;
            }

            if(camera.orthographicSize > targetSize) {
                camera.orthographicSize -= Time.deltaTime * cameraSizeDistance * sizeChangeSpeed;
            } else {
                camera.orthographicSize += Time.deltaTime * cameraSizeDistance * sizeChangeSpeed;
            }
        }

        public void RegisterFocusTarget(ColorOwner owner) {
            if(!focusTargets.Contains(owner)) {
                focusTargets.Add(owner);
            }
        }

        public void DeregisterFocusTarget(ColorOwner owner) {
            if(focusTargets.Contains(owner)) {
                focusTargets.Remove(owner);
            }
        }
    }
}