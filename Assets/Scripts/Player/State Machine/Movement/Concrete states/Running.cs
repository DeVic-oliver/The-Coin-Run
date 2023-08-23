namespace Assets.Scripts.Player.State_Machine.Movement
{
    using UnityEngine;

    public class Running : MoveStateBase
    {
        private Transform _playerTransform;


        public Running(MovementStateMachine stateMachine, Transform playerTransform) : base(stateMachine)
        {
            _playerTransform = playerTransform;
        }

        public override void OnEnter()
        {
            _stateMachine.SetRunningAnimationTrue();
        }

        public override void OnUpdate()
        {
            Vector3 translationDirection = GetTranslationDirection();
            _playerTransform.Translate(translationDirection);

            Vector3 eulers = GetRotationEulers();
            _playerTransform.Rotate(eulers);

            if (!_stateMachine.IsRunning())
                _stateMachine.SwitchState(_stateMachine.StandbyState);
        }

        private Vector3 GetTranslationDirection()
        {
            return Vector3.forward * _stateMachine.GetDirectionInputValue() * _stateMachine.GetMoveSpeed() * Time.deltaTime;
        }

        private Vector3 GetRotationEulers()
        {
            return Vector3.up * _stateMachine.GetRotationInputValue() * _stateMachine.GetRotationSpeed() * Time.deltaTime;
        }

    }
}