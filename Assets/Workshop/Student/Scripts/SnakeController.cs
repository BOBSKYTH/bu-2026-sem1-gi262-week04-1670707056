using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Student
{

    public class SnakeController : MonoBehaviour
    {
        public GameObject snakeSegmentPrefab;
        private LinkedList<GameObject> snakeBody = new LinkedList<GameObject>();
        private Vector3 direction = Vector3.right;
        public float moveSpeed = 0.5f;
        private InputAction moveAction;
        private InputAction growAction;

        void Awake()
        {
            moveAction = InputSystem.actions.FindAction("Move");
            growAction = InputSystem.actions.FindAction("Grow");
        }

        void Start()
        {
            // Add the initial head of the snake
            GameObject head = Instantiate(snakeSegmentPrefab, transform.position, Quaternion.identity);
            snakeBody.AddFirst(head);
            StartCoroutine(MoveSnake());
        }

        void Update()
        {
            // Update direction based on input
            var changedDirection = moveAction.ReadValue<Vector2>();
            changedDirection.Normalize();
            if (changedDirection != Vector2.zero)
            {
                direction = changedDirection;
            }
            
            if (growAction.triggered)
            {
                GrowSnake();
            }
        }

        IEnumerator MoveSnake()
        {
            while (true)
            {
                yield return new WaitForSeconds(moveSpeed);
                Move();
            }
        }

        void Move()
        {
            Vector3 newPosition = snakeBody.First.Value.transform.position + direction;

            // 1. Move the tail to the head's new position
        }

        public void GrowSnake()
        {
            // 2. Instantiate a new segment at the tail's position
        }
    }


}