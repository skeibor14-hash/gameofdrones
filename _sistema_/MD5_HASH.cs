using System.Text;
using System.Security.Cryptography;

namespace _sistema_{

	/*Modelo base*/
	public static class MD5_HASH{

		public static string hazar(){

			/*Generar data hazar*/
			string data_hazar = Guid.NewGuid().ToString();

			/*Convertir a bytes*/
			byte[] data_bytes = Encoding.UTF8.GetBytes( data_hazar );

			/*Computar MD5*/
			using( MD5 md5 = MD5.Create() )
			{
				byte[] bytes_hashed = md5.ComputeHash( data_bytes );

				/*Convertir a HEX*/
				StringBuilder sb = new StringBuilder();
				foreach( byte b in bytes_hashed ){
					sb.Append(b.ToString("x2"));
				}

				/*Generar STRING*/
				string hash = sb.ToString();

				/*Devolver HASH*/
				return hash;
			}
		}
	}
}