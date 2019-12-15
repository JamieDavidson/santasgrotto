using UnityEngine;

public class AttachmentData : MonoBehaviour
{
    public AttachmentSlot Slot;
}

public enum AttachmentSlot
{
    Back = 0,
    Top = 1,
    Bottom = 2
}