using Frap3Core.BCore;

using Dsms.Resource;

namespace Dsms.Business
{
    public class ProjectBusinessBase : BusinessBase
    {
        #region private変数

        /// <summary>
        /// ConnectionInfo
        /// </summary>
        protected ConnectionInfo _connectionInfo { get; set; }
        /// <summary>
        /// ページから受けとった共通パラメータ
        /// </summary>
        private BusinessCommonParams _bcp;

        #endregion

        #region プロパティ

        /// <summary>
        /// ページから受けとった共通パラメータ
        /// </summary>
        ///	<remarks>
        ///	ページから受けとった共通パラメータを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ページから受けとった共通パラメータ</value>
        protected BusinessCommonParams BCP
        {
            get
            {
                return this._bcp;
            }
        }

        #endregion

        #region コンストラクタ

        ///	<summary>
        /// コンストラクタ
        ///	</summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/03/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public ProjectBusinessBase(Frap3Core.BCore.ConnectionInfo connectionInfo, BusinessCommonParams bcp)
        {
            this._connectionInfo = connectionInfo;
            this._bcp = bcp;
        }

        #endregion

        #region メソッド

        #region DB接続チェック

        ///	<summary>
        /// DB接続チェック
        ///	</summary>
        ///	<remarks>
        /// DB接続チェック
        ///	<para>作成年月日 2018/03/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public override bool CheckConnection()
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance(this._connectionInfo);
            return base.CheckConnection(helper);
        }

        /// <summary>
        /// GetConnectErrMessage
        /// </summary>
        /// <returns>string</returns>
        public override string GetConnectErrMessage()
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance(this._connectionInfo);
            return base.GetConnectErrMessage(helper);
        }

        #endregion

        #endregion
    }
}
