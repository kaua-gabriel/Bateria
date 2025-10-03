using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
public class BaquetaController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private Renderer rend;

    [Header("Visual")]
    public Material normalMaterial;
    public Material highlightMaterial;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        rend = GetComponent<Renderer>();

        // Eventos XR Grab corretos
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void Start()
    {
        if (rend != null && normalMaterial != null)
            rend.material = normalMaterial;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // XR Grab cuida do movimento, não precisa mexer na posição
        rb.isKinematic = false; // deixa físico habilitado se quiser interações
        if (rend != null && highlightMaterial != null)
            rend.material = highlightMaterial;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        rb.isKinematic = false; // mantém físico ativo
        if (rend != null && normalMaterial != null)
            rend.material = normalMaterial;
    }
}
