using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Futureinn.Utility.Variable
{
	///	<summary>
	///	数値の切捨て・切上げ・四捨五入等の機能を提供します。	///	</summary>
	///	<remarks>
	///	数値の切捨て・切上げ・四捨五入等の機能を提供します。	///	<para>作成年月日 2009/06/03</para>
	///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
	///	<para>修正年月日</para>
	///	<para>修正者</para>
	///	<para>修正内容</para>
	///	</remarks>
	public class RoundUtility
	{
		#region メソッド

		#region 四捨五入

		///	<summary>
		///	四捨五入を行います。		///	</summary>
		///	<remarks>
		///	数値の四捨五入を行います。		///	<para>作成年月日 2009/06/03</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容
		///	</para></remarks>
		///	<param name="roundValue">四捨五入対象の数値</param>
		///	<param name="position">小数点以下の桁数(例.小数点以下1桁 = 1 , 整数1桁 = 0 , 整数2桁 = 1)</param>
		///	<returns>四捨五入後の数値</returns>
		public static decimal Round(decimal roundValue, int position)
		{
			// マイナス判断
			bool isMinus = roundValue < 0m;
	
			//　マイナスならプラスに変換
			if (isMinus)
			{
				roundValue = 0m - roundValue;
			}

			//	シフト桁数を算出
			decimal shift = (decimal)Math.Pow(10, (double)position - 1);

			//	四捨五入結果を算出
			decimal result = Decimal.Floor((roundValue * shift + 0.5m)) / shift;

			//　マイナスならマイナスへ戻す			if (isMinus)
			{
				result = 0m - result;
			}

			//	戻り値を設定			return result;
		}

		#endregion

		#region 切上げ

		///	<summary>
		///	切上げを行います。		///	</summary>
		///	<remarks>
		///	数値の切上げを行います。		///	<para>作成年月日 2009/06/03</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="roundValue">切上げ対象の数値</param>
		///	<param name="position">小数点以下の桁数(例.小数点以下1桁 = 1 , 整数1桁 = 0 , 整数2桁 = -1)</param>
		///	<returns>切上げ後の数値</returns>
		public static decimal RoundUp(decimal roundValue, int position)
		{
			// マイナス判断
			bool isMinus = roundValue < 0m;

			//　マイナスならプラスに変換
			if (isMinus)
			{
				roundValue = 0m - roundValue;
			}

			//	シフト桁数を算出
			decimal shift = (decimal)Math.Pow(10, (double)position - 1);

			//	切上げ結果を算出
			decimal result = roundValue * shift;

			if (result - Decimal.Floor(result) != 0m)
			{
				if (result - Decimal.Floor(result) < 0.1m)
				{
					result += 0.1m;
				}
			}

			result = Decimal.Floor(result + 0.9m) / shift;

			//　マイナスならマイナスへ戻す			if (isMinus)
			{
				result = 0m - result;
			}

			//	戻り値を設定
			return result;
		}

		#endregion

		#region 切捨て

		///	<summary>
		///	切捨てを行います。
		///	</summary>
		///	<remarks>
		///	数値の切捨てを行います。
		///	<para>作成年月日 2009/06/03</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="roundValue">切捨て対象の数値</param>
		///	<param name="position">小数点以下の桁数(例.小数点以下1桁 = 1 , 整数1桁 = 0 , 整数2桁 = -1)</param>
		///	<returns>切捨て後の数値</returns>
		public static decimal RoundDown(decimal roundValue, int position)
		{
			// マイナス判断
			bool isMinus = roundValue < 0m;

			//　マイナスならプラスに変換
			if (isMinus)
			{
				roundValue = 0m - roundValue;
			}

			//	シフト桁数を算出
			decimal shift = (decimal)Math.Pow(10, (double)position - 1);

			//	切捨て結果を算出
			decimal result = Decimal.Floor((roundValue * shift)) / shift;

			//　マイナスならマイナスへ戻す			if (isMinus)
			{
				result = 0m - result;
			}

			//	戻り値を設定			return result;
		}

		#endregion

		#endregion
	}
}
