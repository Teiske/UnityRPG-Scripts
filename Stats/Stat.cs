using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat  {

    [SerializeField]
    int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue() {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void Addmodifier(int modifier) {
        if(modifier != 0) {
            modifiers.Add(modifier);
        }
    }

    public void Removemodifier(int modifier) {
        if (modifier != 0) {
            modifiers.Remove(modifier);
        }
    }
}
