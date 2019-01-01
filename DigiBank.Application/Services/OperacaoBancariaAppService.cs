using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiBank.Application.Services
{
    public class OperacaoBancariaAppService : IOperacaoBancariaAppService
    {
        ITransacaoRepository transacaoRepository;
        IClienteRepository clienteRepository;
        TokenContextAccessor tokenAcessor;
        IContaCorrenteRepository contaRespository;
        Response<DocumentoFiscalDTO> response;
        public OperacaoBancariaAppService(ITransacaoRepository transacaoRepository,IClienteRepository clienteRepository, TokenContextAccessor tokenAcessor,
            IContaCorrenteRepository contaRespository, Response<DocumentoFiscalDTO> response)
        {
            this.transacaoRepository = transacaoRepository;
            this.clienteRepository = clienteRepository;
            this.tokenAcessor = tokenAcessor;
            this.contaRespository = contaRespository;
            this.response = response;
        }

        public Response<DocumentoFiscalDTO> Transferencia(TransferenciaDTO obj)
        {
          
            int clienteId = Convert.ToInt32(ClaimsInfo.GetClaimInfo(tokenAcessor.GetToken(), "ClienteId"));

            var contaOrigem = contaRespository.GetBy(c => c.ClienteId == clienteId && c.Numero == obj.ContaOrigem).DataList.FirstOrDefault();

            if (obj.ContaOrigem == obj.ContaDestino)
            {
                response.SetMessage("Conta Destino não pode ser Conta Origem", false);
                return response;
            }

            if (contaOrigem == null)
            {
                response.SetMessage("Conta Origem não encontrada", false);
                return response;
            }

            string NomeClienteOrigem = clienteRepository.Get(contaOrigem.ClienteId).Data.Nome;

            var contaDestino = contaRespository.GetBy(c=> c.Numero == obj.ContaDestino).DataList.FirstOrDefault();

            if (contaDestino == null)
            {
                response.SetMessage("Conta Destino não encontrada", false);
                return response;
            }

            string NomeClienteDestino = clienteRepository.Get(contaOrigem.ClienteId).Data.Nome;

            if (contaOrigem.Saldo < obj.Valor)
            {
                response.SetMessage("Saldo Insuficiente", false);
                return response;
            }

            Transacao transacao = new Transacao();

            transacao.ContaOrigem = contaOrigem.Id;
            transacao.ContaDestino = contaDestino.Id;
            transacao.Valor = obj.Valor;
            transacao.DataTransacao = DateTime.Now;
            transacao.CodigoAutenticacao = StringRandom.GerarCodigoAutenticacao();

            var tranRetorno = transacaoRepository.Insert(transacao);

            if (!tranRetorno.Status)
            {
                response.SetMessage("Erro Ao Realizar Transacao!", false, tranRetorno.Ex);

                return response;
            }

            contaOrigem.Saldo -= obj.Valor;

            var contaOrigemRetorno = contaRespository.Update(contaOrigem);

            if(!contaOrigemRetorno.Status)
            {
                response.SetMessage("Erro Ao Realizar Débito Conta Origem!", false, tranRetorno.Ex);
                return response;
            }

            contaDestino.Saldo += obj.Valor;

            var contaDestinoRetorno = contaRespository.Update(contaDestino);

            if (!contaDestinoRetorno.Status)
            {
                response.SetMessage("Erro Ao Realizar Crédito Conta Destino!", false, tranRetorno.Ex);
                return response;
            }

            DocumentoFiscalDTO doc = new DocumentoFiscalDTO();

            doc.ContaOrigem = obj.ContaOrigem;
            doc.ContaDestino = obj.ContaDestino;
            doc.ClieneNomeOrigem = NomeClienteOrigem;
            doc.ClieneNomeDestino = NomeClienteDestino;
            doc.Valor = transacao.Valor;
            doc.DataOperacao = transacao.DataTransacao;
            doc.CodigoAutenticacao = transacao.CodigoAutenticacao;

            string output = JsonConvert.SerializeObject(doc);

            response.SetMessage(output, true);

            return response;
            
        }
    }
}
