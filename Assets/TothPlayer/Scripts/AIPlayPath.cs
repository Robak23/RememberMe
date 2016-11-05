using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class AIPlayPath : MonoBehaviour
{
    public bool StartPlayingPath;
    public bool TriggerAnimation;
    public float JumpTime;
    public float PauseTime;
    public int PathStep;
    public bool Destroyed;


    private List<int> _path;
    private bool _finishedPlayingPath;
    private bool _inMovement;

    private float _currentJumpTime;
    private float _transformProgress;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private Stopwatch _stopwatch;

	// Use this for initialization
	public void Initialize (List<int> pathWay)
	{
	    TriggerAnimation = false;
	    _finishedPlayingPath = false;
	    _path = pathWay;
	    _inMovement = false;
	    PathStep = 0;
        _stopwatch = Stopwatch.StartNew();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!StartPlayingPath) return;
	    if (!_inMovement && _stopwatch.ElapsedMilliseconds > PauseTime && !_finishedPlayingPath)
	    {
	        _startPosition = gameObject.transform.position;
	        _endPosition = GetDirection(_path[PathStep]);
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
                _stopwatch = Stopwatch.StartNew();
                _inMovement = false;
                if (PathStep++ >= _path.Count-1)
                {
                    _finishedPlayingPath = true;
                    Destroy(gameObject, 1);
                }
            }
        }
	}

    public void OnDestroy()
    {
        Destroyed = true;
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
