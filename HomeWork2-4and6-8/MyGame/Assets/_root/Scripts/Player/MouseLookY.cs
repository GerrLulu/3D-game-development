using UnityEngine;

namespace Player
{
    public class MouseLookY : MonoBehaviour
    {
        [SerializeField] private float _sensVertical = 7f;
        [SerializeField] private float _minVertical = -50f;
        [SerializeField] private float _maxVertical = 50f;

        private float rotationX = 0f;


        void Update()
        {
            rotationX -= Input.GetAxis("Mouse Y") * _sensVertical;
            rotationX = Mathf.Clamp(rotationX, _minVertical, _maxVertical);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}