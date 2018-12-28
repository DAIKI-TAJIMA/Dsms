using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Futureinn.Utility.Variable
{
	///	<summary>
	///	文字列に関するユーティリティ。
	///	</summary>
	///	<remarks>
	///	文字列に対して各種チェックメソッド、変換メソッド等を提供します。
	///	<para>作成年月日 2009/06/02</para>
	///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
	///	<para>修正年月日</para>
	///	<para>修正者</para>
	///	<para>修正内容</para>
	///	</remarks>
	public class StringUtility
	{
		#region private定数

		/// <summary>
		/// DES暗号化キー
		/// </summary>
		private const string DES_KEY = "jp.co.fi";

		/// <summary>
		/// SHIFT_JISエンコード
		/// </summary>
		private static readonly Encoding ENCODING_SHIFT_JIS = Encoding.GetEncoding("SHIFT_JIS");

        /// <summary>
        /// AES暗号化キー
        /// </summary>
        private const string AES_KEY = "jp.co.fi";

		#endregion private定数

		#region private変数

		#endregion

		#region メソッド

		#region 文字列の全角チェック

		///	<summary>
		///	文字列の全角チェック
		///	</summary>
		///	<remarks>
		///	文字列の全角チェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が全角の場合はtrue。文字列が半角、null、空白の場合はfalse。</returns>
		public static bool IsZenkaku(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	文字列のバイト数を取得
			int num = ENCODING_SHIFT_JIS.GetByteCount(target);

			//	戻り値設定
			return num == target.Length * 2;
		}

		#endregion

		#region 文字列の半角チェック

		///	<summary>
		///	文字列の半角チェック
		///	</summary>
		///	<remarks>
		///	文字列の半角チェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が半角の場合はtrue。文字列が全角、null、空白の場合はfalse。</returns>
		public static bool IsHankaku(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	文字列のバイト数を取得
			int num = ENCODING_SHIFT_JIS.GetByteCount(target);

			//	戻り値設定
			return num == target.Length;
		}

		#endregion

		#region 文字列の空白チェック

		///	<summary>
		///	文字列の空白チェック
		///	</summary>
		///	<remarks>
		///	文字列の空白チェックを行います。但しチェックは、左右のスペースを取除いた値で行います。また、null値は空白とします。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が空白の場合はtrue。</returns>
		public static bool IsBrank(string target)
		{
			return target == null || target.Trim().Length == 0;
		}

		#endregion

		#region 文字列の数値チェック

		///	<summary>
		///	文字列の数値チェック
		///	</summary>
		///	<remarks>
		///	文字列の数値チェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が数値の場合はtrue。文字列が数値以外、null、空白の場合はfalse。</returns>
		public static bool IsNumeric(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	最初の文字が-の場合
			if (target.Substring(0, 1).Equals("-"))
			{
				//	正規表現の検証結果を返却
				return Regex.IsMatch(target.Substring(1, target.Length - 1), @"^[0-9]+$");
			}
			else
			{
				//	正規表現の検証結果を返却
				return Regex.IsMatch(target, @"^[0-9]+$");
			}
		}

		#endregion

		#region 文字列の半角英字チェック

		///	<summary>
		///	文字列の半角英字チェック
		///	</summary>
		///	<remarks>
		///	文字列の半角英字チェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が半角英字の場合はtrue。文字列が半角英字以外、null、空白の場合はfalse。</returns>
		public static bool IsHankakuEiji(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
            //return Regex.IsMatch(target, @"^[a-zA-Z]|[ ]+$");             // 2010/09/27 FI MITSUI DEL
            return Regex.IsMatch(target, @"^[a-zA-Z ]+$");                  // 2010/09/27 FI MITSUI INS         
        }

		#endregion

		#region 文字列の全角ひらがなチェック

		///	<summary>
		///	文字列の全角ひらがなチェック
		///	</summary>
		///	<remarks>
		///	文字列の全角ひらがなチェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が全角ひらがなの場合はtrue。文字列が全角ひらがな以外、null、空白の場合はfalse。</returns>
		public static bool IsHiragana(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
            //return Regex.IsMatch(target, @"^\p{IsHiragana}|[　]+$");          // 2010/09/27 FI MITSUI DEL
            return Regex.IsMatch(target, @"^[\p{IsHiragana}　]+$");             // 2010/09/27 FI MITSUI INS
        }

		#endregion

		#region 文字列の全角カタカナチェック

		///	<summary>
		///	文字列の全角カタカナチェック
		///	</summary>
		///	<remarks>
		///	文字列の全角カタカナチェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が全角カタカナの場合はtrue。文字列が全角カタカナ以外、null、空白の場合はfalse。</returns>
		public static bool IsZenkakuKatakana(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
            //return Regex.IsMatch(target, @"^\p{IsKatakana}|[　]+$");          // 2010/09/27 FI MITSUI DEL
            return Regex.IsMatch(target, @"^[\p{IsKatakana}　]+$");             // 2010/09/27 FI MITSUI INS
        }

		#endregion

		#region 文字列の半角カタカナチェック

		///	<summary>
		///	文字列の半角カタカナチェック
		///	</summary>
		///	<remarks>
		///	文字列の半角カタカナチェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が半角カタカナの場合はtrue。文字列が半角カタカナ以外、null、空白の場合はfalse。</returns>
		public static bool IsHankakuKatakana(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
            //return Regex.IsMatch(target, @"^[ｱ-ﾝ]|[ｦ]|[ ]|[ﾞ]|[ﾟ]+$");        // 2010/09/27 FI MITSUI DEL
            return Regex.IsMatch(target, @"^[ｱ-ﾝｦｧｨｩｪｫｬｮｭｯﾞﾟ -]+$");            // 2010/09/27 FI MITSUI INS
		}

		#endregion

		#region 文字列の郵便番号チェック

		///	<summary>
		///	文字列の郵便番号チェック
		///	</summary>
		///	<remarks>
		///	文字列の郵便番号チェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が郵便番号の場合はtrue。文字列が郵便番号以外、null、空白の場合はfalse。</returns>
		public static bool IsPostNumber(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
			return Regex.IsMatch(target, @"^[0-9]{3}-[0-9]{4}");
		}

		#endregion

		#region 文字列の電子メールアドレスチェック

		///	<summary>
		///	文字列の電子メールアドレスチェック
		///	</summary>
		///	<remarks>
		///	文字列の電子メールアドレスチェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が電子メールアドレスの場合はtrue。文字列が電子メールアドレス以外、null、空白の場合はfalse。</returns>
		public static bool IsEmailAddress(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
            return Regex.IsMatch(target, @".+@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

		#endregion

		#region 文字列のURLチェック

		///	<summary>
		///	文字列のURLチェック
		///	</summary>
		///	<remarks>
		///	文字列のURLチェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列がURLの場合はtrue。文字列がURL以外、null、空白の場合はfalse。</returns>
		public static bool IsUrl(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
			return Regex.IsMatch(target, @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
		}

		#endregion

		#region 文字列の電話番号チェック

		///	<summary>
		///	文字列の電話番号チェック
		///	</summary>
		///	<remarks>
		///	文字列の電話番号チェックを行います。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">チェック対象の文字列</param>
		///	<returns>文字列が電話番号の場合はtrue。文字列が電話番号以外、null、空白の場合はfalse。</returns>
		public static bool IsTelephoneNumber(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//	戻り値設定(チェックNG)
				return false;
			}

			//	正規表現の検証結果を返却
			return Regex.IsMatch(target, @"(0\d{1,4}-|\(0\d{1,4}\) ?)?\d{1,4}-\d{4}");
		}

		#endregion

		//#region 全角文字列変換

		/////	<summary>
		/////	全角文字列変換
		/////	</summary>
		/////	<remarks>
		/////	半角文字列を全角文字列に変換します。
		/////	<para>作成年月日 2009/06/02</para>
		/////	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/////	<para>修正年月日</para>
		/////	<para>修正者</para>
		/////	<para>修正内容</para>
		/////	</remarks>
		/////	<param name="target">変換対象の文字列</param>
		/////	<returns>全角文字に変換した文字列を戻します。</returns>
		//public static string ToZenkaku(string target)
		//{
		//	//	引数が空白の場合
		//	if (StringUtility.IsBrank(target))
		//	{
		//		//	引数をそのまま戻します

		//		return target;
		//	}

		//	//	全角文字列に変換して返却
		//	return Strings.StrConv(target, VbStrConv.Wide, 0);
		//}

		//#endregion

		#region 空白→null変換

		///	<summary>
		///	空白→null変換
		///	</summary>
		///	<remarks>
		///	空白をnullに変換します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">対象の文字列</param>
		///	<returns>指定された文字列が空白の場合はnullを戻します。</returns>
		public static string BlankToNull(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//　nullを戻す
				return null;
			}

			//	引数をそのまま戻す
			return target;
		}

		#endregion

		#region 空白→0変換

		///	<summary>
		///	空白→0変換
		///	</summary>
		///	<remarks>
		///	空白を0に変換します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">対象の文字列</param>
		///	<returns>指定された文字列が空白の場合は0を戻します。</returns>
		public static string BlankToZero(string target)
		{
			//	引数が空白の場合
			if (StringUtility.IsBrank(target))
			{
				//　0を戻す
				return "0";
			}

			//	引数をそのまま戻す
			return target;
		}

		#endregion

		#region 0→空白変換

		///	<summary>
		///	0→空白変換
		///	</summary>
		///	<remarks>
		///	0を空白に変換します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">対象の文字列</param>
		///	<returns>指定された文字列が0の場合は空白を戻します。</returns>
		public static string ZeroToBlank(string target)
		{
			//	引数が0の場合
			if (target == "0")
			{
				//	空白を戻す
				return "";
			}

			//	引数をそのまま戻す
			return target;
		}

		#endregion

		#region 文字列のバイト数取得

		///	<summary>
		///	文字列のバイト数取得
		///	</summary>
		///	<remarks>
		///	文字列のバイト数を取得します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">対象の文字列</param>
		///	<returns>文字列のバイト数</returns>
		public static int GetByteCount(string target)
		{
			return ENCODING_SHIFT_JIS.GetByteCount(target);
		}

		#endregion

		#region 文字列の暗号化

		///	<summary>
		///	文字列の暗号化
		///	</summary>
		///	<remarks>
		///	文字列をDESで暗号化します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="source">暗号化対象の文字列</param>
		///	<returns>暗号化された文字列</returns>
		public static string EncryptByDES(string source)
		{
			return EncryptByDES(source, DES_KEY);
		}

		///	<summary>
		///	文字列の暗号化
		///	</summary>
		///	<remarks>
		///	文字列をDESで暗号化します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="source">暗号化対象の文字列</param>
		///	<param name="key">暗号化に使用する共有キー(8バイト)</param>
		///	<returns>暗号化された文字列</returns>
		public static string EncryptByDES(string source, string key)
		{
			//	DESサービスプロバイダ定義
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();

			//	暗号化キーの設定
			des.Key = Encoding.ASCII.GetBytes(key);

			//	初期化ベクタの設定
			des.IV = des.Key;

			//	暗号化対象文字列をバイト配列に変換
			byte[] byteSource = Encoding.Unicode.GetBytes(source);

			//	DES暗号化オブジェクトの作成
			ICryptoTransform transform = des.CreateEncryptor();

			//	暗号化
			byte[] encrypted = transform.TransformFinalBlock(byteSource, 0, byteSource.Length);

			//	Base64で文字列に変更して結果を返す
			return Convert.ToBase64String(encrypted);
		}

		#endregion

		#region 文字列の復号化

		///	<summary>
		///	文字列の復号化
		///	</summary>
		///	<remarks>
		///	文字列をDESで復号化します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="source">復号化対象の文字列</param>
		///	<returns>復号化された文字列</returns>
		public static string DecryptByDES(string source)
		{
			return DecryptByDES(source, DES_KEY);
		}


		///	<summary>
		///	文字列の復号化
		///	</summary>
		///	<remarks>
		///	文字列をDESで復号化します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="source">復号化対象の文字列</param>
		///	<param name="key">復号化に使用する共有キー(8バイト)</param>
		///	<returns>復号化された文字列</returns>
		public static string DecryptByDES(string source, string key)
		{
			//	DESサービスプロバイダ定義
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();

			//	暗号化キーの設定
			des.Key = Encoding.ASCII.GetBytes(key);

			//	初期化ベクタの設定
			des.IV = des.Key;

			//	Base64で文字列をバイト配列に戻す
			byte[] byteSource = Convert.FromBase64String(source);

			//	DES復号化オブジェクトの作成
			ICryptoTransform transform = des.CreateDecryptor();

			//	復号化
			byte[] decrypted = transform.TransformFinalBlock(byteSource, 0, byteSource.Length);

			//	Unicodeで文字列を戻す
			return Encoding.Unicode.GetString(decrypted);
		}

		#endregion


        #region 文字列の暗号化

        ///	<summary>
        ///	文字列の暗号化
        ///	</summary>
        ///	<remarks>
        ///	文字列をAESで暗号化します。
        ///	<para>作成年月日 2009/10/16</para>
        ///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="source">暗号化対象の文字列</param>
        ///	<returns>暗号化された文字列</returns>
        public static string EncryptByAES(string source)
        {
            return EncryptByAES(source, AES_KEY);
        }

        ///	<summary>
        ///	文字列の暗号化
        ///	</summary>
        ///	<remarks>
        ///	文字列をAESで暗号化します。
        ///	<para>作成年月日 2009/10/16</para>
        ///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="source">暗号化対象の文字列</param>
        ///	<param name="key">暗号化に使用する共有キー(8バイト)</param>
        ///	<returns>暗号化された文字列</returns>
        public static string EncryptByAES(string source, string key)
        {
            //	AESサービスプロバイダ定義
            AesManaged aes = new AesManaged();

            //	暗号化キーの設定
            aes.Key = Encoding.Unicode.GetBytes(key);

            //	初期化ベクタの設定
            aes.IV = aes.Key;

            //	暗号化対象文字列をバイト配列に変換
            byte[] byteSource = Encoding.Unicode.GetBytes(source);

            //	AES暗号化オブジェクトの作成
            ICryptoTransform transform = aes.CreateEncryptor();

            //	暗号化
            byte[] encrypted = transform.TransformFinalBlock(byteSource, 0, byteSource.Length);

            //	Base64で文字列に変更して結果を返す
            return Convert.ToBase64String(encrypted);
        }

        #endregion

        #region 文字列の復号化

        ///	<summary>
        ///	文字列の復号化
        ///	</summary>
        ///	<remarks>
        ///	文字列をAESで復号化します。
        ///	<para>作成年月日 2009/10/16</para>
        ///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="source">復号化対象の文字列</param>
        ///	<returns>復号化された文字列</returns>
        public static string DecryptByAES(string source)
        {
            return DecryptByAES(source, AES_KEY);
        }


        ///	<summary>
        ///	文字列の復号化
        ///	</summary>
        ///	<remarks>
        ///	文字列をAESで復号化します。
        ///	<para>作成年月日 2009/10/16</para>
        ///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="source">復号化対象の文字列</param>
        ///	<param name="key">復号化に使用する共有キー(8バイト)</param>
        ///	<returns>復号化された文字列</returns>
        public static string DecryptByAES(string source, string key)
        {
            //	AESサービスプロバイダ定義
            AesManaged aes = new AesManaged();

            //	暗号化キーの設定
            aes.Key = Encoding.Unicode.GetBytes(key);

            //	初期化ベクタの設定
            aes.IV = aes.Key;

            //	Base64で文字列をバイト配列に戻す
            byte[] byteSource = Convert.FromBase64String(source);

            //	AES復号化オブジェクトの作成
            ICryptoTransform transform = aes.CreateDecryptor();

            //	復号化
            byte[] decrypted = transform.TransformFinalBlock(byteSource, 0, byteSource.Length);

            //	Unicodeで文字列を戻す
            return Encoding.Unicode.GetString(decrypted, 0, decrypted.Length);
        }

        #endregion

		#region 文字列の右詰め

		///	<summary>
		///	文字列の右詰め
		///	</summary>
		///	<remarks>
		///	指定したバイト数になるまで埋め込み文字を左側に詰め込みます。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="source">対象の文字列</param>
		///	<param name="totalWidth">結果として生成される文字列のバイト数</param>
		///	<param name="padingChar">埋め込み文字</param>
		///	<returns>右詰された文字列</returns>
		public static string PadLeft(string source, int totalWidth, char padingChar)
		{
			//	埋め込み文字数の算出
			int paddingLength = totalWidth - StringUtility.GetByteCount(source);

			//	埋め込み文字数 >= 1
			if (paddingLength >= 1)
			{
				//	埋め込み文字列生成
				string paddingString = new string(padingChar, paddingLength);

				//	戻り値セット
				return paddingString + source;
			}
			//	埋め込み文字数 <= 0
			else
			{
				//	指定された文字列を戻す
				return source;
			}
		}

		#endregion

		#region 文字列の左詰

		///	<summary>
		///	文字列の左詰
		///	</summary>
		///	<remarks>
		///	指定したバイト数になるまで埋め込み文字を右側に詰め込みます。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="source">対象の文字列</param>
		///	<param name="totalWidth">結果として生成される文字列のバイト数</param>
		///	<param name="padingChar">埋め込み文字</param>
		///	<returns>左詰された文字列</returns>
		public static string PadRight(string source, int totalWidth, char padingChar)
		{
			//	埋め込み文字数の算出
			int paddingLength = totalWidth - StringUtility.GetByteCount(source);

			//	埋め込み文字数 >= 1
			if (paddingLength >= 1)
			{
				//	埋め込み文字列生成
				string paddingString = new string(padingChar, paddingLength);

				//	戻り値セット
				return source + paddingString;
			}
			//	埋め込み文字数 <= 0
			else
			{
				//	指定された文字列を戻す
				return source;
			}
		}

		#endregion

		#region 文字列の指定されたバイト位置から指定されたバイト数分の文字列取得

		/// <summary>
		/// 文字列の指定されたバイト位置から指定されたバイト数分の文字列取得
		/// </summary>
		/// <remarks>
		/// 文字列の指定されたバイト位置から指定されたバイト数分の文字列取得します
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks>
		/// <param name="target">対象文字列</param>
		/// <param name="start">開始位置(1文字目は0)</param>
		/// <param name="byteSize">取得バイト数</param>
		/// <returns>指定バイトの文字列</returns>
		public static string MidB(string target, int start, int byteSize)
		{
			//	対象文字列がnull or string.Emptyの場合
			if (target == null || target.Equals(string.Empty))
			{
				//	そのまま返す
				return target;
			}

			//	対象文字列をバイトに変換
			byte[] byteValue = ENCODING_SHIFT_JIS.GetBytes(target);

			//	バイト数
			int maxByte = ENCODING_SHIFT_JIS.GetByteCount(target);

			if (start < 0 ||			//	開始位置がマイナス
				byteSize <= 0 ||		//	取得文字バイト数がマイナス
				start > maxByte)		//	開始位置が文字列バイト数より大きい場合

			{
				//	String.Emptyを返す
				return string.Empty;
			}

			//	開始位置の文字が2バイトの途中かどうか
			bool is2Byte = false;

			//	開始位置の文字取得
			string buf = ENCODING_SHIFT_JIS.GetString(byteValue, 0, start);

			if (start > 0 &&
                buf.EndsWith("・"))
			{
				//	開始位置が2バイト文字の途中
				is2Byte = true;

				//	開始位置を+1
				start += 1;
			}

			//	開始位置 + 取得バイト数 が文字列長より長い場合は、最後の文字列まで
			if (start + byteSize > maxByte)
			{
				byteSize = maxByte - start;
			}
			else
			{
				//	開始位置が2バイトの場合は、後ろのバイトは-1
				if (is2Byte)
				{
					byteSize -= 1;
				}
			}

			//	戻り値
			return ENCODING_SHIFT_JIS.GetString(byteValue, start, byteSize).TrimEnd('\0');
		}

		/// <summary>
		/// 文字列の指定されたバイト位置から指定されたバイト数分の文字列取得
		/// </summary>
		/// <remarks>
		/// 文字列の指定されたバイト位置から指定されたバイト数分の文字列取得します
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks>
		/// <param name="target">対象文字列</param>
		/// <param name="start">開始位置(1文字目は0)</param>
		/// <returns>指定バイトの文字列</returns>
		public static string MidB(string target, int start)
		{
			//	バイト数
			int maxByte = ENCODING_SHIFT_JIS.GetByteCount(target);

			//	MidBを呼び出す
			return MidB(target, start, maxByte - start);
		}

		#endregion

		#region 文字列の左端から指定したバイト数分の文字列取得


		/// <summary>
		/// 文字列の左端から指定したバイト数分の文字列取得
		/// </summary>
		/// <remarks>
		/// 文字列の左端から指定したバイト数分の文字列取得します
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks><param name="target">対象文字列</param>
		/// <param name="byteSize">取得バイト数</param>
		/// <returns>指定バイトの文字列</returns>
		public static string LeftB(string target, int byteSize)
		{
			//	MidBを呼び出す
			return MidB(target, 0, byteSize);
		}

		#endregion

		#region 文字列の右端から指定したバイト数分の文字列取得


		/// <summary>
		/// 文字列の右端から指定したバイト数分の文字列取得
		/// </summary>
		/// <remarks>
		/// 文字列の右端から指定したバイト数分の文字列取得します
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks><param name="target">対象文字列</param>
		/// <param name="byteSize">取得バイト数</param>
		/// <returns>指定バイトの文字列</returns>
		public static string RightB(string target, int byteSize)
		{
			//	開始位置
			int start = 0;

			//	バイト数
			int maxByte = ENCODING_SHIFT_JIS.GetByteCount(target);

			//	開始位置取得
			if ((start = maxByte - byteSize) < 0)
			{
				start = 0;
			}

			//	MidBを呼び出す
			return MidB(target, start);
		}

		#endregion

		#region Int16判定

		/// <summary>
		/// Int16判定
		/// </summary>
		/// <remarks>
		/// 文字列がInt16型に変換可能かを判定します。
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks>
		/// <param name="target">対象の文字列</param>
		/// <returns>true:変換可、false:変換不可</returns>
		public static bool IsInt16(string target)
		{
			Int16 result;

			return Int16.TryParse(target, out result);
		}

		#endregion

		#region Int32判定


		/// <summary>
		/// Int32判定
		/// </summary>
		/// <remarks>
		/// 文字列がInt32型に変換可能かを判定します。
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks>
		/// <param name="target">対象の文字列</param>
		/// <returns>true:変換可、false:変換不可</returns>
		public static bool IsInt32(string target)
		{
			Int32 result;

			return Int32.TryParse(target, out result);
		}

		#endregion

		#region Int64判定


		/// <summary>
		/// Int64判定
		/// </summary>
		/// <remarks>
		/// 文字列がInt64型に変換可能かを判定します。
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks>
		/// <param name="target">対象の文字列</param>
		/// <returns>true:変換可、false:変換不可</returns>
		public static bool IsInt64(string target)
		{
			Int64 result;

			return Int64.TryParse(target, out result);
		}

		#endregion

		#region Decimal判定


		/// <summary>
		/// Decimal判定
		/// </summary>
		/// <remarks>
		/// 文字列がDecimal型に変換可能かを判定します。
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks>
		/// <param name="target">対象の文字列</param>
		/// <returns>true:変換可、false:変換不可</returns>
		public static bool IsDecimal(string target)
		{
			decimal result;

			return decimal.TryParse(target, out result);
		}
		
		#endregion

		#region DateTime判定


		/// <summary>
		/// DateTime判定
		/// </summary>
		/// <remarks>
		/// 文字列がDateTime型に変換可能かを判定します。
		/// <para>作成年月日 2009/06/02</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		/// </remarks>
		/// <param name="target">対象の文字列</param>
		/// <returns>true:変換可、false:変換不可</returns>
		public static bool IsDateTime(string target)
		{
			DateTime result;

			return DateTime.TryParse(target, out result);
		}

		#endregion

		#endregion
	}
}
