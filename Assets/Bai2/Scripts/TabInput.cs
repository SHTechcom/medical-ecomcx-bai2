using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabInput : MonoBehaviour
{
    public List<TMP_InputField> inputs = new List<TMP_InputField>();
    private int current = 0;

    private void Awake()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            int index = i;
            inputs[i].onSelect.AddListener((text) =>
            {
                current = index;
            });
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool reverse = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            inputs[current].DeactivateInputField();

            if (reverse)
                current--;
            else
                current++;

            if (current >= inputs.Count) current = 0;
            if (current < 0) current = inputs.Count - 1;

            inputs[current].Select();
            inputs[current].ActivateInputField();
        }
    }
}
