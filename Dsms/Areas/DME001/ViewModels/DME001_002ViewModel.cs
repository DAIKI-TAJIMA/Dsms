using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dsms.ViewModels
{
    [Serializable]
    public class DME001_002ViewModel
    {
        /// <summary>
        /// ユーザコード
        /// </summary>
        [Required]
        [Display(Name = "ユーザコード")]
        public string UserCd { get; set; }
    }
}
