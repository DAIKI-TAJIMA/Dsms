using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dsms.ViewModels
{
    [Serializable]
    public class DME001_001ViewModel
    {
        /// <summary>
        /// ユーザコード
        /// </summary>
        [Dsms.ValidationAttribute.Required]
        [Display(Name = "ユーザコード")]
        public string UserCd { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        [Dsms.ValidationAttribute.Required]
        [DataType(DataType.Password)]
        [Display(Name = "パスワード")]
        public string Password { get; set; }
    }
}
