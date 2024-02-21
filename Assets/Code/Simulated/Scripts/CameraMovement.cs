using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] List<Transform> _cameraPositions;
    private int _index = 0;

    public void RightCameraPosition()
    {
        if (_index == _cameraPositions.Count - 1) { _index = -1; }
        transform.DOMove(_cameraPositions[_index + 1].position, .75f).SetEase(Ease.OutQuad);
        transform.DORotate(_cameraPositions[_index + 1].eulerAngles, .75f).SetEase(Ease.OutQuad);
        _index++;

    }

    public void LeftCameraPosition()
    {
        if (_index == 0) { _index = 4; }
        transform.DOMove(_cameraPositions[_index - 1].position, .75f).SetEase(Ease.OutQuad);
        transform.DORotate(_cameraPositions[_index - 1].eulerAngles, .75f).SetEase(Ease.OutQuad);
        _index--;
    }
}
