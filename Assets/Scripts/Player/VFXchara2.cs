using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXchara2 : MonoBehaviour
{
    public GameObject fxbomb;

    public void ONfxbomb()
    {
        fxbomb.GetComponent<ParticleSystem>().Play();
        fxbomb.GetComponent<Collider>().enabled = true;
    }

    public void oFFfxbomb()
    {
        fxbomb.GetComponent <ParticleSystem>().Stop();
        fxbomb.GetComponent<Collider>().enabled = false;
    }
}
