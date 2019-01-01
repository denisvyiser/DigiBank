using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DigiBank.Infra.CrossCutting.Utilities
{
    public class Response<T> where T : class
    {
        ILogger log;
        public string Message { get; set; }
        public Exception Ex { get; set; }
        public bool Status { get; set; }

        // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<T> DataList { get; set; }


        public Response(ILoggerFactory loggerFactory)
        {
            this.log = loggerFactory.CreateLogger(typeof(T).GetType().Name);
        }

        public Response<T> SetData(T data, bool Status)
        {
            this.Data = data;
            this.Status = Status;
            return this;
        }

        public Response<T> SetData(IEnumerable<T> datalist, bool Status)
        {
            this.DataList = datalist;
            this.Status = Status;

            return this;
        }

        public Response<T> SetMessage(string mensagem, bool Status = true, Exception ex = null)
        {
            this.Message = mensagem;
            this.Status = Status;
            this.Data = null;
            this.DataList = null;
            this.Ex = ex;

            if (!Status)
            {
                if (ex == null)
                {
                    this.log.LogWarning(mensagem);
                }
                else
                {
                    this.log.LogError(1, ex, mensagem);
                }
            }

            return this;
        }

    }
}
