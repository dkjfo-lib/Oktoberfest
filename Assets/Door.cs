using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 openDelta;
    Vector3 closedPosition;
    [Space]
    [Range(0, 1)] public float speed = .5f;
    [Space]
    public bool shouldBeOpen = false;
    bool isOpen = false;
    [Space]
    public Pipe_SoundsPlay Pipe_SoundsPlay;
    public ClipsCollection OpenCloseSound;

    void Start()
    {
        closedPosition = transform.position;
    }

    public void Open() => shouldBeOpen = true;
    public void Close() => shouldBeOpen = false;

    private void Update()
    {
        if (isOpen != shouldBeOpen)
        {
            isOpen = shouldBeOpen;
            Pipe_SoundsPlay.AddClip(new PlayClipData(OpenCloseSound, transform.position));
        }
        Vector3 targetPos = shouldBeOpen ? closedPosition + openDelta : closedPosition;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed);
    }
}
