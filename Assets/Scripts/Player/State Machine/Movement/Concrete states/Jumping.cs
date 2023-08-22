namespace Assets.Scripts.Player.State_Machine.Movement
{
    using UnityEngine;

    public class Jumping : MoveStateBase
    {
        private bool _canSwitchState;
        private bool _shouldApplyJumpThrustToVelocity;


        public Jumping(MovementStateMachine stateMachine, Rigidbody rigidbody) : base(stateMachine, rigidbody)
        {
        }

        public override void OnEnter()
        {
            if(_stateMachine.GetJumpsToUse() > 0)
            {
                _stateMachine.DecrementJumpsToUse();
                _canSwitchState = false;
                _shouldApplyJumpThrustToVelocity = true;
            }
            else
            {
                SwtichToRunningStateIfItsRunning();
            }
        }

        public override void OnFixedUpdate()
        {
            if(_shouldApplyJumpThrustToVelocity)
            {
                _shouldApplyJumpThrustToVelocity = false;
                float xVelocity = _rigidbody.velocity.x;
                float yVelocity = _rigidbody.velocity.y + _stateMachine.GetJumpThurst() * Time.fixedDeltaTime;
                float zVelocity = _rigidbody.velocity.z;
                Vector3 force = new Vector3(xVelocity, yVelocity, zVelocity);
                _rigidbody.AddForce(force, ForceMode.Impulse); 
                _canSwitchState = true;
            }
        }

        public override void OnUpdate()
        {
            if(_canSwitchState)
            {
                SwtichToRunningStateIfItsRunning();
            }
        }

        private void SwtichToRunningStateIfItsRunning()
        {
            if (_stateMachine.IsRunning())
            {
                _stateMachine.SwitchState(_stateMachine.RunningState);
            }
            else
            {
                _stateMachine.SwitchState(_stateMachine.StandbyState);
            }
        }
    }
}