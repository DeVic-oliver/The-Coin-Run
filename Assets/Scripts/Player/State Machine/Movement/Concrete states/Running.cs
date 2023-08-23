namespace Assets.Scripts.Player.State_Machine.Movement
{
    using UnityEngine;

    public class Running : MoveStateBase
    {
        private Transform _playerTransform;
        private Rigidbody _rigidbody;
        private Vector3 _movePosition;
        private Vector3 _moveRotation;
        private float _maxMoveSpeed = 20f;


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
            Quaternion rotation = _rigidbody.rotation * Quaternion.Euler(_moveRotation * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(rotation);
            
            Vector3 smoothedPosition = _playerTransform.TransformDirection(_movePosition) * Time.fixedDeltaTime;
            if( _rigidbody.velocity.magnitude < _maxMoveSpeed) 
                _rigidbody.AddForce(smoothedPosition);
        }

        public override void OnUpdate()
        {
            _movePosition =  _stateMachine.GetDirectionInputValue() * Vector3.forward * _stateMachine.GetMoveSpeed();
            _moveRotation = _stateMachine.GetRotationInputValue() * Vector3.up * _stateMachine.GetRotationSpeed();

            if (!_stateMachine.IsRunning())
            {
                _rigidbody.velocity = Vector3.zero;
                _stateMachine.SwitchState(_stateMachine.StandbyState);
            }
        }
    }
}