namespace Assets.Scripts.Player.State_Machine.Movement
{
    using Assets.Scripts.Core;
    using UnityEngine;
    
    public class MovementStateMachine : MonoBehaviour
    {

        public Standby StandbyState;
        public Running RunningState;
        public Jumping JumpingState;

        [SerializeField] private MovementActionsParser _actions;
        [SerializeField] private Rigidbody _rigdbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpThrust;
        [SerializeField] private int _jumpLimit = 1;
        private int _currentJumpsToUse;

        private MoveStateBase _currentState;


        public void DecrementJumpsToUse()
        {
            if(_currentJumpsToUse > 0)
                _currentJumpsToUse--;
        }

        public void ResetJumpsToUse()
        {
            _currentJumpsToUse = _jumpLimit;
        }

        public int GetJumpsToUse()
        {
            return _currentJumpsToUse;
        }

        public float GetJumpThurst()
        {
            return _jumpThrust;
        }

        public float GetMoveSpeed()
        {
            return _moveSpeed;
        }

        public bool HasJumpActionMade()
        {
            return _actions.HasJumpActionMade();
        }

        public bool IsRunning()
        {
            return (GetVelocity().x != 0 || GetVelocity().z != 0);
        }

        public Vector3 GetVelocity()
        {
            return _actions.PlayerVelocity;
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
            StandbyState = new Standby(this, _rigdbody);
            RunningState = new Running(this, _rigdbody);
            JumpingState = new Jumping(this, _rigdbody);
        }

        void Start()
        {
            SetupInitialState();
            GeneralVariablesInit();
        }

        private void SetupInitialState()
        {
            _currentState = StandbyState;
            _currentState.OnEnter();
        }

        private void GeneralVariablesInit()
        {
            _currentJumpsToUse = _jumpLimit;
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