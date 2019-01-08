using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dsms.ViewModels;
using Dsms.Business;
using Dsms.Model;
using Dsms.Filter;
using Dsms.Controller;

namespace Dsms.Controllers
{
    [Session]
    public class DMT015_001Controller : ProjecControllerBase
    {
        public DMT015_001Controller(IOptions<Frap3Core.BCore.ConnectionInfo> connectioninfo) : base(connectioninfo)
        {
            // ページの情報を設定
            this.SetPageInfo("DMT015", "DMT015_001", new Resource.Enums.Code_ユーザ権限[] { Resource.Enums.Code_ユーザ権限.一般, Resource.Enums.Code_ユーザ権限.管理者 });
            // 複合チェックメドッドの追加
            this.AddInputCheckMethod(this.CheckFukugo);
        }

        public IActionResult Init()
        {
            // ビューモデルを生成する。
            DMT015_001ViewModel viewModel = new DMT015_001ViewModel();

            // ビューを表示する。
            return View(viewModel);
        }

        /// <summary>
        /// 複合チェック
        /// </summary>
        ///	<remarks>
        /// 複合チェック
        ///	<para>作成年月日 2012/12/16</para>
        ///	<para>作成者 (株)フューチャーイン 三井 久永</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<returns>True：チェックOK / False：チェックNG</returns>
        private bool CheckFukugo()
        {
            bool result = true;

            //ModelState.AddModelError("", "複合エラーメッセージ");

            return result;
        }
    }
}