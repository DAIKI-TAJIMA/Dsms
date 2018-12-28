using System;
using System.Data.Common;

namespace Frap3Core.BCore
{
    /// <summary>
    /// ビジネスの基本クラス
    /// </summary>
    ///	<remarks>
    /// ビジネスの基本クラス
    ///	<para>作成年月日 2009/3/1</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class BusinessBase
    {
        #region メンバ変数

        /// <summary>
        /// 接続情報ID
        /// </summary>
        private string _connectId;
        
        #endregion

        #region プロパティ

        /// <summary>
        /// 接続情報ID
        /// </summary>
        ///	<remarks>
        /// 接続情報IDを取得、設定
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>接続情報</value>
        public string ConnectId
        {
            get
            {
                return this._connectId;
            }
            set
            {
                this._connectId = value;
            }
        }
        
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public BusinessBase()
        {
            this.ConnectId = string.Empty;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="connectId">接続情報ID</param>
        public BusinessBase(string connectId)
        {
            this.ConnectId = connectId;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// DBに接続できるかチェック
        /// </summary>
        ///	<remarks>
        /// DBに接続できるかチェック
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>True:OK、False:NG</returns>
        public virtual bool CheckConnection()
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance();
            return this.CheckConnection(helper);
        }

        /// <summary>
        /// DBに接続できるかチェック
        /// </summary>
        ///	<remarks>
        /// DBに接続できるかチェック
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="connectId">接続情報ID</param>
        /// <returns>True:OK、False:NG</returns>
        public virtual bool CheckConnection(string connectId)
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance(connectId);
            return this.CheckConnection(helper);
        }

        /// <summary>
        /// DBに接続できるかチェック
        /// </summary>
        ///	<remarks>
        /// DBに接続できるかチェック
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="helper">AbstractDataAccessHelper</param>
        /// <returns>True:OK、False:NG</returns>
        protected virtual bool CheckConnection(AbstractDataAccessHelper helper)
        {
            bool result;

            if (this.GetConnectErrMessage(helper) == string.Empty)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// DB接続エラーの内容を取得
        /// </summary>
        ///	<remarks>
        /// DB接続エラーの内容を取得
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>DB接続エラーの内容</returns>
        public virtual string GetConnectErrMessage()
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance();
            return this.GetConnectErrMessage(helper);
        }

        /// <summary>
        /// DB接続エラーの内容を取得
        /// </summary>
        ///	<remarks>
        /// DB接続エラーの内容を取得
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="connectId">接続情報ID</param>
        /// <returns>DB接続エラーの内容</returns>
        public virtual string GetConnectErrMessage(string connectId)
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance(connectId);
            return this.GetConnectErrMessage(helper);
        }

        /// <summary>
        /// DB接続エラーの内容を取得
        /// </summary>
        ///	<remarks>
        /// DB接続エラーの内容を取得
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="helper">AbstractDataAccessHelper</param>
        /// <returns>DB接続エラーの内容</returns>
        protected virtual string GetConnectErrMessage(AbstractDataAccessHelper helper)
        {
            string errMsg = string.Empty;

            DbConnection con = null;

            try
            {
                con = helper.GetConnection();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    helper.CloseConnection(con);
                }
            }

            return errMsg;
        }

        #endregion
    }
}
