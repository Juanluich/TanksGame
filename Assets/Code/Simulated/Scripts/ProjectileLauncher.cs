using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchSpeed = 10f;

    [Header("Trajectory Display")]
    public LineRenderer line;
    public int linePoints = 175;
    public float timeIntervalinPoints = 0.01f;

    public float distance = 5;

    private void Update()
    {
        if(line != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //DrawTrajectory();
                line.enabled = true;
            }
        }
        else
        {
            line.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint.up;
        }
    }

    void DrawTrajectory()
    {
        Vector3 origin = launchPoint.position;
        Vector3 startVelocity = launchSpeed * launchPoint.up;
        line.positionCount = linePoints;
        float time = 0;
        for(int i = 0; i < linePoints; i++)
        {
            // s = u*t + 1/2*g*t*t
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.y * time) + (Physics.gravity.y / 2 * time * time);
            Vector3 point = new Vector3(x, y, 0);
            line.SetPosition(i, origin + point);
            time += timeIntervalinPoints;
        }

    }

}
