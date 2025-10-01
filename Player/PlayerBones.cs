// Change bones on clothes

using UnityEngine;

public class AttachClothToAvatar : MonoBehaviour
{
    SkinnedMeshRenderer targetCloth; // Clothes
    SkinnedMeshRenderer targetBody;  // Body of player

    void Start()
    {
        targetCloth = gameObject.GetComponent<SkinnedMeshRenderer>();
        targetBody = PlayerController.instance.targetBody;
        if (targetCloth == null || targetBody == null) return;

        // Copy bones and root bone
        targetCloth.rootBone = targetBody.rootBone;
        targetCloth.bones = targetBody.bones;
    }
}
