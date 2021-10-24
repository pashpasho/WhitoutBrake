using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Smart2DWaypoints.Scripts;


[ExecuteInEditMode]
public class Portal : MonoBehaviour
{
    ParticleSystem ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
    private GameObject[] markCount;
    private GameObject vb;


    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        Component component = ps.trigger.GetCollider(0);
        vb = component.gameObject;
        markCount = GameObject.FindGameObjectsWithTag("Marker");
        if (markCount.Length == 4 && numEnter > 0 )
        {
            StartCoroutine(trans());
        }
    }
    IEnumerator trans()
    {
        vb.GetComponent<WaypointsMover>().teleport();
        yield return null;
        vb.transform.position = markCount[2].transform.position;
        yield return null;
        vb.GetComponent<WaypointsMover>().started();
    }
}
