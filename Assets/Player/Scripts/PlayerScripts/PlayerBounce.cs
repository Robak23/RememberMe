using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerBounce : MonoBehaviour
    {
        public bool TriggerAnimation;
        public float JumpTime;

        private bool _inMovement;

        private float _currentJumpTime;
        private float _tranformProgress;

        private Vector3 _startPosition;
        private Vector3 _endPosition;

        void Start()
        {
            _inMovement = false;
            TriggerAnimation = false;
        }

        void Update()
        {
            if (!_inMovement)
            {
                _inMovement = StartMoving();
                _startPosition = gameObject.transform.position;
                _endPosition = GetInputDirection();
            }
            if (_inMovement)
            {
                _currentJumpTime += Time.deltaTime;
                _tranformProgress = _currentJumpTime/JumpTime;
                gameObject.transform.position = Vector3.Lerp(_startPosition, _endPosition, _tranformProgress);

                if (_tranformProgress > 0.8f)
                {
                    TriggerAnimation = false;
                }

                if (gameObject.transform.position == _endPosition)
                {
                    _inMovement = false;
                }
            }
        }

        private bool StartMoving()
        {
            if (Input.GetButtonDown("up") 
                || Input.GetButtonDown("down") 
                || Input.GetButtonDown("left") 
                || Input.GetButtonDown("right"))
            {
                _tranformProgress = 0f;
                _currentJumpTime = 0f;
                _inMovement = true;
                TriggerAnimation = true;
                return true;
            }
            return false;
        }

        private Vector3 GetInputDirection()
        {
            if (Input.GetButtonDown("up"))
            {
                return new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            }
            if (Input.GetButtonDown("down"))
            {
                return new Vector3(transform.position.x, transform.position.y, transform.position.z -1);
            }
            if (Input.GetButtonDown("right"))
            {
                return new Vector3(transform.position.x +1, transform.position.y, transform.position.z);
            }
            if (Input.GetButtonDown("left"))
            {
                return new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
            return new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
