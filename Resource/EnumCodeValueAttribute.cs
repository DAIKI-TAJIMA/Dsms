using System;
using System.Collections.Generic;
using System.Text;

namespace Dsms.Resource
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EnumCodeValueAttribute : Attribute
    {
        private string codeValue;
        public EnumCodeValueAttribute(string CodeValue)
        {
            this.codeValue = CodeValue;
        }

        public static string GetCodeValue(object value)
        {

            //列挙型の種別を取得
            Type enumType = value.GetType();
            //メンバ名を取得
            string enumName = Enum.GetName(enumType, value);
            //フィールド情報を取得
            System.Reflection.FieldInfo field = enumType.GetField(enumName);
            //属性の設定を取得
            EnumCodeValueAttribute[] attrs = (EnumCodeValueAttribute[])field.GetCustomAttributes(typeof(EnumCodeValueAttribute), false);
            //属性に設定されているコード値を返却
            return attrs[0].codeValue;

        }
    }
}
