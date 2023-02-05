using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.ViewModels.Requests;
using Sigesp.Application.ViewModels.Oficios.Educacao;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using Microsoft.AspNetCore.Hosting;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Oficio-Leitura_All,"+
                       "Oficio-Leitura_Create")]
    [ApiController]
    [Route("api/oficios")]
    public class OficioEndPoint : ApiController
    {
        private readonly IAlunoLeituraAppService _alunoLeituraManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAlunoLeituraRepository _alunoLeituraRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SigespDbContext _context;
        private readonly ITenantRepository _tenantRepository;

        public OficioEndPoint(IAlunoLeituraAppService alunoLeituraManager,
                              IWebHostEnvironment webHostEnvironment,
                              IAlunoLeituraRepository alunoLeituraRepository,
                              IUnitOfWork unitOfWork,
                              SigespDbContext context,
                              ITenantRepository tenantRepository) 
        {
            _alunoLeituraManager = alunoLeituraManager;
            _webHostEnvironment = webHostEnvironment;
            _alunoLeituraRepository = alunoLeituraRepository;
            _unitOfWork = unitOfWork;
            _context = context;
            _tenantRepository = tenantRepository;
        }

        #region Ofícios Educação
        [Authorize(Roles = "Master, Oficio-Leitura_All, Oficio-Leitura_Reimpressao")]
        [Route("educacao/leituras/reimprimir/{oficio}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostOficioEducacaoLeituraReimpressao([FromRoute] string oficio)
        {
            #region Required validations
            if (string.IsNullOrEmpty(oficio))
            {
                AddError("Número do ofício requerido.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { throw ex; }
            if (tenantId == null || tenantId == Guid.Empty)
            {
                AddError("Problemas ao obter o id da Unidade Prisional");
                return CustomResponsePassCode(404);
            }
            
            var tenant = new Tenant();
            try
            {
                tenant = await _tenantRepository.GetForOficioLeituraAsync(tenantId);
            }
            catch (Exception ex) { throw ex; }

            if (tenant == null)
            {
                AddError("Nenhum Unidade encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get data for ofício
            IEnumerable<AlunoLeitura> leituras = new List<AlunoLeitura>();
            try
            {
                leituras = await _context
                                    .AlunosLeituras
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Tenant)
                                    .Include(x => x.AlunoLeitor)
                                    .ThenInclude(x => x.Aluno)
                                    .ThenInclude(x => x.Detento)
                                    .ThenInclude(x => x.AndamentoPenal)
                                    .Include(x => x.AlunoLeituraCronograma)
                                    .Include(x => x.Livro)
                                    .Where(x => x.OficioNumero == Convert.ToInt32(oficio) &&
                                           x.TenantId == tenantId)
                                    .ToListAsync();
            }
            catch (Exception ex) { throw ex; }
            if (leituras == null)
            {
                AddError("Nenhuma leitura encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            var result = new OficioEducacaoLeituraViewModel();
            result.Leituras = new List<OficioEducacaoLeitura>();

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
            try
            {
                result.OficioNumero = leituras.Select(x => x.OficioNumero).FirstOrDefault().ToString();
                result.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";
                result.DetentoNome = leituras.Select(x => x.AlunoLeitor.Aluno.Detento.Nome).FirstOrDefault();
                result.DetentoIpen = leituras.Select(x => x.AlunoLeitor.Aluno.Detento.Ipen).FirstOrDefault().ToString();
                result.DetentoPec = leituras.Select(x => x.AlunoLeitor.Aluno.Detento.AndamentoPenal.Pec).FirstOrDefault().Replace(" ", "");
                result.OficioRemicao = (leituras.Count(x => x.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.APROVADO) * 4).ToString();
                
                foreach (var leitura in leituras.ToList())
                {
                    try
                    {
                        var item = new OficioEducacaoLeitura
                        {
                            Id = leitura.Id,
                            AnoReferencia = leitura.AlunoLeituraCronograma.AnoReferencia,
                            PeriodoReferenciaSequencia = leitura.AlunoLeituraCronograma.PeriodoReferencia,
                            PeriodoReferencia = leitura.AlunoLeituraCronograma.PeriodoInicio.ToString("dd/MM/yyyy") + " a " + leitura.AlunoLeituraCronograma.PeriodoFim.ToString("dd/MM/yyyy"),
                            TituloLivro = leitura.Livro.Titulo,
                            LeituraRemicao = leitura.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.APROVADO ? 4.ToString() : "0",
                            Conceito = leitura.AvaliacaoConceito.ToString()
                        };
                        result.Leituras.Add(item);    
                    }
                    catch (Exception ex) { throw ex; }
                }
                
                result.Tenant =  new Tenant()
                {
                    NomeExibicao = tenant.NomeExibicao,
                    OficioLeituraAssinaturaNome = tenant.OficioLeituraAssinaturaNome,
                    OficioLeituraAssinaturaCargo = tenant.OficioLeituraAssinaturaCargo,
                    OficioLeituraAssinaturaMatricula = tenant.OficioLeituraAssinaturaMatricula,
                    EnderecoLogradouro = tenant.EnderecoLogradouro,
                    EnderecoLogradouroNumero = tenant.EnderecoLogradouroNumero,
                    EnderecoBairro = tenant.EnderecoBairro,
                    EnderecoCEP = tenant.EnderecoCEP,
                    EnderecoCidade = tenant.EnderecoCidade,
                    EnderecoEstado = tenant.EnderecoEstado,
                    TelefoneDDD = tenant.TelefoneDDD,
                    TelefoneNumero = tenant.TelefoneNumero,
                    EmailPrincipal = tenant.EmailPrincipal,
                    OficioLeituraVocativo1 = tenant.OficioLeituraVocativo1,
                    OficioLeituraVocativo2 = tenant.OficioLeituraVocativo2,
                    OficioLeituraVocativo3 = tenant.OficioLeituraVocativo3
                };
            }
            catch (Exception ex) { throw ex; }
            #endregion

            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
            byte[] bytes = null;

            var posFixoNomeArquivo = result.DetentoNome;
            var nomeArquivo = "OFICIO(S)_LEITURA(S)_" + posFixoNomeArquivo + ".pdf";
            var newEntry = new ZipEntry(nomeArquivo.Replace("/", "-"));
            newEntry.DateTime = DateTime.Now;

            zipStream.PutNextEntry(newEntry);

            bytes = PdfCreateToOficioLeitura(result);

            MemoryStream inStream = new MemoryStream(bytes);
            StreamUtils.Copy(inStream, zipStream, new byte[4096]);
            inStream.Close();
            zipStream.CloseEntry();

            zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

            outputMemStream.Position = 0;

            // Atualizar dados de ofício nas leituras
            foreach (var leitura in result.Leituras)
            {
                var leituraForUpdate = _alunoLeituraRepository.GetById(leitura.Id);
                if (leituraForUpdate == null)
                    return StatusCode(400, "Problemas ao obter a leitura para atualizar seus dados de ofício. Tente novamente mais tarde, persistindo, informe a equipe técnica do sistema;");
                
                leituraForUpdate.HasOficio = true;
                leituraForUpdate.OficioNumero = Convert.ToInt32(result.OficioNumero);
                leituraForUpdate.OficioDataCriacao = DateTime.Now;

                _alunoLeituraRepository.Update(leituraForUpdate);
            }
            _unitOfWork.Commit();

            return File(outputMemStream.ToArray(), "application/octet-stream");
        }

        [Authorize(Roles = "Master, Oficio-Leitura_All, Oficio-Leitura_Create")]
        [Route("educacao/leituras/create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostOficioEducacaoLeituraCreate([FromBody] OficioEducacaoLeituraRequestModel oficioEducacaoLeituraRequestModel)
        {
            #region Get data for ofício
            var result = new OficioEducacaoLeituraViewModel();
            try
            {
                result = await _alunoLeituraManager.GetOficioLeituraAsync(oficioEducacaoLeituraRequestModel.LeiturasIds);
            }
            catch(Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            if (result == null)
                return StatusCode(404, "Nenhuma leitura encontrada com os ids informados para criação do ofício.");

            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
            byte[] bytes = null;

            var posFixoNomeArquivo = result.DetentoNome;
            var nomeArquivo = "OFICIO(S)_LEITURA(S)_" + posFixoNomeArquivo + ".pdf";
            var newEntry = new ZipEntry(nomeArquivo.Replace("/", "-"));
            newEntry.DateTime = DateTime.Now;

            zipStream.PutNextEntry(newEntry);

            bytes = PdfCreateToOficioLeitura(result);

            MemoryStream inStream = new MemoryStream(bytes);
            StreamUtils.Copy(inStream, zipStream, new byte[4096]);
            inStream.Close();
            zipStream.CloseEntry();

            zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

            outputMemStream.Position = 0;

            // Atualizar dados de ofício nas leituras
            foreach (var leitura in result.Leituras)
            {
                var leituraForUpdate = await _context
                                                .AlunosLeituras
                                                .IgnoreQueryFilters()
                                                .FirstOrDefaultAsync(x => x.Id == leitura.Id);

                if (leituraForUpdate == null)
                    return StatusCode(400, "Problemas ao obter a leitura para atualizar seus dados de ofício. Tente novamente mais tarde, persistindo, informe a equipe técnica do sistema;");
                
                leituraForUpdate.HasOficio = true;
                leituraForUpdate.OficioNumero = Convert.ToInt32(result.OficioNumero);
                leituraForUpdate.OficioDataCriacao = DateTime.Now;

                _alunoLeituraRepository.Update(leituraForUpdate);
            }
            _unitOfWork.Commit();

            return File(outputMemStream.ToArray(), "application/octet-stream", "reports.zip");
        }

        [Authorize(Roles = "Master, Oficio-Leitura_All, Oficio-Leitura_Delete")]
        [Route("educacao/leituras/cancelar/{oficio}")]
        [HttpDelete]
        public async Task<IActionResult> PostOficioEducacaoLeituraDelete([FromRoute] string oficio)
        {
            #region Required validations
            if (string.IsNullOrEmpty(oficio))
            {
                AddError("Número do ofício requerido.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get leituras vinculadas ao ofício da tenancy
            var leituras = new List<AlunoLeitura>();
            try
            {
                leituras =  await _context
                                    .AlunosLeituras
                                    .IgnoreQueryFilters()
                                    .Where(x => x.OficioNumero == Convert.ToInt32(oficio) &&
                                           x.TenantId == tenantId)
                                    .ToListAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (leituras == null || leituras.Count() <= 0)
            {
                AddError("Nenhuma leitura encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Clean número de ofício das leituras
            foreach (var leitura in leituras)
            {
                leitura.OficioNumero = 0;
                leitura.HasOficio = false;
                _context.AlunosLeituras.Update(leitura);
            }
            #endregion

            #region Commit and return
            _unitOfWork.Commit();
            return CustomResponsePassCode(204);
            #endregion
        }
        #endregion

        #region Private methods
        private byte[] PdfCreateToOficioLeitura(OficioEducacaoLeituraViewModel oficioEducacaoLeituraViewModel) 
        {
            var zipFileMemoryStream = new MemoryStream();
            Document document = new Document(PageSize.A4, 25, 25, 25, 15);
            document.SetMargins(15, 15, 25, 0);

            PdfWriter pw = PdfWriter.GetInstance(document, zipFileMemoryStream);                      

            document.Open();

            var leiturasOrdenandasPorPeriodoRefencia = oficioEducacaoLeituraViewModel.Leituras.OrderBy(x => x.AnoReferencia).ThenBy(x => x.PeriodoReferenciaSequencia);
            #region PAGE PDF 1

            #region HEADER
            /// Instância da tabela HEADER
            PdfPTable tableHeader = new PdfPTable(2);
            tableHeader.WidthPercentage = 100f;

            /// Instâncias 3 células do HEADER
            PdfPCell cellHeaderLogoSc = new PdfPCell();
            cellHeaderLogoSc.Border = 0;
            PdfPCell cellHeaderTitulo = new PdfPCell(new Paragraph("ESTADO DE SANTA CATARINA" + "\nSECRETARIA DE ESTADO DA ADMINISTRAÇÃO PRISIONAL E SOCIOEDUCATIVA" +  "\n"+ oficioEducacaoLeituraViewModel.Tenant.NomeExibicao + "\nCOORDENAÇÃO DE ENSINO E PROMOÇÃO SOCIAL", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellHeaderTitulo.Border = 0;
            cellHeaderTitulo.SetLeading(4, 1);

            /// Definição de largura das colunas das tabelas
            float[] tableHeaderSize= new float[] {15, 85};
            tableHeader.SetWidths(tableHeaderSize);

            /// Ajuste de Alinhamento das células
            cellHeaderTitulo.PaddingTop = 2;

            //Path imagens HEADER
            string folderLogoSCName = "img\\logo-sc.png";
            string webRootPath = _webHostEnvironment.WebRootPath;
            string pathLogoSCImg = System.IO.Path.Combine(webRootPath, folderLogoSCName);

            Image imageLogoSC = Image.GetInstance(pathLogoSCImg);

            imageLogoSC.ScaleAbsolute(70, 80);

            // var headerTitulo1 = new Chunk("ESTADO DE SANTA CATARINA", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            // var headerTitul2 = new Chunk("SECRETARIA DE ESTADO DA ADMINISTRAÇÃO PRISIONAL E SOCIOEDUCATIVA", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            // var headerTitulo3 = new Chunk(oficioEducacaoLeituraViewModel.Tenant.NomeExibicao, FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            // var headerTitulo4 = new Chunk("COORDENAÇÃO DE ENSINO E PROMOÇÃO SOCIAL", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            
            cellHeaderTitulo.PaddingLeft = 20;
            cellHeaderTitulo.FixedHeight = 40f;
            cellHeaderTitulo.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellHeaderTitulo.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            // cellHeaderTitulo.AddElement(headerTitulo1);
            // cellHeaderTitulo.AddElement(headerTitul2);
            // cellHeaderTitulo.AddElement(headerTitulo3);
            // cellHeaderTitulo.AddElement(headerTitulo4);

            cellHeaderLogoSc.PaddingLeft = 30;
            cellHeaderLogoSc.AddElement(imageLogoSC);

            tableHeader.AddCell(cellHeaderLogoSc);
            tableHeader.AddCell(cellHeaderTitulo);

            document.Add(tableHeader);
            #endregion

            #region HEADER OFÍCIO - DATA
            /// Tabela ofício e data
            PdfPTable tableHOD = new PdfPTable(2);
            tableHOD.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableHODSize= new float[] {25, 75};
            tableHOD.SetWidths(tableHODSize);

            /// Célula ofício
            PdfPCell cellOficio = new PdfPCell(new Phrase("Ofício nº " + oficioEducacaoLeituraViewModel.OficioNumero + "/" + DateTime.Now.Year, FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellOficio.Border = 0;
            cellOficio.FixedHeight = 40f;
            cellOficio.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellOficio.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cellOficio.PaddingLeft = 32;

            tableHOD.AddCell(cellOficio);

            /// Célula data
            PdfPCell cellData = new PdfPCell(new Phrase(oficioEducacaoLeituraViewModel.OficioData, FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellData.Border = 0;
            cellData.FixedHeight = 30f;
            cellData.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cellData.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cellData.PaddingRight = 35;

            tableHOD.AddCell(cellData);
            document.Add(tableHOD);
            #endregion

            #region HEADER CUMPRIMENTO
            /// Tabela cumprimento
            PdfPTable tableHC = new PdfPTable(1);
            tableHC.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableHCSize= new float[] {100};
            tableHC.SetWidths(tableHCSize);

            /// Célula ofício
            PdfPCell cellCumprimento = new PdfPCell(new Phrase("Excelentíssimo(a) Juíz(a),", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));
            cellCumprimento.Border = 0;
            cellCumprimento.FixedHeight = 67f;
            cellCumprimento.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellCumprimento.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cellCumprimento.PaddingLeft = 77;

            tableHC.AddCell(cellCumprimento);
            document.Add(tableHC);
            #endregion

            #region CONTENT 1
            /// Tabela content 1
            PdfPTable tableC1 = new PdfPTable(1);
            tableC1.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableC1Size= new float[] {100};
            tableC1.SetWidths(tableC1Size);

            /// Célula ofício
            PdfPCell cellC1 = new PdfPCell();
            // cellC1.AddElement(new Phrase("ENCAMINHAMOS a Vossa Excelência, nos termos da Portaria 06/2018, a REMIÇÃO POR LEITURA, em favor do reeducando ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            // cellC1.AddElement(new Phrase(oficioEducacaoLeituraViewModel.DetentoNome + " (IPEN " + oficioEducacaoLeituraViewModel.DetentoIpen + " - PEC " + oficioEducacaoLeituraViewModel.DetentoPec + ").", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));

            Phrase texto_1= new Phrase("               ENCAMINHAMOS ", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK));
            Phrase texto_2= new Phrase("a Vossa Excelência, nos termos da Portaria 06/2018, a ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            Phrase texto_3= new Phrase("REMIÇÃO POR LEITURA ", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK));
            Phrase texto_4= new Phrase(", em favor do reeducando ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            Phrase texto_5 = new Phrase(oficioEducacaoLeituraViewModel.DetentoNome + " (IPEN " + oficioEducacaoLeituraViewModel.DetentoIpen + " - PEC " + oficioEducacaoLeituraViewModel.DetentoPec + ").", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK));
            Paragraph texto_2_formatacoes= new Paragraph{texto_1, texto_2, texto_3, texto_4, texto_5};
            // texto_2_formatacoes.IndentationLeft = 100;
            
            cellC1.AddElement(texto_2_formatacoes);

            cellC1.Border = 0;
            cellC1.FixedHeight = 100f;
            cellC1.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;
            cellC1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            cellC1.Indent = 45;
            cellC1.SetLeading(4, 1);
            cellC1.PaddingRight = 34;
            cellC1.PaddingLeft = 32;
            cellC1.PaddingTop = 45;

            tableC1.AddCell(cellC1);

            document.Add(tableC1);
            #endregion

            #region CONTENT 2
            /// Tabela content 2
            PdfPTable tableC2 = new PdfPTable(1);
            tableC2.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableC2Size = new float[] {100};
            tableC2.SetWidths(tableC2Size);

            /// Célula ofício
            PdfPCell cellC2 = new PdfPCell(new Phrase("REGISTRAMOS que conforme RELATÓRIO de LEITURA(S) anexo, o reeducando procedeu com a(s) leitura(s) do(s) livro(s) apresentado(s), evidenciando aprovação na(s) leitura(s) de conceito 'APROVADO'.", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellC2.Border = 0;
            cellC2.FixedHeight = 55f;
            cellC2.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;
            cellC2.VerticalAlignment = PdfPCell.ALIGN_TOP;

            cellC2.Indent = 45;
            cellC2.SetLeading(4, 1);
            cellC2.PaddingRight = 34;
            cellC2.PaddingLeft = 32;

            tableC2.AddCell(cellC2);
            document.Add(tableC2);
            #endregion

            #region CONTENT 3
            /// Tabela content 3
            PdfPTable tableC3 = new PdfPTable(1);
            tableC3.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableC3Size = new float[] {100};
            tableC3.SetWidths(tableC3Size);

            /// Célula ofício
            PdfPCell cellC3 = new PdfPCell();
            // cellC1.AddElement(new Phrase("ENCAMINHAMOS a Vossa Excelência, nos termos da Portaria 06/2018, a REMIÇÃO POR LEITURA, em favor do reeducando ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            // cellC1.AddElement(new Phrase(oficioEducacaoLeituraViewModel.DetentoNome + " (IPEN " + oficioEducacaoLeituraViewModel.DetentoIpen + " - PEC " + oficioEducacaoLeituraViewModel.DetentoPec + ").", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));

            Phrase texto_6= new Phrase("               Sendo assim, ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            Phrase texto_7= new Phrase("SOLICITAMOS ", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK));
            Phrase texto_8= new Phrase("a homologação de um total de ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            Phrase texto_9= new Phrase(oficioEducacaoLeituraViewModel.OficioRemicao + " dia(s) de remição ", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK));
            Phrase texto_10= new Phrase("em face da(s) leitura(s) realizada(s), com base no art. 126 da LEP c/c art. 5º, inciso IV da Recomendação n° 391/2021, do CNJ.", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            Paragraph texto_3_formatacoes= new Paragraph{texto_6, texto_7, texto_8, texto_9, texto_10};
            
            cellC3.AddElement(texto_3_formatacoes);

            cellC3.Border = 0;
            cellC3.FixedHeight = 55f;
            cellC3.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;
            cellC3.VerticalAlignment = PdfPCell.ALIGN_TOP;

            cellC3.Indent = 45;
            cellC3.SetLeading(4, 1);
            cellC3.PaddingRight = 34;
            cellC3.PaddingLeft = 32;

            tableC3.AddCell(cellC3);
            document.Add(tableC3);
            #endregion

            #region RESPEITOSAMENTE
            /// Tabela RESPEITOSAMENTE
            PdfPTable tableR = new PdfPTable(1);
            tableR.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableRSize = new float[] {100};
            tableR.SetWidths(tableRSize);

            /// Célula ofício
            PdfPCell cellR = new PdfPCell(new Paragraph(@"Respeitosamente,", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellR.Border = 0;
            cellR.FixedHeight = 110f;
            cellR.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cellR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            cellR.PaddingRight = 195;

            tableR.AddCell(cellR);
            document.Add(tableR);
            #endregion

            #region ASSINATURA
            /// Tabela ASSINATURA NOME
            PdfPTable tableAN = new PdfPTable(1);
            tableAN.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableANSize = new float[] {100};
            tableAN.SetWidths(tableANSize);

            /// Célula ofício
            PdfPCell cellAN = new PdfPCell(new Paragraph("(documento assinado digitalmente)", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellAN.Border = 0;
            cellAN.FixedHeight = 30f;
            cellAN.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellAN.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cellAN.PaddingTop = 5;
            cellAN.PaddingLeft = 172;

            tableAN.AddCell(cellAN);

            PdfPCell cellAC = new PdfPCell(new Paragraph(oficioEducacaoLeituraViewModel.Tenant.OficioLeituraAssinaturaNome, FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));
            cellAC.Border = 0;
            cellAC.FixedHeight = 15f;
            cellAC.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellAC.VerticalAlignment = PdfPCell.ALIGN_TOP;

            cellAC.PaddingLeft = 114;

            tableAN.AddCell(cellAC);

            PdfPCell cellAM = new PdfPCell(new Paragraph(oficioEducacaoLeituraViewModel.Tenant.OficioLeituraAssinaturaCargo, FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellAM.Border = 0;
            cellAM.FixedHeight = 15f;
            cellAM.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellAM.VerticalAlignment = PdfPCell.ALIGN_TOP;

            cellAM.PaddingLeft = 185;

            tableAN.AddCell(cellAM);
            
            document.Add(tableAN);
            #endregion

            #region VOCATIVO
            /// Tabela ASSINATURA NOME
            PdfPTable tableVCTVO = new PdfPTable(1);
            tableVCTVO.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableVCTVOSize = new float[] {100};
            tableVCTVO.SetWidths(tableVCTVOSize);

            /// Célula ofício
            PdfPCell cellVCTVO = new PdfPCell(new Paragraph(oficioEducacaoLeituraViewModel.Tenant.OficioLeituraVocativo1 + "\n" + oficioEducacaoLeituraViewModel.Tenant.OficioLeituraVocativo2.ToUpper() + "\n" + oficioEducacaoLeituraViewModel.Tenant.OficioLeituraVocativo3, FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellVCTVO.Border = 0;
            cellVCTVO.FixedHeight = 120f;
            cellVCTVO.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellVCTVO.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cellVCTVO.PaddingLeft = 31;
            cellVCTVO.SetLeading(3, 1);

            tableVCTVO.AddCell(cellVCTVO);
            document.Add(tableVCTVO);
            #endregion

            #region VOCATIVO NESTA
            /// Tabela ASSINATURA NOME
            PdfPTable tableVCTVONT = new PdfPTable(1);
            tableVCTVONT.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableVCTVONTSize = new float[] {100};
            tableVCTVONT.SetWidths(tableVCTVONTSize);

            /// Célula ofício
            PdfPCell cellVCTVONT = new PdfPCell(new Paragraph(oficioEducacaoLeituraViewModel.Tenant.EnderecoCidade + "/" + oficioEducacaoLeituraViewModel.Tenant.EnderecoEstado, FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellVCTVONT.Border = 0;
            cellVCTVONT.FixedHeight = 50f;
            cellVCTVONT.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellVCTVONT.VerticalAlignment = PdfPCell.ALIGN_TOP;

            cellVCTVONT.PaddingLeft = 31;

            tableVCTVONT.AddCell(cellVCTVONT);
            document.Add(tableVCTVONT);
            #endregion

            #region FOOTER - POLICIAL PENAL
            /// Tabela FOOTER POLICIAL PENAL
            PdfPTable tableFPP = new PdfPTable(1);
            tableFPP.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableFPPSize = new float[] {100};
            tableFPP.SetWidths(tableFPPSize);

            /// Célula 1
            PdfPCell cellFPP = new PdfPCell(new Paragraph(@"POLÍCIA PENAL DE SANTA CATARINA", FontFactory.GetFont("Roboto", 8, Font.BOLD, BaseColor.BLACK)));
            cellFPP.Border = 0;
            cellFPP.FixedHeight = 12f;
            cellFPP.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellFPP.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            tableFPP.AddCell(cellFPP);

            /// Célula 2
            PdfPCell cellUP = new PdfPCell(new Paragraph(oficioEducacaoLeituraViewModel.Tenant.NomeExibicao, FontFactory.GetFont("Roboto", 8, Font.BOLD, BaseColor.BLACK)));
            cellUP.Border = 0;
            cellUP.FixedHeight = 12f;
            cellUP.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellUP.VerticalAlignment = PdfPCell.ALIGN_TOP;

            tableFPP.AddCell(cellUP);

            /// Célula 3
            PdfPCell cellEND = new PdfPCell(new Paragraph(oficioEducacaoLeituraViewModel.Tenant.EnderecoLogradouro + ", nº " + oficioEducacaoLeituraViewModel.Tenant.EnderecoLogradouroNumero + " - Bairro: " + oficioEducacaoLeituraViewModel.Tenant.EnderecoBairro + " - CEP " + oficioEducacaoLeituraViewModel.Tenant.EnderecoCEP + " - " + oficioEducacaoLeituraViewModel.Tenant.EnderecoCidade + "/" + oficioEducacaoLeituraViewModel.Tenant.EnderecoEstado, FontFactory.GetFont("Roboto", 8, BaseColor.BLACK)));
            cellEND.Border = 0;
            cellEND.FixedHeight = 12f;
            cellEND.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellEND.VerticalAlignment = PdfPCell.ALIGN_TOP;

            tableFPP.AddCell(cellEND);

            /// Célula 4
            PdfPCell cellTEL = new PdfPCell(new Paragraph("Telefone: ("+ oficioEducacaoLeituraViewModel.Tenant.TelefoneDDD + ") " + oficioEducacaoLeituraViewModel.Tenant.TelefoneNumero + " / " + "E-mail: " + oficioEducacaoLeituraViewModel.Tenant.EmailPrincipal, FontFactory.GetFont("Roboto", 8, BaseColor.BLACK)));
            cellTEL.Border = 0;
            cellTEL.FixedHeight = 12f;
            cellTEL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellTEL.VerticalAlignment = PdfPCell.ALIGN_TOP;

            tableFPP.AddCell(cellTEL);

            document.Add(tableFPP);
            #endregion
            
            #endregion

            #region PAGE PDF 2

            #region HEADER REPORT LEITURAS
            // cellHeaderTitulo.AddElement(headerTitulo1);
            tableHeader.AddCell(cellHeaderTitulo);
            document.Add(tableHeader);
            #endregion

            #region HEADER OFÍCIO + DATA
            PdfPTable tableLaudo = new PdfPTable(1);
            tableLaudo.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableLaudoSize = new float[] {100};
            tableLaudo.SetWidths(tableLaudoSize);

            PdfPCell cellLaudo = new PdfPCell(new Phrase("Relatório nº " + oficioEducacaoLeituraViewModel.OficioNumero + "/" + DateTime.Now.Year, FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellLaudo.Border = 0;
            cellLaudo.FixedHeight = 30f;
            cellLaudo.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellLaudo.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cellLaudo.PaddingLeft = 32;

            tableLaudo.AddCell(cellLaudo);
            document.Add(tableLaudo);
            #endregion

            #region RELATÓRIO DE LEITURA(S)
            PdfPTable tableC6 = new PdfPTable(1);
            tableC6.WidthPercentage = 50f;

            /// Definição de largura das colunas das tabelas
            float[] tableC6Size = new float[] {100};
            tableC6.SetWidths(tableC6Size);

            PdfPCell cellC6 = new PdfPCell(new Paragraph("RELATÓRIO DE LEITURA(S)", FontFactory.GetFont("Roboto", 12, Font.BOLDITALIC, BaseColor.BLACK)));
            cellC6.Border = 0;
            cellC6.FixedHeight = 40f;
            cellC6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellC6.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            tableC6.AddCell(cellC6);

            document.Add(tableC6);
            #endregion

            #region CONTENT 4
            /// Tabela content 1
            PdfPTable tableC4 = new PdfPTable(1);
            tableC4.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableC4Size = new float[] {100};
            tableC4.SetWidths(tableC4Size);

            /// Célula ofício
            PdfPCell cellC4 = new PdfPCell();
            Phrase texto_11 = new Phrase("               Conforme relatório abaixo, reeducando apresentou um total de ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            Phrase texto_12 = new Phrase(oficioEducacaoLeituraViewModel.Leituras.Count(x => x.Conceito == AlunoLeituraAvaliacaoConceitoEnum.APROVADO.ToString()) + "" + " leitura(s) no conceito APROVADA, ", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK));
            Phrase texto_13 = new Phrase("o que por sua vez lhe confere o direito a um total de ", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK));
            Phrase texto_14 = new Phrase(oficioEducacaoLeituraViewModel.OficioRemicao + " dia(s) de remição.", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK));
            Paragraph texto_4_formatacoes = new Paragraph{texto_11, texto_12, texto_13, texto_14};
            
            cellC4.AddElement(texto_4_formatacoes);
            cellC4.Border = 0;
            cellC4.FixedHeight = 60f;
            cellC4.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;
            cellC4.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cellC4.Indent = 45;
            cellC4.SetLeading(4, 1);
            cellC4.PaddingRight = 35;
            cellC4.PaddingLeft = 32;    

            tableC4.AddCell(cellC4);

            document.Add(tableC4);
            #endregion

            #region CONTENT 5
            /// Tabela content 1
            PdfPTable tableC5 = new PdfPTable(1);
            tableC5.WidthPercentage = 100f;

            /// Definição de largura das colunas das tabelas
            float[] tableC5Size = new float[] {100};
            tableC5.SetWidths(tableC5Size);

            /// Célula ofício
            PdfPCell cellC5 = new PdfPCell(new Paragraph("De outra forma, no que tange os NÃO CUMPRIMENTOS e INSUFICIÊNCIAS, o reeducando apresentou um total de " + oficioEducacaoLeituraViewModel.Leituras.Count(x => x.Conceito == AlunoLeituraAvaliacaoConceitoEnum.NAO_CUMPRIMENTO.ToString() || x.Conceito == AlunoLeituraAvaliacaoConceitoEnum.INSUFICIENTE.ToString()) + "" + " leitura(s) nestes conceitos, o que por sua vez não lhe confere o direito a remição.", FontFactory.GetFont("Roboto", 11, BaseColor.BLACK)));
            cellC5.Border = 0;
            cellC5.FixedHeight = 80f;
            cellC5.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;
            cellC5.VerticalAlignment = PdfPCell.ALIGN_TOP;

            cellC5.Indent = 45;
            cellC5.SetLeading(4, 1);
            cellC5.PaddingRight = 35;
            cellC5.PaddingLeft = 32;

            tableC5.AddCell(cellC5);

            document.Add(tableC5);
            #endregion

            #region RELATÓRIO DE LEITURAS
            /// Tabela RELATÓRIO DE LEITURAS
            PdfPTable tableGLT = new PdfPTable(1);
            tableGLT.WidthPercentage = 90f;

            /// Definição de largura das colunas das tabelas
            float[] tableGLTSize= new float[] {100};
            tableGLT.SetWidths(tableGLTSize);

            /// Célula ofício
            PdfPCell cellGLT = new PdfPCell(new Phrase("GRADE DE LEITURA(S)", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
            cellGLT.FixedHeight = 30f;
            cellGLT.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellGLT.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            tableGLT.AddCell(cellGLT);
            document.Add(tableGLT);
            #endregion

            #region GRADE LEITURA CONTEÚDO - TÍTULO
            /// Tabela GRADE LEITURA CONTEÚDO
            PdfPTable tableGLC = new PdfPTable(4);
            tableGLC.WidthPercentage = 90f;

            /// Definição de largura das colunas das tabelas
            float[] tableGLCSize= new float[] {25, 42, 10, 23};
            tableGLC.SetWidths(tableGLCSize);

            /// Célula GRADE LEITURA CONTEÚDO TÍTULO - PERÍODO LEITURA
            PdfPCell cellGLCTPL = new PdfPCell(new Phrase("Período Leitura", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));
            cellGLCTPL.FixedHeight = 25f;
            cellGLCTPL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellGLCTPL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            tableGLC.AddCell(cellGLCTPL);

            /// Célula GRADE LEITURA CONTEÚDO TÍTULO - TÍTULO LIVRO
            PdfPCell cellGLCTTL = new PdfPCell(new Phrase("Título Livro", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));
            cellGLCTTL.FixedHeight = 25f;
            cellGLCTTL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellGLCTTL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            tableGLC.AddCell(cellGLCTTL);

            /// Célula GRADE LEITURA CONTEÚDO TÍTULO - REMIÇÃO
            PdfPCell cellGLCTR = new PdfPCell(new Phrase("Remição", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));
            cellGLCTR.FixedHeight = 25f;
            cellGLCTR.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellGLCTR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            tableGLC.AddCell(cellGLCTR);

            /// Célula GRADE LEITURA CONTEÚDO TÍTULO - CONCEITO
            PdfPCell cellGLCTC = new PdfPCell(new Phrase("Conceito", FontFactory.GetFont("Roboto", 11, Font.BOLD, BaseColor.BLACK)));
            cellGLCTC.FixedHeight = 25f;
            cellGLCTC.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cellGLCTC.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            tableGLC.AddCell(cellGLCTC);

            document.Add(tableGLC);
            #endregion

            #region CREATE REPORT LEITURAS
            foreach (var dadoLeitura in leiturasOrdenandasPorPeriodoRefencia.ToList())
            {
                #region GRADE LEITURA CONTEÚDO - L1
                /// Tabela GRADE LEITURA CONTEÚDO
                PdfPTable tableGLCL1 = new PdfPTable(4);
                tableGLCL1.WidthPercentage = 90f;

                /// Definição de largura das colunas das tabelas
                float[] tableGLCL1Size= new float[] {25, 42, 10, 23};
                tableGLCL1.SetWidths(tableGLCL1Size);

                /// Célula GRADE LEITURA CONTEÚDO TÍTULO - PERÍODO LEITURA
                PdfPCell cellGLCPLTL1 = new PdfPCell(new Phrase(dadoLeitura.PeriodoReferencia, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellGLCPLTL1.FixedHeight = 25f;
                cellGLCPLTL1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellGLCPLTL1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                tableGLCL1.AddCell(cellGLCPLTL1);

                /// Célula GRADE LEITURA CONTEÚDO TÍTULO - TÍTULO LIVRO
                PdfPCell cellGLCTL1 = new PdfPCell(new Phrase(dadoLeitura.TituloLivro, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellGLCTL1.FixedHeight = 25f;
                cellGLCTL1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellGLCTL1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                tableGLCL1.AddCell(cellGLCTL1);

                /// Célula GRADE LEITURA CONTEÚDO TÍTULO - REMIÇÃO
                PdfPCell cellGLCTRL1 = new PdfPCell(new Phrase(dadoLeitura.LeituraRemicao, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellGLCTRL1.FixedHeight = 25f;
                cellGLCTRL1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellGLCTRL1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                tableGLCL1.AddCell(cellGLCTRL1);

                /// Célula GRADE LEITURA CONTEÚDO TÍTULO - CONCEITO
                PdfPCell cellGLCTCL1 = new PdfPCell(new Phrase(dadoLeitura.Conceito, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellGLCTCL1.FixedHeight = 25f;
                cellGLCTCL1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellGLCTCL1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                tableGLCL1.AddCell(cellGLCTCL1);
                document.Add(tableGLCL1);
                #endregion
            }
            #endregion
            
            #endregion

            document.Close();
            
            byte[] bytes = zipFileMemoryStream.ToArray();
            MemoryStream inStream = new MemoryStream(bytes);

            return bytes;
        }
        #endregion
    }
}