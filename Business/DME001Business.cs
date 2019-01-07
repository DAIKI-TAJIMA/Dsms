using System;
using System.Data.Common;

using Frap3Core.BCore;

namespace Dsms.Business
{
    public class DME001Business : ProjectBusinessBase
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/04/27</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>connectionInfo</value>
        public DME001Business(Frap3Core.BCore.ConnectionInfo connectionInfo) : base(connectionInfo)
        {
        }

        #endregion

        #region ユーザ取得

        /// <summary>
        /// ユーザ取得
        /// </summary>
        ///	<remarks>
        /// ユーザ取得　※Identityの仕様に準じる
        ///	<para>作成年月日 2018/04/27</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="userId"></param>
        /// <returns>AppNhcUser</returns>
        public void GetUser()
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance(this._connectionInfo);

            using (DbConnection con = helper.GetConnection())
            {
                try
                {
                    lock (this.GetType())
                    {
                    }
                }
                catch (Exception ex)
                {
                    //  再スロー
                    throw ex;
                }
                finally
                {
                    //  コネクションを閉じる
                    helper.CloseConnection(con);
                }
            }
        }

        #endregion
    }
}
