using UnityEngine;

public class BarbellAnchorController : MonoBehaviour {
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    private void LateUpdate()
    {
        if (leftHand != null && rightHand != null)
        {
            // Calculate midpoint between hands
            Vector3 midpoint = (leftHand.position + rightHand.position) / 2f;
            transform.position = midpoint;

            // Adjust rotation if necessary
            transform.rotation = Quaternion.LookRotation(rightHand.position - leftHand.position);
        }
    }
}
