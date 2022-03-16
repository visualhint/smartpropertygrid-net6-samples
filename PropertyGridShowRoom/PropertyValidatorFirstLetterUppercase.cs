using System;
using System.Text;
using VisualHint.SmartPropertyGrid;
using System.Windows.Forms;

namespace PropertyGridShowRoom
{
    class PropertyValidatorFirstLetterUppercase : PropertyValidatorBase
    {
        public override bool Check(PropertyEnumerator propEnum, object value, bool modify)
        {
            if (value == null)
                return true;

            bool result = true;

            if (value is string str)
            {
                try
                {
                    result = char.IsUpper(str, 0);

                    if (modify && !result)
                    {
                        str = char.ToUpper(str[0]) + str[1..];
                        propEnum.Property.Value.SetValue(str);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    return true;
                }
            }

            if (result == false)
                Message = "The string must begin by an upper letter.";
            else
                Message = "";

            return result;
        }
    }
}
