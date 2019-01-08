using System;
using System.Collections.Generic;
using System.Text;
// SetStringとGetStringの拡張メソッドを使うのに必要
using Microsoft.AspNetCore.Http;

using Futureinn.Utility.Variable;

using Dsms.Resource;
using Dsms.Common;

namespace Dsms.Controller
{
    public class SessionManager
    {
        #region メンバ変数

        /// <summary>
        /// セッション情報
        /// </summary>
        private readonly ISession _sessionInfo;

        #endregion

        #region プロパティ

        /// <summary>
        /// セッション情報の値
        /// </summary>
        ///	<remarks>
        /// セッション情報の値を取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="info">セッション情報の項目識別</param>
        ///	<value>セッション情報の値</value>
        public string this[Enums.SessionInfo info]
        {
            get
            {
                return this._sessionInfo.GetString(info.ToString());
            }
            set
            {
                this._sessionInfo.SetString(info.ToString(), CommonMethod.ToString(value));
            }
        }

        /// <summary>
        /// ロールCD
        /// </summary>
        ///	<remarks>
        /// ロールCDを取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ロールCD</value>
        public Enums.Code_ユーザ権限 Kengen
        {
            get
            {
                int roleCd = int.Parse(StringUtility.BlankToZero(this[Enums.SessionInfo.AN_KENGEN]));
                if (Enum.IsDefined(typeof(Enums.Code_ユーザ権限), roleCd))
                {
                    return (Enums.Code_ユーザ権限)roleCd;
                }
                else
                {
                    return Enums.Code_ユーザ権限.NONE;
                }
            }
            set
            {
                this[Enums.SessionInfo.AN_KENGEN] = Convert.ToString((int)value);
            }
        }

        /// <summary>
        /// ユーザCD
        /// </summary>
        ///	<remarks>
        /// ユーザCDを取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ロールCD</value>
        public string UserCd
        {
            get
            {
                return StringUtility.IsBrank(this[Enums.SessionInfo.CD_USER]) ? Constants.STRANGER_USERCD : this[Enums.SessionInfo.CD_USER];
            }
            set
            {
                this[Enums.SessionInfo.CD_USER] = value;
            }
        }

        /// <summary>
        /// ユーザ名
        /// </summary>
        ///	<remarks>
        /// ユーザ名を取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>姓</value>
        public string UserNm
        {
            get
            {
                return this[Enums.SessionInfo.NM_USER];
            }
            set
            {
                this[Enums.SessionInfo.NM_USER] = value;
            }
        }

        /// <summary>
        /// 自治体コード
        /// </summary>
        ///	<remarks>
        /// 自治体コードを取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>学校CD</value>
        public string JichitaiCd
        {
            get
            {
                return this[Enums.SessionInfo.CD_JICHITAI];
            }
            set
            {
                this[Enums.SessionInfo.CD_JICHITAI] = value;
            }
        }

        /// <summary>
        /// 自治体名
        /// </summary>
        ///	<remarks>
        /// 自治体名を取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>学校名</value>
        public string JichitaiNm
        {
            get
            {
                return this[Enums.SessionInfo.NM_JICHITAI];
            }
            set
            {
                this[Enums.SessionInfo.NM_JICHITAI] = value;
            }
        }

        /// <summary>
        /// セッションID
        /// </summary>
        ///	<remarks>
        /// セッションIDを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>セッションID</value>
        public string SessionId
        {
            get
            {
                return this._sessionInfo.Id;
            }
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="session">セッション情報</param>
        public SessionManager(ISession session)
        {
            // メンバ変数にセット
            this._sessionInfo = session;
        }

        #endregion

        #region パブリックメソッド

        /// <summary>
        /// セッション情報を設定
        /// </summary>
        ///	<remarks>
        /// セッション情報を設定する。
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="kengen">ロールCD</param>
        ///	<param name="userCd">ユーザーCD</param>
        ///	<param name="userNm">姓</param>
        ///	<param name="jichitaiCd">学校CD</param>
        ///	<param name="jichitaiNm">学校名</param>
        public void SetSession(Enums.Code_ユーザ権限 kengen, string userCd, string userNm, string jichitaiCd, string jichitaiNm)
        {
            this.Kengen = kengen;
            this.UserCd = userCd;
            this.UserNm = userNm;
            this.JichitaiCd = jichitaiCd;
            this.JichitaiNm = jichitaiNm;
        }

        /// <summary>
        /// セッション情報をクリア
        /// </summary>
        ///	<remarks>
        /// セッション情報をクリアする。
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public void ClearSession()
        {
            this._sessionInfo.Clear();
        }

        /// <summary>
        /// セッションから値を取得(SessionInfoにないキーを使用して取り出す場合に使用する)
        /// 基本的に使用しないこと
        /// GetValueメソッドで取得後、RemoveValueメソッドで破棄すること
        /// </summary>
        ///	<remarks>
        /// セッションから値を取得(SessionInfoにないキーを使用して取り出す場合に使用する)
        /// 
        ///	<para>作成年月日 2014/12/18</para>
        ///	<para>作成者 (株)フューチャーイン 村上 正和</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="infoName">セッションの項目名</param>
        ///	<returns>セッションの値</returns>
        public string GetValue(string infoName)
        {
            return this._sessionInfo.GetString(infoName);
        }

        /// <summary>
        /// セッションに値をセット(SessionInfoにないキーを使用して設定する場合に使用する)
        /// 基本的に使用しないこと
        /// </summary>
        ///	<remarks>
        /// セッションに値をセット(SessionInfoにないキーを使用して設定する場合に使用する)
        ///	<para>作成年月日 2014/12/18</para>
        ///	<para>作成者 (株)フューチャーイン 村上 正和</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="infoName">セッションの項目名</param>
        ///	<param name="value">セットする値</param>
        public void SetValue(string infoName, string value)
        {
            this._sessionInfo.SetString(infoName, value);
        }

        /// <summary>
        /// セッションの値を破棄する(SessionInfoにないキーを使用して設定する場合に使用する)
        /// 基本的に使用しないこと
        /// </summary>
        ///	<remarks>
        /// セッションの値を破棄する(SessionInfoにないキーを使用して設定する場合に使用する)
        ///	<para>作成年月日 2014/12/18</para>
        ///	<para>作成者 (株)フューチャーイン 村上 正和</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="infoName">セッションの項目名</param>
        public void RemoveValue(string infoName)
        {
            this._sessionInfo.Remove(infoName);
        }

        #endregion
    }
}
