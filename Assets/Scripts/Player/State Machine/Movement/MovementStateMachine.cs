namespace Assets.Scripts.Player.State_Machine.Movement
{
    using UnityEngine;
    
    public class MovementStateMachine : MonoBehaviour
    {

        public Idle IdleState;
        public Running RunningState;

        private MoveStateBase _currentState;


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
            IdleState = new Idle(this);
            RunningState = new Running(this);
        }

        void Start()
        {
            SetupInitialState();
        }

        private void SetupInitialState()
        {
            _currentState = IdleState;
            _currentState.OnEnter();
        }

        void Update()
        {
            _currentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            _currentState.OnFixedUpdate();
        }
    }
}