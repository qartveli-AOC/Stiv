using UnityEditor;
[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor 
{
    public override void OnInspectorGUI()
    {

        Interactable interactable = (Interactable)target;

        if(target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.Messege = EditorGUILayout.TextArea("messsse", interactable.Messege);
            EditorGUILayout.HelpBox("event",MessageType.Info);
            if(interactable.GetComponent<Interactable>() != null ) 
            {
                interactable.UseEvents_B = true;
                interactable.gameObject.AddComponent<InteractionEvents>();
            }
        }
        else 
        {
            base.OnInspectorGUI();
            if (interactable.UseEvents_B)
            {
                if (interactable.GetComponent<InteractionEvents>() == null)
                    interactable.gameObject.AddComponent<InteractionEvents>();


            }
            else
            {
                if (interactable.GetComponent<InteractionEvents>() != null)
                    DestroyImmediate(interactable.GetComponent<InteractionEvents>());

            }
        }
       
    }
}
