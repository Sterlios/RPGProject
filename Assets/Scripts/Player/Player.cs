using UnityEngine;

namespace Player
{
    class Player : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationAngle;

        private void Update()
        {
            Rotate();
            Move();
        }

        private void Move()
        {
            float movement = Input.GetAxis("Vertical");
            
            if (movement != 0)
            {
                Vector3 target = transform.position + transform.forward * movement;
                
                transform.position = Vector3.MoveTowards(transform.position, target, _movementSpeed * Time.deltaTime);
            }
        }

        private void Rotate()
        {
            float rotationSpeed = Input.GetAxis("Horizontal");

            if (rotationSpeed != 0)
            {
                transform.Rotate(Vector3.up, _rotationAngle * rotationSpeed);
            }
        }
    }
}
