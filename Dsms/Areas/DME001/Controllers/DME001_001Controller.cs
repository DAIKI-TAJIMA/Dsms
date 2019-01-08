using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
// SetStringとGetStringの拡張メソッドを使うのに必要
using Microsoft.AspNetCore.Http;

using Dsms.ViewModels;
using Dsms.Business;
using Dsms.Model;
//using Dsms.Filter;
using Dsms.Controller;
using Dsms.Resource;

namespace Dsms.Controllers
{
    public class DME001_001Controller : ProjecControllerBase
    {
        public DME001_001Controller(IOptions<Frap3Core.BCore.ConnectionInfo> connectioninfo) : base(connectioninfo)
        {
            // ページの情報を設定
            this.SetPageInfo("DME001", "DME001_001", null);
        }

        public IActionResult Init()
        {
            // ビューモデルを生成する。
            DME001_001ViewModel viewModel = new DME001_001ViewModel();

            // システム設定を取得する。
            
            // アプリケーション設定値．メンテナンスモードをログインビューモデル．メンテナンスモードに設定する。																																										

            // ログインビューモデル．メンテナンスモードがTrueの場合、																																										
            // ViewBag.OperationMessageに取得したシステム設定．メンテナンス中メッセージを設定する。																																										

            // ログインビューモデル．メンテナンスモードがFalseの場合、																																										
            // 取得したシステム設定．メンテナンス予告メッセージがNULLでない場合、																																										
            // ViewBag.OperationMessageに取得したシステム設定．メンテナンス予告メッセージを設定する。																																										

            // ビューを表示する。
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(DME001_001ViewModel viewModel)
        {
            // ログイン前チェック
            if (this.InputCheck())
            {
                // ビジネスの生成
                DME001Business bs = new DME001Business(this.ConnectionInfo, this.BCP);
                // ユーザマスタを取得する。[ユーザコード、パスワード]
                M_USERModel model = bs.GetMUser(viewModel.UserCd, viewModel.Password);
                // ユーザマスタが取得できなかった場合、
                if (model == null)
                {
                    // エラーコレクションにモデルエラーを追加する。
                    ModelState.AddModelError("", Dsms.Resource.MessageManager.GetMessage("DME001_0001_E"));
                    // ビューを表示する。
                    return View(viewModel);
                }

                // 取得できたユーザマスタの情報をセッション情報に設定する。
                this.SessionMan.SetSession((Enums.Code_ユーザ権限)model.AN_KENGEN, model.CD_USER, model.NM_USER, model.CD_JICHITAI, model.NM_JICHITAI);

                // メイン画面へリダイレクトする。
                return RedirectToAction(nameof(DMT015_001Controller.Init), "DMT015_001", new { area = "DMT015" });
            }
            else
            {
                // ビューを表示する。
                return View(viewModel);
            }
        }
    }
}