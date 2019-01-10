using Dsms.Resource;

namespace Dsms.ValidationAttribute
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
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
        public RequiredAttribute()
        {
            this.ErrorMessage = MessageManager.GetMessage("DME000_0003_E");
        }
    }
}
