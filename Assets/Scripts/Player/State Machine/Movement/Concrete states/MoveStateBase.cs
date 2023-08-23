namespace Assets.Scripts.Player.State_Machine.Movement
{
    public abstract class MoveStateBase
    {
        protected MovementStateMachine _stateMachine;

        public MoveStateBase(MovementStateMachine stateMachine) 
        {
            _stateMachine = stateMachine;
        }

        public abstract void OnEnter();
        
        public abstract void OnUpdate();

        public abstract void OnFixedUpdate();

    }
}