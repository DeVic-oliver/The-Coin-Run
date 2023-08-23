namespace Assets.Scripts.Player.State_Machine.Movement
{

    public class Standby : MoveStateBase
    {
        public Standby(MovementStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            _stateMachine.SetRunningAnimationToFalse();
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnUpdate()
        {
            SwtichToRunningStateIfItsRunning();
        }

        private void SwtichToRunningStateIfItsRunning()
        {
            if (_stateMachine.IsRunning())
                _stateMachine.SwitchState(_stateMachine.RunningState);
        }
    }
}