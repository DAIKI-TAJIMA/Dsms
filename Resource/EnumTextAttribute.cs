using System;
using System.Collections.Generic;
using System.Text;

namespace Dsms.Resource
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EnumTextAttribute : Attribute
    {
        private string text;
        public EnumTextAttribute(string text)
        {
            this.text = text;
        }

        public static string GetText(object value)
        {

            //列挙型の種別を取得
            Type enumType = value.GetType();
            //メンバ名を取得
            string enumName = Enum.GetName(enumType, value);
            //フィールド情報を取得
            System.Reflection.FieldInfo field = enumType.GetField(enumName);
            //属性の設定を取得
            EnumTextAttribute[] attrs = (EnumTextAttribute[])field.GetCustomAttributes(typeof(EnumTextAttribute), false);
            //属性に設定されているコード値を返却
            return attrs[0].text;

        }
    }
}
