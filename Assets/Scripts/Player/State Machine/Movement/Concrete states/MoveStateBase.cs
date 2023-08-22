namespace Assets.Scripts.Player.State_Machine.Movement
{
    using UnityEngine;
    
    public abstract class MoveStateBase
    {
        protected MovementStateMachine _stateMachine;
        protected Rigidbody _rigidbody;

        public MoveStateBase(MovementStateMachine stateMachine, Rigidbody rigidbody) 
        {
            _stateMachine = stateMachine;
            _rigidbody = rigidbody;
        }

        public abstract void OnEnter();
        
        public abstract void OnUpdate();

        public abstract void OnFixedUpdate();
    }
}