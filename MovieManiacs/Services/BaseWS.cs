using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MovieManiacs.Utils;
using Newtonsoft.Json;

namespace MovieManiacs.Services
{
	public class BaseWS<T> where T : class
	{

		private string _baseURl;

		public BaseWS(string baseUrl)
		{
			this._baseURl = baseUrl;
		}
		public BaseWS()
		{
			this._baseURl = string.Empty;
		}
		public async Task<T> RequestAsync(string URL, ERequestType requestType = ERequestType.Get, object SendObject = null, int triesNumber = 0, string contentType = "application/json")
		{

			T tReturn = null;

			for (int i = 0; i <= triesNumber; i++)
			{
				try
				{

					using (HttpClient client = new HttpClient())
					{
            client.BaseAddress = new Uri( this._baseURl);
						

						var response = new HttpResponseMessage();

						var requestBody = SendObject != null ? JsonHelper<object>.ObjectToJson(SendObject) : string.Empty;

						var httpContent = new StringContent(requestBody, Encoding.UTF8, contentType);

						switch (requestType)
						{
							case ERequestType.Get:
								response = await client.GetAsync(URL);
								break;
							case ERequestType.Post:
								response = await client.PostAsync(URL, httpContent);
								break;
							case ERequestType.Put:
								response = await client.PutAsync(URL, httpContent);
								break;
							case ERequestType.Delete:
								response = await client.DeleteAsync(URL);
								break;
							default:
								break;
						}

						if (response.IsSuccessStatusCode)
						{
							string responseString = await response.Content.ReadAsStringAsync();

							var objetoRetorno = JsonHelper<T>.JsonToObject(responseString);


							tReturn = objetoRetorno;

						}
						else
						{
							if (response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
							{
								if (i == triesNumber)
									throw new Exception("Tempo limite atingido");
							}
							else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
								throw new Exception("Serviço não encontrado");
							else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
							{
								if (i == triesNumber)
									throw new Exception("Serviço indisponível no momento");
							}
							else
								throw new Exception("Falha no acesso!");
						}
					}

				}
				catch (JsonException x)
				{
					throw x;
				}
				catch (Exception x)
				{
					throw x;
				}
			}

			return tReturn;
		}

	}
}