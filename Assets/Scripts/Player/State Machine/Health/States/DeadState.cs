namespace Assets.Scripts.Player.State_Machine.Health.States
{
    public class DeadState : HealthStateBase
    {
        public DeadState(HealthStateMachine stateMachine, PlayerHealthAnimator healthAnimator) : base(stateMachine, healthAnimator)
        {
        }

        public override void OnEnter()
        {
            _healthAnimator.SetIsAliveParamToFalse();
            _stateMachine.InvokeDeathEvents();
        }

        public override void OnUpdate()
        {
        }
    }
}