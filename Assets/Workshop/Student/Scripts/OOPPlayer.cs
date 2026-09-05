using UnityEngine;
using UnityEngine.InputSystem;

namespace Student
{
    public class OOPPlayer : Character
    {
        public Inventory inventory;

        private InputAction actionMove;

        private void Awake()
        {
            actionMove = InputSystem.actions.FindAction("Move");
        }

        public void Start()
        {
            PrintInfo();
            GetRemainEnergy();
        }

        public void Update()
        {
            if (actionMove.triggered)
            {
                Vector2 moveDirection = actionMove.ReadValue<Vector2>();
                Move(moveDirection);
            }
        }

        public void Attack(OOPEnemy _enemy)
        {
            _enemy.energy -= AttackPoint;
            Debug.Log(_enemy.name + " is energy " + _enemy.energy);
        }

        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }
    }
}