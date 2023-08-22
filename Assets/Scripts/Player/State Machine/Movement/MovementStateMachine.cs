namespace Assets.Scripts.Player.State_Machine.Movement
{
    using Assets.Scripts.Core;
    using UnityEngine;
    
    public class MovementStateMachine : MonoBehaviour
    {
        public Standby StandbyState;
        public Running RunningState;

        [SerializeField] private MovementActionsParser _actions;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        
        private MoveStateBase _currentState;


        public float GetMoveSpeed()
        {
            return _moveSpeed;
        }

        public float GetRotationSpeed()
        {
            return _rotationSpeed;
        }

        public bool IsRunning()
        {
            return (GetRotationInputValue() != 0 || GetDirectionInputValue() != 0);
        }

        public float GetRotationInputValue() 
        {
            return _actions.HorizontalActionValue;
        }

        public float GetDirectionInputValue()
        {
            return _actions.VerticalActionValue;
        }

        public void SwitchState(MoveStateBase newState)
        {
            _currentState = newState;
            _currentState.OnEnter();
        }

        private void Awake()
        {
            InitializeStates();
        }

        private void InitializeStates()
        {
            StandbyState = new Standby(this);
            RunningState = new Running(this, _playerTransform);
        }

        void Start()
        {
            SetupInitialState();
        }

        private void SetupInitialState()
        {
            _currentState = StandbyState;
            _currentState.OnEnter();
        }

        void Update()
        {
            _currentState.OnUpdate();
        }
    }
}