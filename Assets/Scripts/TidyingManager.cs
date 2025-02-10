using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectObjectivePairing
{
    public ObjectInteractable MovableObject;
    public ObjectObjectiveInteractable Objective;
}

public class TidyingManager : MonoBehaviour
{
    Dictionary<string,ObjectObjectivePairing> _pairingObjectObjective;

    private void Awake()
    {
        Managers.TidyingObjectsManager = this;
    }

    private void Start()
    {
        InitializeObjectMap();
    }

    void InitializeObjectMap()
    {
        _pairingObjectObjective = new Dictionary<string, ObjectObjectivePairing>();
        ObjectInteractable[] objectsInteractable = FindObjectsOfType<ObjectInteractable>();
        foreach (ObjectInteractable interactable in objectsInteractable)
        {
            if (!_pairingObjectObjective.ContainsKey(interactable.IDName))
            {
                ObjectObjectivePairing pairing = new ObjectObjectivePairing();
                _pairingObjectObjective[interactable.IDName] = pairing;
            }
            _pairingObjectObjective[interactable.IDName].MovableObject = interactable;
        }

        ObjectObjectiveInteractable[] objectivesInteractable = FindObjectsOfType<ObjectObjectiveInteractable>();
        foreach (ObjectObjectiveInteractable objective in objectivesInteractable)
        {
            if (!_pairingObjectObjective.ContainsKey(objective.IDName))
            {
                ObjectObjectivePairing pairing = new ObjectObjectivePairing();
                _pairingObjectObjective[objective.IDName] = pairing;
                Debug.LogWarning($"No object set for {objective.IDName}");
            }
            _pairingObjectObjective[objective.IDName].Objective = objective;
            //objective.gameObject.SetActive(false);
        }
    }

    public void ActivateObjective(string idName)
    {
        if (_pairingObjectObjective.TryGetValue(idName,out var pairing))
        {
            Debug.Log($"Acitvate ovjective {pairing} {pairing.Objective == null}");
            pairing.Objective.gameObject.SetActive(true);
        } else
        {
            Debug.LogWarning($"No object/objective pairing found with id {idName}");
        }
    }

    public void PlaceObjectOnObjective(string idName)
    {
        if (_pairingObjectObjective.TryGetValue(idName, out var pairing))
        {
            if (pairing.Objective != null && pairing.MovableObject != null)
            {
                Vector3 objectivePosition = pairing.Objective.transform.position;
                Quaternion objectiveRotation = pairing.Objective.transform.rotation;

                pairing.MovableObject.transform.SetParent(null);
                pairing.MovableObject.transform.position = objectivePosition;
                pairing.MovableObject.transform.rotation = objectiveRotation;
                pairing.Objective.gameObject.SetActive(false);
                pairing.MovableObject.IsCurrentlyInteractable = false;
            }
        }
        else
        {
            Debug.LogWarning($"No object/objective pairing found with id {idName}");
        }
    }
}
