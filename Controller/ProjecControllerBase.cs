using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Dsms.Resource;

namespace Dsms.Controller
{
    public class ProjecControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        #region デリゲート

        /// <summary>
        /// 入力チェック用デリゲート
        /// </summary>
        ///	<remarks>
        ///	入力チェック用デリゲート
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="errList">エラー情報のリスト</param>
        ///	<returns>True：チェックOK / False：チェックNG</returns>
        public delegate bool InputCheckDelegate();

        #endregion

        #region Private変数

        /// <summary>
        /// 入力チェックメソッドリスト
        /// </summary>
        private readonly List<InputCheckDelegate> _checkMethods = new List<InputCheckDelegate>();
        /// <summary>
        /// ページを使用可能なロールの種類
        /// </summary>
        private Enums.Code_ユーザ権限[] _usableRoles = null;
        /// <summary>
        /// 接続情報を保持
        /// </summary>
        private readonly Frap3Core.BCore.ConnectionInfo _connectioninfo = null;
        /// <summary>
        /// セッションマネージャ
        /// </summary>
        private SessionManager _sessionMan;
        /// <summary>
        /// 画面ID
        /// </summary>
        private string _gamenId;
        /// <summary>
        /// プログラムID
        /// </summary>
        private string _programId;

        #endregion

        public ProjecControllerBase(IOptions<Frap3Core.BCore.ConnectionInfo> connectioninfo)
        {
            this._connectioninfo = connectioninfo.Value;
        }

        #region パブリックプロパティ

        #region 画面のモード

        /// <summary>
        /// 画面のモード
        /// </summary>
        ///	<remarks>
        ///	画面のモードを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>画面のモード</value>
        public Enums.Code_ユーザ権限[] UsableRoles
        {
            get
            {
                return this._usableRoles;
            }
        }

        #endregion

        #region 画面のモード

        /// <summary>
        /// 画面のモード
        /// </summary>
        ///	<remarks>
        ///	画面のモードを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>画面のモード</value>
        public Frap3Core.BCore.ConnectionInfo ConnectionInfo
        {
            get
            {
                return this._connectioninfo;
            }
        }

        #endregion

        #region セッションマネージャ

        /// <summary>
        /// セッションマネージャ
        /// </summary>
        ///	<remarks>
        ///	セッションマネージャを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>セッションマネージャ</value>
        public SessionManager SessionMan
        {
            get
            {
                if (this._sessionMan == null)
                {
                    this._sessionMan = new SessionManager(HttpContext.Session);
                }
                return this._sessionMan;
            }
        }

        #endregion

        #region ページからビジネスへ受け渡す共通パラメータ

        ///	<summary>
        ///	ページからビジネスへ受け渡す共通パラメータ
        ///	</summary>
        ///	<remarks>
        ///	ページからビジネスへ受け渡す共通パラメータを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ページからビジネスへ受け渡す共通パラメータを生成</value>
        public BusinessCommonParams BCP
        {
            get
            {
                // ページからビジネスへ受け渡す共通パラメータを生成
                BusinessCommonParams bcp = new BusinessCommonParams
                {
                    SessionId = this.SessionMan.SessionId,      // セッションID
                    UserCd = this.SessionMan.UserCd,            // ユーザコード
                    JichitaiCd = this.SessionMan.JichitaiCd,    // 自治体コード
                    Kengen = this.SessionMan.Kengen             // 権限
                };

                return bcp;
            }
        }

        #endregion

        #region 画面ID

        /// <summary>
        /// 画面ID
        /// </summary>
        ///	<remarks>
        ///	画面IDを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>画面ID</value>
        public string GamenId
        {
            get
            {
                return this._gamenId;
            }
        }

        #endregion

        #region プログラムID

        /// <summary>
        /// プログラムID
        /// </summary>
        ///	<remarks>
        ///	プログラムIDを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>プログラムID</value>
        public string ProgramId
        {
            get
            {
                return this._programId;
            }
        }

        #endregion

        #endregion

        #region プロテクテッドメソッド

        #region ページの情報を設定

        ///	<summary>
        ///	ページの情報を設定
        ///	</summary>
        ///	<remarks>
        ///	ページの情報を設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="programId">プログラムID</param>
        ///	<param name="gamenId">画面ID</param>
        ///	<param name="usableRoles">ページを使用可能な権限の種類</param>
        protected void SetPageInfo(string programId, string gamenId, Enums.Code_ユーザ権限[] usableRoles)
        {
            this._programId = programId;
            this._gamenId = gamenId;
            if (usableRoles == null)
            {
                this._usableRoles = new Enums.Code_ユーザ権限[] { };
            }
            else
            {
                this._usableRoles = usableRoles;
            }
        }

        #endregion

        #endregion

        #region メソッド

        ///	<summary>
        ///	入力チェックメソッドを追加
        ///	</summary>
        ///	<remarks>
        ///	入力チェックメソッドを追加
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="method">入力チェックメソッド</param>
        public void AddInputCheckMethod(InputCheckDelegate method)
        {
            if (method != null)
            {
                this._checkMethods.Add(method);
            }
        }

        ///	<summary>
        ///	入力チェック
        ///	</summary>
        ///	<remarks>
        ///	コントロールの入力値をチェックする。
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="errList">エラー情報のリスト</param>
        ///	<returns>True：チェックOK / False：チェックNG</returns>
        public bool InputCheck()
        {
            // チェック結果格納用
            bool result = true;

            // 基本的なチェックを実行
            if (!ModelState.IsValid)
            {
                result = false;
            }
            // 個別の入力チェックをすべて実行
            for (int i = 0; i <= this._checkMethods.Count - 1; i++)
            {
                if (this._checkMethods[i] != null)
                {
                    if (!this._checkMethods[i].Invoke())
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}