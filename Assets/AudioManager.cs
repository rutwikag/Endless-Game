using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    void Start()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop=s.loop;
        }
        PlaySound("Main Theme");
    }

    public void PlaySound(string name)
    {
        foreach (Sounds s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }

    }
}
