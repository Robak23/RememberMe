using UnityEngine;
using System.Collections.Generic;

public class AIPlayPath : MonoBehaviour
{
    public bool StartPlayingPath;
    public bool TriggerAnimation;
    public float JumpTime;
    public bool FinishedPlayingPath;

    private List<int> _path;
    private int _pathStep;
    private bool _inMovement;

    private float _currentJumpTime;
    private float _transformProgress;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

	// Use this for initialization
	public void Initialize (List<int> pathWay)
	{
	    TriggerAnimation = false;
	    FinishedPlayingPath = false;
	    _path = pathWay;
	    _inMovement = false;
	    _pathStep = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!StartPlayingPath) return;
	    if (!_inMovement)
	    {
	        _startPosition = gameObject.transform.position;
	        _endPosition = GetDirection(_path[_pathStep]);
            _transformProgress = 0f;
            _currentJumpTime = 0f;
            _inMovement = true;
            TriggerAnimation = true;
        }

	    if (_inMovement)
	    {
            _currentJumpTime += Time.deltaTime;
            _transformProgress = _currentJumpTime / JumpTime;
            gameObject.transform.position = Vector3.Lerp(_startPosition, _endPosition, _transformProgress);

            if (_transformProgress > 0.8f)
            {
                TriggerAnimation = false;
            }

            if (gameObject.transform.position == _endPosition)
            {
                _inMovement = false;
                if (_pathStep++ > _path.Count)
                {
                    FinishedPlayingPath = true;
                }
            }
        }
	}

    private Vector3 GetDirection(int direction)
    {
        switch (direction)
        {
            case 1:
                return new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            case 2:
                return new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            case 3:
                return new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            case 4:
                return new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        return new Vector3(0f,0f,0f);
    }
}
