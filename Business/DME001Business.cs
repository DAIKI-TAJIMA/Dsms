using System;
using System.Data.Common;
using System.Collections.Generic;

using Frap3Core.BCore;

using Dsms.DataAccess;
using Dsms.Model;
using Dsms.Resource;

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
        public DME001Business(Frap3Core.BCore.ConnectionInfo connectionInfo, BusinessCommonParams bcp) : base(connectionInfo, bcp)
        {
        }

        #endregion

        #region ユーザマスタ取得

        /// <summary>
        /// ユーザマスタ取得
        /// </summary>
        ///	<remarks>
        /// ユーザマスタ取得
        ///	<para>作成年月日 2019/01/08</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="cdUser">ユーザコード</param>
        /// <param name="anPassword">パスワード</param>
        /// <returns>ユーザマスタモデル</returns>
        public M_USERModel GetMUser(string cdUser, string anPassword)
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance(this._connectionInfo);

            using (DbConnection con = helper.GetConnection())
            {
                try
                {
                    lock (this.GetType())
                    {
                        // データクアセスを生成する。
                        DME001DataAccess da = new DME001DataAccess(con, helper, this.BCP);

                        // ユーザマスタを取得する。
                        M_USERModel model = da.GetMUser(cdUser, anPassword);

                        // ユーザマスタを返却する。 
                        return model;
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
