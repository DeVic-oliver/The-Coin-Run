using UnityEngine;

namespace Assets.Scripts.Player.State_Machine.Movement
{
    public class Running : MoveStateBase
    {
        public Running(MovementStateMachine stateMachine, Rigidbody rigidbody) : base(stateMachine, rigidbody)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnFixedUpdate()
        {
            float yVelocity = _rigidbody.velocity.y;
            _rigidbody.velocity = new Vector3(GetMovementVelocity().x, yVelocity, GetMovementVelocity().z);
        }

        private Vector3 GetMovementVelocity()
        {
            float xVelocity = _stateMachine.GetVelocity().x;
            float zVelocity = _stateMachine.GetVelocity().z;
            Vector3 velocity = new Vector3(xVelocity, 0, zVelocity) * GetFixedDeltaTimeMultipliedBySpeed();
            return velocity;
        }

        private float GetFixedDeltaTimeMultipliedBySpeed()
        {
            return Time.fixedDeltaTime * _stateMachine.GetMoveSpeed();
        }

        public override void OnUpdate()
        {
            if (!_stateMachine.IsRunning())
            {
                _stateMachine.SwitchState(_stateMachine.StandbyState);
            }

            if (_stateMachine.HasJumpActionMade())
            {
                _stateMachine.SwitchState(_stateMachine.JumpingState);
            }

        }
    }
}