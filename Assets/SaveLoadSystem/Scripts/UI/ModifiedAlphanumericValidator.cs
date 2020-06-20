using System;
using TMPro;
using UnityEngine;

namespace TMPro
{
    [Serializable]
    // [CreateAssetMenu(fileName = "Modified Alphanumeric", menuName = "Input Validators/Modified Alphanumeric")]
    public class ModifiedAlphanumericValidator : TMP_InputValidator
    {
        public override char Validate(ref string text, ref int pos, char ch)
        {
            if (isValid(ch, pos) && text.Length < 32)
            {
                text = text.Insert(pos, ch.ToString());
                pos++;
                return ch;
            }
            
            return '\0';
        }

        // Returns whether character and position meet specifications
        private bool isValid(char ch, int pos)
        {
            if (ch >= 'A' && ch <= 'Z') return true;
            if (ch >= 'a' && ch <= 'z') return true;
            if (ch >= '0' && ch <= '9') return true;
            if (ch == '_') return true;
            if (ch == ' ' && pos != 0) return true;
            return false;
        }
    }
}
