using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] private ParticleSystem leaves;

    [SerializeField] private Animation treeAnimation;

    void Start()
    {
        treeAnimation.Play("TreeIdle");
    }

    private void OnMouseEnter()
    {
        ShakeTree();
    }

    private void OnMouseExit()
    {
        ShakeTree();
    }

    private void ShakeTree()
    {
        if (!treeAnimation.IsPlaying("TreeShake"))
        {
            leaves.Emit(Random.Range(2, 4));
        }

        treeAnimation.Play("TreeShake");
        treeAnimation.PlayQueued("TreeIdle");
    }
}