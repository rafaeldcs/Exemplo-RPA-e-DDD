using FuncoesComuns.Requisicao.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Configuration;
using System.Text;

namespace FuncoesComuns.Requisicao.Chamada
{
    public class ChamarRequisicao
    {
        private static T ConsultaRest<T>(string url, HttpMethod method, object objToSerialize = null, string serialize_type = "json", string bearerToken = null, bool sendFiles = false, string contentType = "application/json")
        {
            string jsonRetorno = "";
            string query = "";
            if (serialize_type == "json")
            {
                query = JsonConvert.SerializeObject(objToSerialize, new IsoDateTimeConverter
                {
                    DateTimeFormat = "yyyy-MM-dd"
                });
            }
            else if (serialize_type == "plain")
            {
                query = objToSerialize.ToString();
            }
            if (Encoding.UTF8.GetByteCount(query) / 1024 / 1024 / 1024 > 2.0)
            {
                throw new Exception("Arquivo ultrapassa 2Gb que são permitidos na aplicação");
            }
            using (HttpClient request = new HttpClient())
            {
                try
                {
                    HttpRequestMessage msg = new HttpRequestMessage(method, url)
                    {
                        Content = new StringContent(query, Encoding.UTF8, contentType)
                    };
                    request.Timeout = TimeSpan.FromMinutes(5.0);

                    if (bearerToken != null)
                    {
                        request.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
                    }

                    request.DefaultRequestHeaders.Add("Accept", "*/*");
                    request.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    request.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate");
                    request.DefaultRequestHeaders.Add("Connection", "keep-alive");

                    var result = request.SendAsync(msg)
                        .Result;

                    var content = result.Content
                        .ReadAsStringAsync()
                        .Result;


                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Retorno com erro: {jsonRetorno}");
                    throw new Exception("Erro ao realizar a solicitação. Retorno: " + ex.Message, ex);
                }
            }
        }

        public T FazRequisicao<T, U>(U request, EnumChamada chamada, HttpMethod method, string bearerToken = null)
        {
            try
            {
                var retorno = ConsultaRest<T>(GetEnumDescription<EnumChamada>(EnumChamada.Url) + GetEnumDescription<EnumChamada>(chamada), method, request, "json", bearerToken);

                return retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        internal string GetEnumDescription<T>(T Enumerator)
        {
            string descricao = string.Empty;

            var fieldInfo = Enumerator.GetType().GetField(Enumerator.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    descricao = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return descricao;
        }
    }
}
