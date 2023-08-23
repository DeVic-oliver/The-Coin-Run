namespace Assets.Scripts.Player.State_Machine.Movement
{
    using UnityEngine;

    public class Running : MoveStateBase
    {
        private Transform _playerTransform;
        private Rigidbody _rigidbody;
        private Vector3 _movePosition;
        private float _maxMoveSpeed = 10f;


        public Running(MovementStateMachine stateMachine, Transform playerTransform, Rigidbody rigidbody) : base(stateMachine)
        {
            _playerTransform = playerTransform;
            _rigidbody = rigidbody;
        }

        public override void OnEnter()
        {
            _stateMachine.SetRunningAnimationTrue();
        }

        public override void OnFixedUpdate()
        {   
            Vector3 smoothedPosition = _playerTransform.TransformDirection(_movePosition) * Time.fixedDeltaTime;
            if( _rigidbody.velocity.magnitude < _maxMoveSpeed) 
                _rigidbody.AddForce(smoothedPosition);
        }

        public override void OnUpdate()
        {
            _movePosition =  _stateMachine.GetDirectionInputValue() * Vector3.forward * _stateMachine.GetMoveSpeed();

            if (!_stateMachine.IsRunning())
            {
                _rigidbody.velocity = Vector3.zero;
                _stateMachine.SwitchState(_stateMachine.StandbyState);
            }
        }
    }
}