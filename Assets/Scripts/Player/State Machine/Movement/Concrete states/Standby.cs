namespace Assets.Scripts.Player.State_Machine.Movement
{
    using UnityEngine;

    public class Standby : MoveStateBase
    {
        public Standby(MovementStateMachine stateMachine, Rigidbody rigidbody) : base(stateMachine, rigidbody)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnUpdate()
        {
            SwitchToJumpState();
            SwtichToRunningStateIfItsRunning();
        }

        private void SwitchToJumpState()
        {
            if (_stateMachine.HasJumpActionMade())
                _stateMachine.SwitchState(_stateMachine.JumpingState);
        }

        private void SwtichToRunningStateIfItsRunning()
        {
            if (_stateMachine.IsRunning())
                _stateMachine.SwitchState(_stateMachine.RunningState);
        }
    }
}