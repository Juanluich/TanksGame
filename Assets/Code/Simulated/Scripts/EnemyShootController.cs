using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    [SerializeField] GameObject _player1;
    [SerializeField] GameObject _projectile;

    [SerializeField] LineRenderer _line;
    [SerializeField] float _step;
    [SerializeField] Transform _firePoint;

    [SerializeField] Transform _targetCircle;
    public float height = 2;

    [SerializeField] Transform _TopPart;

    [HideInInspector] public bool shooted;
    public bool attack;

    private EnemyAimingController _aimingController;

    private void Awake()
    {
        _aimingController = GetComponent<EnemyAimingController>();
        
    }
    private void OnEnable() { _line.enabled = true; _targetCircle.gameObject.SetActive(true);}
    private void OnDisable() { _line.enabled = false; }
    private void Update()
    {
        if(!shooted)
        {
            StartShooting();
        }
    }
    public void StartShooting()
    {
        Vector3 direction = _targetCircle.position - _firePoint.position;
        Vector3 groundDirection = new Vector3(direction.x, 0, direction.z);
        Vector3 targetPos = new Vector3(groundDirection.magnitude, direction.y, 0);

        LookAtTarget(direction);

        height = Mathf.Clamp(height, 0.01f, 5);
        float angle;
        float v0;
        float time;
        CalculatePathWithHeight(targetPos, height, out v0, out angle, out time);

        DrawPath(groundDirection.normalized, v0, angle, time, _step);

        //PrepareShooting(groundDirection, angle, v0, time);
        StartCoroutine(PrepareShooting(groundDirection, angle, v0, time));
    }
    private void LookAtTarget(Vector3 direction)
    {
        // Avoid flicker rotating when mouse is too close
        if (Vector3.Distance(_targetCircle.position, transform.position) > 2)
        {
            direction.y = 0;
            _TopPart.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }

    IEnumerator PrepareShooting(Vector3 groundDirection, float angle, float v0, float time)
    {
        _aimingController.CalcDirection(_targetCircle, _player1.transform);
        yield return new WaitForSeconds(3);
        if (attack)
        {
            _projectile.SetActive(true);
            attack = false;
            shooted = true;
            //StopAllCoroutines();
            StartCoroutine(Movement(groundDirection.normalized, v0, angle, time));
        }
    }
    public void Shooted()
    {
        shooted = false;
    }

    private void DrawPath(Vector3 direction, float v0, float angle, float time, float step)
    {
        step = Mathf.Max(0.01f, step);
        _line.positionCount = (int)(time / step) + 2;
        int count = 0;
        for (float i = 0; i < time; i += step)
        {
            float x = v0 * i * Mathf.Cos(angle);
            float y = v0 * i * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(i, 2);
            _line.SetPosition(count, _firePoint.position + direction * x + Vector3.up * y);
            count++;
        }
        float xFinal = v0 * time * Mathf.Cos(angle);
        float yFinal = v0 * time * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(time, 2);
        _line.SetPosition(count, _firePoint.position + direction * xFinal + Vector3.up * yFinal);
    }
    private float QuadraticEquation(float a, float b, float c, float sign)
    {
        return (-b + sign * Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
    }
    private void CalculatePathWithHeight(Vector3 targetPos, float h, out float v0, out float angle, out float time)
    {
        float xt = targetPos.x;
        float yt = targetPos.y;
        float g = -Physics.gravity.y;

        float b = Mathf.Sqrt(2 * g * h);
        float a = (-0.5f * g);
        float c = -yt;

        float tplus = QuadraticEquation(a, b, c, 1);
        float tmin = QuadraticEquation(a, b, c, -1);
        time = tplus > tmin ? tplus : tmin;

        angle = Mathf.Atan(b * time / xt);

        v0 = b / Mathf.Sin(angle);

    }

    IEnumerator Movement(Vector3 direction, float v0, float angle, float time)
    {
        float t = 0;
        while (t < time)
        {
            float x = v0 * t * Mathf.Cos(angle);
            float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(t, 2);
            _projectile.transform.position = _firePoint.position + direction * x + Vector3.up * y;
            t += Time.deltaTime;
            yield return null;
        }
    }
}
