using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTracksController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _clips;

    private int _currentClipIndex;
    private AudioSource _source;

    AudioClip _currentClip;

    bool _isPlaying = true;
    bool _isMuted = false;
    private float _trackLenth;
    private float _elapsedTrackTime = 0;
    private void OnEnable()
    {

        _source = GetComponent<AudioSource>();
        _currentClip = _clips[0];
        _currentClipIndex = 0;
        _source.clip = _currentClip;
        StartCoroutine(ClipSequencePlaying(0));
        _isPlaying = true;
    }

    public void PlayPause()
    {
        if (_isPlaying)
        {
            PauseClip();
            _isPlaying = false;
        }
        else
        {
            PlayClip();
            _isPlaying = true;
        }
    }

    public void PauseClip()
    {
        _source.Pause();
        StopAllCoroutines();
    }

    public void PlayClip()
    {

        StopAllCoroutines();
        StartCoroutine(ClipSequencePlaying(_currentClipIndex));
    }

    public void MuteVolumeTrigger()
    {
        if (!_isMuted)
        {
            _source.volume = 0;
            _isMuted = true;
        }
        else
        {
            _source.volume = 0.4f;
            _isMuted = false;
        }
    }

    public void SetNextTrack()
    {
        _elapsedTrackTime = 0;
        int index = _currentClipIndex + 1;
        AudioClip nextClip;
        if (index > _clips.Length - 1)
        {
            nextClip = _clips[0];
            index = 0;
        }
        else
        {
            nextClip = _clips[index]; 
            _currentClipIndex = index;
        }
        _currentClipIndex = index;
        _currentClip = nextClip;
        _source.clip = _currentClip;
        StopAllCoroutines();
        StartCoroutine(ClipSequencePlaying(index));
    }

    public void SetPreviousTrack()
    {
        _elapsedTrackTime = 0;
        int index = _currentClipIndex - 1;
        AudioClip nextClip;
        if (index < 0)
        {
            nextClip = _clips[_clips.Length - 1];
            index = _clips.Length - 1;
        }
        else
        {
            nextClip = _clips[index];
            _currentClipIndex = index;
        }
        _currentClipIndex = index;
        _currentClip = nextClip;
        _source.clip = _currentClip;
        StopAllCoroutines();
        StartCoroutine(ClipSequencePlaying(index));
    }




    private IEnumerator ClipSequencePlaying(int index)
    {
        float elapsed = _elapsedTrackTime;
        while (true)
        {
            for (int i = index; i < _clips.Length; i++)
            {
                _source.clip = _clips[i];
                _trackLenth = _source.clip.length;
                _source.Play();
                StartCoroutine(TrackProgress(_trackLenth));
                yield return new WaitForSeconds(_trackLenth - elapsed);
            }
        }
    }

    private IEnumerator TrackProgress(float TrackLength)
    {
        while (_elapsedTrackTime <= TrackLength)
        {
            _elapsedTrackTime++;
            yield return new WaitForSeconds(1f);
        }
    }
}