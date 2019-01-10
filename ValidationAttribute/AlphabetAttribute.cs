using System.ComponentModel.DataAnnotations;
using Dsms.Resource;
using Futureinn.Utility.Variable;

namespace Dsms.ValidationAttribute
{
    public class AlphabetAttribute : ProjectValidationAttributeBase
    {
        ///	<summary>
        /// コンストラクタ
        ///	</summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/05/09</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public AlphabetAttribute()
        {
        }

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!StringUtility.IsHankakuEiji(value.ToString()))
            {
                return new ValidationResult(MessageManager.GetMessage("DME000_0031_E", new string[] { validationContext.DisplayName }));
            }

            return ValidationResult.Success;
        }
    }
}
