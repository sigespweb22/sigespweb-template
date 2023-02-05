using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Helpers;
using Sigesp.WebUI.Extensions;
using Sigesp.Application.ViewModels.Requests;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using Microsoft.AspNetCore.Hosting;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using Sigesp.Application.ViewModels.Forms;
using Microsoft.EntityFrameworkCore.Internal;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels.Responses;
using Sigesp.Application.ViewModels.Relatorios;

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/alunos-leituras")]
    public class AlunoLeituraEndPoint : ApiController
    {
        private readonly IAlunoLeituraAppService _alunoLeituraManager;
        private readonly IAlunoLeituraCronogramaAppService _alunoLeituraCronogramaManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly ValidationResult _validationResult;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITenantRepository _tenantRepository;

        public AlunoLeituraEndPoint(IAlunoLeituraAppService alunoLeituraManager,
                                    IAlunoLeituraCronogramaAppService alunoLeituraCronogramaManager,
                                    SigespDbContext context,
                                    IMapper mapper,
                                    ValidationResult validationResult,
                                    IWebHostEnvironment webHostEnvironment,
                                    ITenantRepository tenantRepository)
        {
            _alunoLeituraManager = alunoLeituraManager;
            _alunoLeituraCronogramaManager = alunoLeituraCronogramaManager;
            _context = context;
            _mapper = mapper;
            _validationResult = validationResult;
            _webHostEnvironment = webHostEnvironment;
            _tenantRepository = tenantRepository;
        }

        #region Métodos privados
        // private byte[] CriarPDF(AlunoLeituraForFormModel dadosLeitura,
        //                         FormularioLeituraDicaEscrita dicaEscrita,
        //                         FormularioLeituraPerguntaGrupo perguntaGrupo,
        //                         Tenant dadosUnidadePrisional)
        // {
        //     var zipFileMemoryStream = new MemoryStream();
        //     Document document = new Document(PageSize.A4, 25, 25, 25, 15);
        //     document.SetMargins(15, 15, 35, 0);

        //     PdfWriter.GetInstance(document, zipFileMemoryStream).CloseStream = false;
        //     document.Open();

        //     #region PAGE PDF 1

        //     #region HEADER
        //     /// Instância da tabela HEADER
        //     PdfPTable tableHeader = new PdfPTable(3);
        //     tableHeader.WidthPercentage = 100f;

        //     /// Instâncias 3 células do HEADER
        //     PdfPCell cellHeaderLogoSc = new PdfPCell();
        //     PdfPCell cellHeaderTitulo = new PdfPCell();
        //     PdfPCell cellHeaderLogoProjetoLeitura = new PdfPCell();

        //     /// Definição de largura das colunas das tabelas
        //     float[] anchoDeColumnas= new float[] {15, 62, 23};
        //     tableHeader.SetWidths(anchoDeColumnas);

        //     /// Ajuste de Alinhamento das células
        //     cellHeaderTitulo.PaddingTop = 8;

        //     /// Ajuste de cores das células
        //     /// LOGO SC - BORDAS
        //     cellHeaderLogoSc.BorderWidthRight = 1;
        //     cellHeaderLogoSc.BorderColorRight = BaseColor.WHITE;

        //     /// HEADER TÍTULO - BORDAS
        //     cellHeaderTitulo.BorderWidthLeft = 1;
        //     cellHeaderTitulo.BorderColorLeft = BaseColor.WHITE;
        //     cellHeaderTitulo.BorderWidthRight = 1;
        //     cellHeaderTitulo.BorderColorRight = BaseColor.WHITE;

        //     /// LOGO PROJETO - BORDAS
        //     cellHeaderLogoProjetoLeitura.BorderWidthLeft = 1;
        //     cellHeaderLogoProjetoLeitura.BorderColorLeft = BaseColor.WHITE;

        //     //Path imagens HEADER
        //     string folderLogoSCName = "img\\logo-sc.png";
        //     string folderLogoProjetoLeituraName = "img\\logo-projeto-leitura.jpg";
        //     string webRootPath = _webHostEnvironment.WebRootPath;
        //     string pathLogoSCImg = System.IO.Path.Combine(webRootPath, folderLogoSCName);
        //     string pathLogoProjetoLeituraImg = System.IO.Path.Combine(webRootPath, folderLogoProjetoLeituraName);

        //     Image imageLogoSC = Image.GetInstance(pathLogoSCImg);
        //     Image imageLogoProjetoLeitura = Image.GetInstance(pathLogoProjetoLeituraImg);

        //     imageLogoSC.ScaleAbsolute(80, 90);
        //     imageLogoProjetoLeitura.ScaleAbsolute(121, 81);

        //     var headerTitulo1 = new Chunk("ESTADO DE SANTA CATARINA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
        //     var headerTitul2 = new Chunk("SECRETARIA DE ESTADO DA ADMINISTRAÇÃO PRISIONAL E SOCIOEDUCATIVA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
        //     var headerTitulo3 = new Chunk(dadosUnidadePrisional.Nome, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
        //     var headerTitulo4 = new Chunk("COORDENAÇÃO DE EDUCAÇÃO E PROMOÇÃO SOCIAL", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
        //     cellHeaderTitulo.AddElement(headerTitulo1);
        //     cellHeaderTitulo.AddElement(headerTitul2);
        //     cellHeaderTitulo.AddElement(headerTitulo3);
        //     cellHeaderTitulo.AddElement(headerTitulo4);

        //     cellHeaderLogoSc.AddElement(imageLogoSC);
        //     cellHeaderLogoProjetoLeitura.AddElement(imageLogoProjetoLeitura);

        //     tableHeader.AddCell(cellHeaderLogoSc);
        //     tableHeader.AddCell(cellHeaderTitulo);
        //     tableHeader.AddCell(cellHeaderLogoProjetoLeitura);

        //     document.Add(tableHeader);
        //     #endregion

        //     #region FORMULÁRIO DE LEITURA E CHAVE LEITURA
        //     /// Instância da tabela TEXTO FORMULÁRIO LEITURA
        //     PdfPTable tableFLeCH = new PdfPTable(2);
        //     tableFLeCH.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableFLeCHSize= new float[] {80, 20};
        //     tableFLeCH.SetWidths(tableFLeCHSize);

        //     /// Instâncias e célula do TEXTO FORMULÁRIO LEITURA e CHAVE LEITURA
        //     PdfPCell celltextoFL = new PdfPCell(new Phrase("FORMULÁRIO DE LEITURA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
        //     celltextoFL.FixedHeight = 30f;
        //     celltextoFL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //     celltextoFL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     celltextoFL.PaddingBottom = 7f;
        //     celltextoFL.PaddingLeft = 95f;

        //     tableFLeCH.AddCell(celltextoFL);

        //     PdfPCell cellCHL = new PdfPCell(new Phrase(dadosLeitura.ChaveLeitura.ToString(), FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
        //     cellCHL.FixedHeight = 30f;
        //     cellCHL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //     cellCHL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellCHL.PaddingBottom = 7f;

        //     tableFLeCH.AddCell(cellCHL);
        //     document.Add(tableFLeCH);
        //     #endregion         

        //     #region DADOS ALUNO E QRCODE
        //     /// Instância da tabela DADOS DO ALUNO
        //     PdfPTable tableDA = new PdfPTable(1);
        //     tableDA.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableDASize= new float[] {100};
        //     tableDA.SetWidths(tableDASize);

        //     /// Instância célula IPEN
        //     PdfPCell cellDA = new PdfPCell(new Phrase("DADOS DO ALUNO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
        //     cellDA.FixedHeight = 30f;
        //     cellDA.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellDA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellDA.PaddingBottom = 7f;
        //     cellDA.PaddingRight = 5f;

        //     tableDA.AddCell(cellDA);
        //     document.Add(tableDA);
        //     #endregion

        //     #region DADOS IPEN
        //     /// Instância da tabela IPEN
        //     PdfPTable tableIpen = new PdfPTable(2);
        //     tableIpen.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableIpenSize = new float[] {20, 80};
        //     tableIpen.SetWidths(tableIpenSize);

        //     /// Instância célula IPEN LABEL
        //     PdfPCell cellIpenLabel = new PdfPCell(new Phrase("IPEN: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellIpenLabel.FixedHeight = 15f;
        //     cellIpenLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellIpenLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellIpenLabel.PaddingTop = 1f;

        //     tableIpen.AddCell(cellIpenLabel);

        //     /// Instância célula IPEN NÚMERO
        //     PdfPCell cellIpenNumero = new PdfPCell(new Phrase(dadosLeitura.Ipen.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellIpenNumero.FixedHeight = 15f;
        //     cellIpenNumero.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellIpenNumero.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellIpenLabel.PaddingTop = 1f;

        //     tableIpen.AddCell(cellIpenNumero);
        //     document.Add(tableIpen);
        //     #endregion

        //     #region DADOS NOME
        //     /// Instância da tabela IPEN
        //     PdfPTable tableNome = new PdfPTable(2);
        //     tableNome.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableNomeSize = new float[] {20, 80};
        //     tableNome.SetWidths(tableNomeSize);

        //     /// Instância célula NOME LABEL
        //     PdfPCell cellNomeLabel = new PdfPCell(new Phrase("NOME: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellNomeLabel.FixedHeight = 15f;
        //     cellNomeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellNomeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellNomeLabel.PaddingTop = 1f;

        //     tableNome.AddCell(cellNomeLabel);

        //     /// Instância célula IPEN NÚMERO
        //     PdfPCell cellNome = new PdfPCell(new Phrase(dadosLeitura.Nome.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellNome.FixedHeight = 15f;
        //     cellNome.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellNome.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellNome.PaddingTop = 1f;

        //     tableNome.AddCell(cellNome);
        //     document.Add(tableNome);
        //     #endregion
            
        //     #region DADOS ESCOLARIDADE, GALERIA E CELA
        //     /// Instância da tabela ESCOLARIDADE, GALERIA E CELA
        //     PdfPTable tableEGC = new PdfPTable(6);
        //     tableEGC.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableEGCSize = new float[] {20, 32, 12, 12, 12, 12};
        //     tableEGC.SetWidths(tableEGCSize);

        //     /// Instância célula ESCOLARIDADE LABEL
        //     PdfPCell cellEscolaridadeLabel = new PdfPCell(new Phrase("ESCOLARIDADE: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellEscolaridadeLabel.FixedHeight = 15f;
        //     cellEscolaridadeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellEscolaridadeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellEscolaridadeLabel.PaddingTop = 1f;

        //     tableEGC.AddCell(cellEscolaridadeLabel);

        //     /// Instância célula ESCOLARIDADE
        //     PdfPCell cellEscolaridade = new PdfPCell(new Phrase(dadosLeitura.Escolaridade.Replace("_", " "), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellEscolaridade.FixedHeight = 15f;
        //     cellEscolaridade.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellEscolaridade.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellEscolaridade.PaddingTop = 1f;

        //     tableEGC.AddCell(cellEscolaridade);

        //     /// Instância célula GALERIA LABEL
        //     PdfPCell cellGaleriaLabel = new PdfPCell(new Phrase("GALERIA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellGaleriaLabel.FixedHeight = 15f;
        //     cellGaleriaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellGaleriaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellGaleriaLabel.PaddingTop = 1f;

        //     tableEGC.AddCell(cellGaleriaLabel);

        //     /// Instância célula GALERIA
        //     PdfPCell cellGaleria = new PdfPCell(new Phrase(dadosLeitura.Galeria, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellGaleria.FixedHeight = 15f;
        //     cellGaleria.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellGaleria.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellGaleria.PaddingTop = 1f;

        //     tableEGC.AddCell(cellGaleria);

        //     /// Instância célula CELA LABEL
        //     PdfPCell cellCelaLabel = new PdfPCell(new Phrase("CELA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellCelaLabel.FixedHeight = 15f;
        //     cellCelaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellCelaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellCelaLabel.PaddingTop = 1f;

        //     tableEGC.AddCell(cellCelaLabel);

        //     /// Instância célula GALERIA
        //     PdfPCell cellCela = new PdfPCell(new Phrase(dadosLeitura.Cela.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellCela.FixedHeight = 15f;
        //     cellCela.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellCela.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellCela.PaddingTop = 1f;

        //     tableEGC.AddCell(cellCela);

        //     document.Add(tableEGC);
        //     #endregion

        //     #region DADOS TÍTULO LIVRO
        //     /// Instância da tabela TÍTULO LIVRO
        //     PdfPTable tableTL = new PdfPTable(2);
        //     tableTL.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableTLSize = new float[] {20, 80};
        //     tableTL.SetWidths(tableTLSize);

        //     /// Instância célula TITULO LIVRO LABEL
        //     PdfPCell cellTLLabel = new PdfPCell(new Phrase("TÍTULO LIVRO: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellTLLabel.FixedHeight = 15f;
        //     cellTLLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellTLLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellTLLabel.PaddingTop = 1f;

        //     tableTL.AddCell(cellTLLabel);

        //     /// Instância célula TITULO LIVRO
        //     PdfPCell cellTL = new PdfPCell(new Phrase(dadosLeitura.LivroTitulo, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellTL.FixedHeight = 15f;
        //     cellTL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellTL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellTL.PaddingTop = 1f;

        //     tableTL.AddCell(cellTL);
        //     document.Add(tableTL);
        //     #endregion

        //     #region DADOS AUTOR
        //     /// Instância da tabela TÍTULO LIVRO
        //     PdfPTable tableAT = new PdfPTable(2);
        //     tableAT.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableATSize = new float[] {20, 80};
        //     tableAT.SetWidths(tableATSize);

        //     /// Instância célula AUTOR LABEL
        //     PdfPCell cellATLabel = new PdfPCell(new Phrase("AUTOR: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellATLabel.FixedHeight = 15f;
        //     cellATLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellATLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellATLabel.PaddingTop = 1f;

        //     tableAT.AddCell(cellATLabel);

        //     /// Instância célula AUTOR
        //     PdfPCell cellAT = new PdfPCell(new Phrase(dadosLeitura.LivroAutorNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellAT.FixedHeight = 15f;
        //     cellAT.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellAT.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellAT.PaddingTop = 1f;

        //     tableAT.AddCell(cellAT);
        //     document.Add(tableAT);
        //     #endregion

        //     #region DADOS PERÍODO REFERÊNCIA E ANO REFERÊNCIA
        //     /// Instância da tabela PERÍODO REFERÊNCIA E ANO REFERÊNCIA
        //     PdfPTable tablePReAR = new PdfPTable(4);
        //     tablePReAR.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tablePReARSize = new float[] {20, 30, 25, 25};
        //     tablePReAR.SetWidths(tablePReARSize);

        //     /// Instância célula PERÍODO REFERÊNCIA LABEL
        //     PdfPCell cellPRLabel = new PdfPCell(new Phrase("PERÍODO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellPRLabel.FixedHeight = 15f;
        //     cellPRLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellPRLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellPRLabel.PaddingTop = 1f;

        //     tablePReAR.AddCell(cellPRLabel);

        //     /// Instância célula PERÍODO REFERÊNCIA
        //     PdfPCell cellPR = new PdfPCell(new Phrase(dadosLeitura.AlunoLeituraCronogramaNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellPR.FixedHeight = 15f;
        //     cellPR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellPR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellPR.PaddingTop = 1f;

        //     tablePReAR.AddCell(cellPR);

        //     /// Instância célula ANO REFERÊNCIA LABEL
        //     PdfPCell cellARLabel = new PdfPCell(new Phrase("ANO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //     cellARLabel.FixedHeight = 15f;
        //     cellARLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellARLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellARLabel.PaddingTop = 1f;

        //     tablePReAR.AddCell(cellARLabel);

        //     /// Instância célula ANO REFERÊNCIA
        //     PdfPCell cellAR = new PdfPCell(new Phrase(dadosLeitura.AlunoLeituraCronogramaAnoReferencia, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //     cellAR.FixedHeight = 15f;
        //     cellAR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellAR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellAR.PaddingTop = 1f;

        //     tablePReAR.AddCell(cellAR);
        //     document.Add(tablePReAR);
        //     #endregion

        //     #region DICA DE ESCRITA
        //     /// Instância da tabela DICA DE ESCRITA
        //     PdfPTable tableDE = new PdfPTable(2);
        //     tableDE.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableDESize = new float[] {27, 73   };
        //     tableDE.SetWidths(tableDESize);

        //     /// Instância célula DICA DE ESCRITA LABEL
        //     PdfPCell cellDELabel = new PdfPCell(new Phrase("DICA DE ESCRITA: ", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
        //     cellDELabel.FixedHeight = 30f;
        //     cellDELabel.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //     cellDELabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //     cellDELabel.BackgroundColor = BaseColor.LIGHT_GRAY;

        //     /// Ajuste de Alinhamento
        //     cellDELabel.PaddingBottom = 7f;
        //     cellDELabel.PaddingRight = 5f;

        //     tableDE.AddCell(cellDELabel);

        //     /// Instância célula DICA DE ESCRITA LABEL
        //     PdfPCell cellDE = new PdfPCell(new Phrase(dicaEscrita.Nome, FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
        //     cellDE.FixedHeight = 30f;
        //     cellDE.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //     cellDE.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //     cellDE.BackgroundColor = BaseColor.LIGHT_GRAY;

        //     /// Ajuste de Alinhamento
        //     cellDE.PaddingBottom = 7f;
        //     cellDE.PaddingLeft = 10f;

        //     tableDE.AddCell(cellDE);

        //     document.Add(tableDE);
        //     #endregion

        //     #region DICA DE ESCRITA LINHAS
        //     /// Instância da tabela DICA DE ESCRITA LINHAS
        //     PdfPTable tableDEL = new PdfPTable(1);
        //     tableDEL.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableDELSize = new float[] {100};
        //     tableDEL.SetWidths(tableDELSize);

        //     var dicasOrdenadas = dicaEscrita.FormularioLeituraDicaEscritaDicas.OrderBy(x => x.Ordem).ToList();
        //     foreach (var tmp in dicasOrdenadas.ToList())
        //     {
        //         /// Instância célula DICA DE ESCRITA LINHA 1
        //         PdfPCell cellDEL = new PdfPCell(new Phrase(tmp.Dica.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //         cellDEL.FixedHeight = 15f;
        //         cellDEL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //         cellDEL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //         cellDEL.BackgroundColor = BaseColor.LIGHT_GRAY;

        //         /// Ajuste de Alinhamento
        //         cellDEL.PaddingBottom = 3f;

        //         tableDEL.AddCell(cellDEL);
        //     }

        //     document.Add(tableDEL);
        //     #endregion

        //     #region DADOS DA LEITURA
        //     /// Instância da tabela DADOS DA LEITURA
        //     PdfPTable tableDL = new PdfPTable(1);
        //     tableDL.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableDLSize= new float[] {100};
        //     tableDL.SetWidths(tableDLSize);

        //     /// Instância célula IPEN
        //     PdfPCell cellDL = new PdfPCell(new Phrase("DADOS DA LEITURA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
        //     cellDL.FixedHeight = 30f;
        //     cellDL.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellDL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellDL.PaddingBottom = 7f;
        //     cellDL.PaddingRight = 5f;

        //     tableDL.AddCell(cellDL);
        //     document.Add(tableDL);
        //     #endregion

        //     #region DADOS PERGUNTAS 1 a 5
        //     /// Instância da tabela PERGUNTA 1 
        //     PdfPTable tablePGTA1 = new PdfPTable(1);
        //     tablePGTA1.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tablePGTA1Size = new float[] {100};
        //     tablePGTA1.SetWidths(tablePGTA1Size);

        //     var perguntasOrdenadas = perguntaGrupo.FormularioLeituraPerguntas.OrderBy(x => x.Ordem);
        //     foreach (var item in perguntasOrdenadas.Select((value, i) => new { i, value }))
        //     {
                

        //         PdfPCell cellPGTA = new PdfPCell(new Phrase(item.value.Ordem + ". " + item.value.Pergunta, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
        //         cellPGTA.FixedHeight = 15f;
        //         cellPGTA.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
        //         cellPGTA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //         cellPGTA.BackgroundColor = BaseColor.LIGHT_GRAY;

        //         /// Ajuste de Alinhamento
        //         cellPGTA.PaddingTop = 1f;

        //         tablePGTA1.AddCell(cellPGTA);

        //         /// Instância célula RESPOSTA 1
        //         PdfPCell cellRPSTA = new PdfPCell();
        //         cellRPSTA.FixedHeight = 15f;

        //         if (item.i == (perguntasOrdenadas.Count() - 1) ||
        //             item.i == (perguntasOrdenadas.Count() - 2))
        //         {
        //             tablePGTA1.AddCell(cellRPSTA);
        //             tablePGTA1.AddCell(cellRPSTA);
        //             tablePGTA1.AddCell(cellRPSTA);    
        //         }
        //         else 
        //         {
        //             tablePGTA1.AddCell(cellRPSTA);
        //             tablePGTA1.AddCell(cellRPSTA);
        //             tablePGTA1.AddCell(cellRPSTA);
        //             tablePGTA1.AddCell(cellRPSTA);
        //             tablePGTA1.AddCell(cellRPSTA);
        //         }
                
                
        //     }
        //     document.Add(tablePGTA1);
        //     #endregion
            
        //     #endregion

        //     #region PAGE PDF 2

        //     #region DADOS DA RESENHA
        //     /// Instância da tabela DADOS DA RESENHA
        //     PdfPTable tableRSHA = new PdfPTable(1);
        //     tableRSHA.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableRSHASize= new float[] {100};
        //     tableRSHA.SetWidths(tableRSHASize);

        //     /// Instância célula DADOS DA RESENHA
        //     PdfPCell cellRSHA = new PdfPCell(new Phrase("RESENHA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
        //     cellRSHA.FixedHeight = 45f;
        //     cellRSHA.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //     cellRSHA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellRSHA.PaddingBottom = 7f;
        //     cellRSHA.PaddingRight = 5f;

        //     tableRSHA.AddCell(cellRSHA);

        //     /// Instância célula DADOS DA RESENHA DESCRIÇÃO
        //     PdfPCell cellRSHADescricao = new PdfPCell(new Phrase("Faça uma resenha de no mínimo 20 linhas e no máximo 40 linhas sobre o livro que você leu, contando os fatos mais importantes.", FontFactory.GetFont("Roboto", 8, BaseColor.BLACK)));
        //     cellRSHADescricao.FixedHeight = 25f;
        //     cellRSHADescricao.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //     cellRSHADescricao.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellRSHADescricao.PaddingBottom = 7f;
        //     cellRSHADescricao.PaddingRight = 5f;

        //     tableRSHA.AddCell(cellRSHADescricao);

        //     /// Instância célula DADOS DA RESENHA RESPOSTA
        //     var cellRSHATL = 42;
        //     for (var i = 1; i < cellRSHATL - 1; i++)
        //     {
        //         PdfPCell cellRSHAL = new PdfPCell(new Phrase(i.ToString(), FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
        //         cellRSHAL.FixedHeight = 16f;
        //         cellRSHAL.PaddingBottom = 1f;
        //         cellRSHAL.PaddingLeft = 2f;
                
        //         tableRSHA.AddCell(cellRSHAL);
        //     }
            
        //     document.Add(tableRSHA);
        //     #endregion

        //     #region DADOS ASSINATURA DO ALUNO
        //     /// Instância da tabela DADOS ASSINATURA DO ALUNO
        //     PdfPTable tableDAAL = new PdfPTable(1);
        //     tableDAAL.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableDAALSize= new float[] {100};
        //     tableDAAL.SetWidths(tableDAALSize);

        //     /// Instância célula IPEN
        //     PdfPCell cellDAAL = new PdfPCell(new Phrase("ASSINATURA DO ALUNO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.GRAY)));
        //     cellDAAL.FixedHeight = 55f;
        //     cellDAAL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //     cellDAAL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //     cellDAAL.BackgroundColor = BaseColor.LIGHT_GRAY;

        //     /// Ajuste de Alinhamento
        //     cellDAAL.PaddingBottom = 7f;
        //     cellDAAL.PaddingRight = 5f;

        //     tableDAAL.AddCell(cellDAAL);
        //     document.Add(tableDAAL);
        //     #endregion

        //     #region DADOS DATA DOCUMENTO
        //     /// Instância da tabela DATA DOCUMENTO
        //     PdfPTable tableDDD = new PdfPTable(1);
        //     tableDDD.WidthPercentage = 100f;

        //     /// Definição de largura das colunas das tabelas
        //     float[] tableDDDSize= new float[] {100};
        //     tableDDD.SetWidths(tableDDDSize);

        //     /// Instância célula DATA DOCUMENTO
        //     var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        //     PdfPCell cellDDD = new PdfPCell(new Phrase("DOCUMENTO GERADO EM: " + dateTime, FontFactory.GetFont("Roboto", 9, Font.BOLDITALIC, BaseColor.LIGHT_GRAY)));
        //     cellDDD.FixedHeight = 20f;
        //     cellDDD.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //     cellDDD.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

        //     /// Ajuste de Alinhamento
        //     cellDDD.PaddingBottom = 7f;
        //     cellDDD.PaddingRight = 5f;

        //     tableDDD.AddCell(cellDDD);
        //     document.Add(tableDDD);
        //     #endregion
            
        //     #endregion

        //     document.Close();

        //     byte[] bytes = zipFileMemoryStream.ToArray();
        //     MemoryStream inStream = new MemoryStream(bytes);

        //     return bytes;
        // }
        private byte[] CriarPDF(FormularioLeituraFormModel dadosLeitura)
        {
            var zipFileMemoryStream = new MemoryStream();
            Document document = new Document(PageSize.A4, 25, 25, 25, 15);
            document.SetMargins(15, 15, 35, 0);

            PdfWriter.GetInstance(document, zipFileMemoryStream).CloseStream = false;
            document.Open();

            var leiturasOrdenandasPorCela = dadosLeitura.DadosLeituras.OrderBy(x => x.Cela);
            foreach (var dadoLeitura in leiturasOrdenandasPorCela.ToList())
            {
                #region Método comentado para criar capa para cada cela - pendente de implementação
                // var indiceAtual = Convert.ToInt32(leiturasOrdenandasPorCela.IndexOf(dadoLeitura));
                // var indicePrev = Convert.ToInt32(leiturasOrdenandasPorCela.IndexOf(dadoLeitura) - 1);
                // var indiceNext = Convert.ToInt32(leiturasOrdenandasPorCela.IndexOf(dadoLeitura) + 1);

                // var celaAtual = 0;
                // var celaPrev = 0;
                // var celaNext = 0;

                // if (indiceAtual != -1)
                // {
                //     celaAtual = leiturasOrdenandasPorCela.ToList()[indiceAtual].Cela;                    
                // } else if (indicePrev != -1) {
                //     celaPrev = leiturasOrdenandasPorCela.ToList()[indicePrev].Cela;                    
                // } else if (indiceNext != -1) {
                //     celaNext = leiturasOrdenandasPorCela.ToList()[indiceNext].Cela;
                // }
                
                // if (leiturasOrdenandasPorCela.IndexOf(dadoLeitura) == 0)
                // {
                //     /// Instância da tabela Capa
                //     PdfPTable tableCapa = new PdfPTable(1);
                //     tableCapa.WidthPercentage = 100f;
                //     tableCapa.DefaultCell.FixedHeight = 100f;
                //     tableCapa.DefaultCell.MinimumHeight = 100f;

                //     tableCapa.KeepTogether = false;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableCapaSize= new float[] {100};
                //     tableCapa.SetWidths(tableCapaSize);

                //     /// Instâncias e célula do TEXTO CAPA
                //     PdfPCell cellCapa = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa.FixedHeight = 100;
                //     cellCapa.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa1 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa1.FixedHeight = 100;
                //     cellCapa1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa2 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa2.FixedHeight = 100;
                //     cellCapa2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa3 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa3.FixedHeight = 100;
                //     cellCapa3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa4 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa4.FixedHeight = 100;
                //     cellCapa4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa4.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa5 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa5.FixedHeight = 100;
                //     cellCapa5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa5.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa6 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa6.FixedHeight = 100;
                //     cellCapa6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa7 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa7.FixedHeight = 100;
                //     cellCapa7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     // cellCapa.PaddingTop = 50;

                //     tableCapa.AddCell(cellCapa);
                //     tableCapa.AddCell(cellCapa1);
                //     tableCapa.AddCell(cellCapa2);
                //     tableCapa.AddCell(cellCapa3);
                //     tableCapa.AddCell(cellCapa4);
                //     tableCapa.AddCell(cellCapa5);
                //     tableCapa.AddCell(cellCapa6);
                //     tableCapa.AddCell(cellCapa7);
                //     document.Add(tableCapa);
                // }
                // else if (celaAtual != celaPrev && 
                //          celaAtual == celaNext)
                // {
                //     /// Instância da tabela Capa
                //     PdfPTable tableCapa = new PdfPTable(1);
                //     tableCapa.WidthPercentage = 100f;
                //     tableCapa.DefaultCell.FixedHeight = 100f;
                //     tableCapa.DefaultCell.MinimumHeight = 100f;

                //     tableCapa.KeepTogether = false;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableCapaSize= new float[] {100};
                //     tableCapa.SetWidths(tableCapaSize);

                //     /// Instâncias e célula do TEXTO CAPA
                //     PdfPCell cellCapa = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa.FixedHeight = 100;
                //     cellCapa.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa1 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa1.FixedHeight = 100;
                //     cellCapa1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa2 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa2.FixedHeight = 100;
                //     cellCapa2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa3 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa3.FixedHeight = 100;
                //     cellCapa3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa4 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa4.FixedHeight = 100;
                //     cellCapa4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa4.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa5 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa5.FixedHeight = 100;
                //     cellCapa5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa5.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa6 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa6.FixedHeight = 100;
                //     cellCapa6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     PdfPCell cellCapa7 = new PdfPCell(new Phrase("LEITURAS CELA "+ dadoLeitura.Cela, FontFactory.GetFont("Roboto", 50, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCapa7.FixedHeight = 100;
                //     cellCapa7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCapa7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     // cellCapa.PaddingTop = 50;

                //     tableCapa.AddCell(cellCapa);
                //     tableCapa.AddCell(cellCapa1);
                //     tableCapa.AddCell(cellCapa2);
                //     tableCapa.AddCell(cellCapa3);
                //     tableCapa.AddCell(cellCapa4);
                //     tableCapa.AddCell(cellCapa5);
                //     tableCapa.AddCell(cellCapa6);
                //     tableCapa.AddCell(cellCapa7);
                //     document.Add(tableCapa);
                // }
                // else
                // {
                //     #region PAGE PDF 1

                //     #region HEADER
                //     /// Instância da tabela HEADER
                //     PdfPTable tableHeader = new PdfPTable(3);
                //     tableHeader.WidthPercentage = 100f;

                //     /// Instâncias 3 células do HEADER
                //     PdfPCell cellHeaderLogoSc = new PdfPCell();
                //     PdfPCell cellHeaderTitulo = new PdfPCell();
                //     PdfPCell cellHeaderLogoProjetoLeitura = new PdfPCell();

                //     /// Definição de largura das colunas das tabelas
                //     float[] anchoDeColumnas= new float[] {15, 62, 23};
                //     tableHeader.SetWidths(anchoDeColumnas);

                //     /// Ajuste de Alinhamento das células
                //     cellHeaderTitulo.PaddingTop = 8;

                //     /// Ajuste de cores das células
                //     /// LOGO SC - BORDAS
                //     cellHeaderLogoSc.BorderWidthRight = 1;
                //     cellHeaderLogoSc.BorderColorRight = BaseColor.WHITE;

                //     /// HEADER TÍTULO - BORDAS
                //     cellHeaderTitulo.BorderWidthLeft = 1;
                //     cellHeaderTitulo.BorderColorLeft = BaseColor.WHITE;
                //     cellHeaderTitulo.BorderWidthRight = 1;
                //     cellHeaderTitulo.BorderColorRight = BaseColor.WHITE;

                //     /// LOGO PROJETO - BORDAS
                //     cellHeaderLogoProjetoLeitura.BorderWidthLeft = 1;
                //     cellHeaderLogoProjetoLeitura.BorderColorLeft = BaseColor.WHITE;

                //     //Path imagens HEADER
                //     string folderLogoSCName = "img\\logo-sc.png";
                //     string folderLogoProjetoLeituraName = "img\\logo-projeto-leitura.jpg";
                //     string webRootPath = _webHostEnvironment.WebRootPath;
                //     string pathLogoSCImg = System.IO.Path.Combine(webRootPath, folderLogoSCName);
                //     string pathLogoProjetoLeituraImg = System.IO.Path.Combine(webRootPath, folderLogoProjetoLeituraName);

                //     Image imageLogoSC = Image.GetInstance(pathLogoSCImg);
                //     Image imageLogoProjetoLeitura = Image.GetInstance(pathLogoProjetoLeituraImg);

                //     imageLogoSC.ScaleAbsolute(80, 90);
                //     imageLogoProjetoLeitura.ScaleAbsolute(121, 81);

                //     var headerTitulo1 = new Chunk("ESTADO DE SANTA CATARINA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                //     var headerTitul2 = new Chunk("SECRETARIA DE ESTADO DA ADMINISTRAÇÃO PRISIONAL E SOCIOEDUCATIVA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                //     var headerTitulo3 = new Chunk(dadosLeitura.DadosUnidadePrisional.Nome, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                //     var headerTitulo4 = new Chunk("COORDENAÇÃO DE EDUCAÇÃO E PROMOÇÃO SOCIAL", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                //     cellHeaderTitulo.AddElement(headerTitulo1);
                //     cellHeaderTitulo.AddElement(headerTitul2);
                //     cellHeaderTitulo.AddElement(headerTitulo3);
                //     cellHeaderTitulo.AddElement(headerTitulo4);

                //     cellHeaderLogoSc.AddElement(imageLogoSC);
                //     cellHeaderLogoProjetoLeitura.AddElement(imageLogoProjetoLeitura);

                //     tableHeader.AddCell(cellHeaderLogoSc);
                //     tableHeader.AddCell(cellHeaderTitulo);
                //     tableHeader.AddCell(cellHeaderLogoProjetoLeitura);

                //     document.Add(tableHeader);
                //     #endregion

                //     #region FORMULÁRIO DE LEITURA E CHAVE LEITURA
                //     /// Instância da tabela TEXTO FORMULÁRIO LEITURA
                //     PdfPTable tableFLeCH = new PdfPTable(2);
                //     tableFLeCH.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableFLeCHSize= new float[] {80, 20};
                //     tableFLeCH.SetWidths(tableFLeCHSize);

                //     /// Instâncias e célula do TEXTO FORMULÁRIO LEITURA e CHAVE LEITURA
                //     PdfPCell celltextoFL = new PdfPCell(new Phrase("FORMULÁRIO DE LEITURA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                //     celltextoFL.FixedHeight = 30f;
                //     celltextoFL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     celltextoFL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     celltextoFL.PaddingBottom = 7f;
                //     celltextoFL.PaddingLeft = 95f;

                //     tableFLeCH.AddCell(celltextoFL);

                //     PdfPCell cellCHL = new PdfPCell(new Phrase(dadoLeitura.ChaveLeitura.ToString(), FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellCHL.FixedHeight = 30f;
                //     cellCHL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellCHL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellCHL.PaddingBottom = 7f;

                //     tableFLeCH.AddCell(cellCHL);
                //     document.Add(tableFLeCH);
                //     #endregion         

                //     #region DADOS ALUNO E QRCODE
                //     /// Instância da tabela DADOS DO ALUNO
                //     PdfPTable tableDA = new PdfPTable(1);
                //     tableDA.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableDASize= new float[] {100};
                //     tableDA.SetWidths(tableDASize);

                //     /// Instância célula IPEN
                //     PdfPCell cellDA = new PdfPCell(new Phrase("DADOS DO ALUNO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellDA.FixedHeight = 30f;
                //     cellDA.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellDA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellDA.PaddingBottom = 7f;
                //     cellDA.PaddingRight = 5f;

                //     tableDA.AddCell(cellDA);
                //     document.Add(tableDA);
                //     #endregion

                //     #region DADOS IPEN
                //     /// Instância da tabela IPEN
                //     PdfPTable tableIpen = new PdfPTable(2);
                //     tableIpen.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableIpenSize = new float[] {20, 80};
                //     tableIpen.SetWidths(tableIpenSize);

                //     /// Instância célula IPEN LABEL
                //     PdfPCell cellIpenLabel = new PdfPCell(new Phrase("IPEN: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellIpenLabel.FixedHeight = 15f;
                //     cellIpenLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellIpenLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellIpenLabel.PaddingTop = 1f;

                //     tableIpen.AddCell(cellIpenLabel);

                //     /// Instância célula IPEN NÚMERO
                //     PdfPCell cellIpenNumero = new PdfPCell(new Phrase(dadoLeitura.Ipen.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellIpenNumero.FixedHeight = 15f;
                //     cellIpenNumero.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellIpenNumero.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellIpenLabel.PaddingTop = 1f;

                //     tableIpen.AddCell(cellIpenNumero);
                //     document.Add(tableIpen);
                //     #endregion

                //     #region DADOS NOME
                //     /// Instância da tabela IPEN
                //     PdfPTable tableNome = new PdfPTable(2);
                //     tableNome.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableNomeSize = new float[] {20, 80};
                //     tableNome.SetWidths(tableNomeSize);

                //     /// Instância célula NOME LABEL
                //     PdfPCell cellNomeLabel = new PdfPCell(new Phrase("NOME: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellNomeLabel.FixedHeight = 15f;
                //     cellNomeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellNomeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellNomeLabel.PaddingTop = 1f;

                //     tableNome.AddCell(cellNomeLabel);

                //     /// Instância célula IPEN NÚMERO
                //     PdfPCell cellNome = new PdfPCell(new Phrase(dadoLeitura.Nome.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellNome.FixedHeight = 15f;
                //     cellNome.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellNome.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellNome.PaddingTop = 1f;

                //     tableNome.AddCell(cellNome);
                //     document.Add(tableNome);
                //     #endregion
                    
                //     #region DADOS ESCOLARIDADE, GALERIA E CELA
                //     /// Instância da tabela ESCOLARIDADE, GALERIA E CELA
                //     PdfPTable tableEGC = new PdfPTable(6);
                //     tableEGC.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableEGCSize = new float[] {20, 32, 12, 12, 12, 12};
                //     tableEGC.SetWidths(tableEGCSize);

                //     /// Instância célula ESCOLARIDADE LABEL
                //     PdfPCell cellEscolaridadeLabel = new PdfPCell(new Phrase("ESCOLARIDADE: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellEscolaridadeLabel.FixedHeight = 15f;
                //     cellEscolaridadeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellEscolaridadeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellEscolaridadeLabel.PaddingTop = 1f;

                //     tableEGC.AddCell(cellEscolaridadeLabel);

                //     /// Instância célula ESCOLARIDADE
                //     PdfPCell cellEscolaridade = new PdfPCell(new Phrase(dadoLeitura.Escolaridade.Replace("_", " "), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellEscolaridade.FixedHeight = 15f;
                //     cellEscolaridade.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellEscolaridade.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellEscolaridade.PaddingTop = 1f;

                //     tableEGC.AddCell(cellEscolaridade);

                //     /// Instância célula GALERIA LABEL
                //     PdfPCell cellGaleriaLabel = new PdfPCell(new Phrase("GALERIA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellGaleriaLabel.FixedHeight = 15f;
                //     cellGaleriaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellGaleriaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellGaleriaLabel.PaddingTop = 1f;

                //     tableEGC.AddCell(cellGaleriaLabel);

                //     /// Instância célula GALERIA
                //     PdfPCell cellGaleria = new PdfPCell(new Phrase(dadoLeitura.Galeria, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellGaleria.FixedHeight = 15f;
                //     cellGaleria.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellGaleria.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellGaleria.PaddingTop = 1f;

                //     tableEGC.AddCell(cellGaleria);

                //     /// Instância célula CELA LABEL
                //     PdfPCell cellCelaLabel = new PdfPCell(new Phrase("CELA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellCelaLabel.FixedHeight = 15f;
                //     cellCelaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellCelaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellCelaLabel.PaddingTop = 1f;

                //     tableEGC.AddCell(cellCelaLabel);

                //     /// Instância célula GALERIA
                //     PdfPCell cellCela = new PdfPCell(new Phrase(dadoLeitura.Cela.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellCela.FixedHeight = 15f;
                //     cellCela.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellCela.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellCela.PaddingTop = 1f;

                //     tableEGC.AddCell(cellCela);

                //     document.Add(tableEGC);
                //     #endregion

                //     #region DADOS TÍTULO LIVRO
                //     /// Instância da tabela TÍTULO LIVRO
                //     PdfPTable tableTL = new PdfPTable(2);
                //     tableTL.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableTLSize = new float[] {20, 80};
                //     tableTL.SetWidths(tableTLSize);

                //     /// Instância célula TITULO LIVRO LABEL
                //     PdfPCell cellTLLabel = new PdfPCell(new Phrase("TÍTULO LIVRO: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellTLLabel.FixedHeight = 15f;
                //     cellTLLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellTLLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellTLLabel.PaddingTop = 1f;

                //     tableTL.AddCell(cellTLLabel);

                //     /// Instância célula TITULO LIVRO
                //     PdfPCell cellTL = new PdfPCell(new Phrase(dadoLeitura.LivroTitulo, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellTL.FixedHeight = 15f;
                //     cellTL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellTL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellTL.PaddingTop = 1f;

                //     tableTL.AddCell(cellTL);
                //     document.Add(tableTL);
                //     #endregion

                //     #region DADOS AUTOR
                //     /// Instância da tabela TÍTULO LIVRO
                //     PdfPTable tableAT = new PdfPTable(2);
                //     tableAT.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableATSize = new float[] {20, 80};
                //     tableAT.SetWidths(tableATSize);

                //     /// Instância célula AUTOR LABEL
                //     PdfPCell cellATLabel = new PdfPCell(new Phrase("AUTOR: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellATLabel.FixedHeight = 15f;
                //     cellATLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellATLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellATLabel.PaddingTop = 1f;

                //     tableAT.AddCell(cellATLabel);

                //     /// Instância célula AUTOR
                //     PdfPCell cellAT = new PdfPCell(new Phrase(dadoLeitura.LivroAutorNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellAT.FixedHeight = 15f;
                //     cellAT.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellAT.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellAT.PaddingTop = 1f;

                //     tableAT.AddCell(cellAT);
                //     document.Add(tableAT);
                //     #endregion

                //     #region DADOS PERÍODO REFERÊNCIA E ANO REFERÊNCIA
                //     /// Instância da tabela PERÍODO REFERÊNCIA E ANO REFERÊNCIA
                //     PdfPTable tablePReAR = new PdfPTable(4);
                //     tablePReAR.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tablePReARSize = new float[] {20, 30, 25, 25};
                //     tablePReAR.SetWidths(tablePReARSize);

                //     /// Instância célula PERÍODO REFERÊNCIA LABEL
                //     PdfPCell cellPRLabel = new PdfPCell(new Phrase("PERÍODO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellPRLabel.FixedHeight = 15f;
                //     cellPRLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellPRLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellPRLabel.PaddingTop = 1f;

                //     tablePReAR.AddCell(cellPRLabel);

                //     /// Instância célula PERÍODO REFERÊNCIA
                //     PdfPCell cellPR = new PdfPCell(new Phrase(dadoLeitura.AlunoLeituraCronogramaNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellPR.FixedHeight = 15f;
                //     cellPR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellPR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellPR.PaddingTop = 1f;

                //     tablePReAR.AddCell(cellPR);

                //     /// Instância célula ANO REFERÊNCIA LABEL
                //     PdfPCell cellARLabel = new PdfPCell(new Phrase("ANO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //     cellARLabel.FixedHeight = 15f;
                //     cellARLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellARLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellARLabel.PaddingTop = 1f;

                //     tablePReAR.AddCell(cellARLabel);

                //     /// Instância célula ANO REFERÊNCIA
                //     PdfPCell cellAR = new PdfPCell(new Phrase(dadoLeitura.AlunoLeituraCronogramaAnoReferencia, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //     cellAR.FixedHeight = 15f;
                //     cellAR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellAR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellAR.PaddingTop = 1f;

                //     tablePReAR.AddCell(cellAR);
                //     document.Add(tablePReAR);
                //     #endregion

                //     #region DICA DE ESCRITA
                //     /// Instância da tabela DICA DE ESCRITA
                //     PdfPTable tableDE = new PdfPTable(2);
                //     tableDE.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableDESize = new float[] {27, 73   };
                //     tableDE.SetWidths(tableDESize);

                //     /// Instância célula DICA DE ESCRITA LABEL
                //     PdfPCell cellDELabel = new PdfPCell(new Phrase("DICA DE ESCRITA: ", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellDELabel.FixedHeight = 30f;
                //     cellDELabel.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellDELabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                //     cellDELabel.BackgroundColor = BaseColor.LIGHT_GRAY;

                //     /// Ajuste de Alinhamento
                //     cellDELabel.PaddingBottom = 7f;
                //     cellDELabel.PaddingRight = 5f;

                //     tableDE.AddCell(cellDELabel);

                //     /// Instância célula DICA DE ESCRITA LABEL
                //     PdfPCell cellDE = new PdfPCell(new Phrase(dadosLeitura.FormularioLeituraDicaEscrita.Nome, FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellDE.FixedHeight = 30f;
                //     cellDE.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //     cellDE.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                //     cellDE.BackgroundColor = BaseColor.LIGHT_GRAY;

                //     /// Ajuste de Alinhamento
                //     cellDE.PaddingBottom = 7f;
                //     cellDE.PaddingLeft = 10f;

                //     tableDE.AddCell(cellDE);

                //     document.Add(tableDE);
                //     #endregion

                //     #region DICA DE ESCRITA LINHAS
                //     /// Instância da tabela DICA DE ESCRITA LINHAS
                //     PdfPTable tableDEL = new PdfPTable(1);
                //     tableDEL.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableDELSize = new float[] {100};
                //     tableDEL.SetWidths(tableDELSize);

                //     var dicasOrdenadas = dadosLeitura.FormularioLeituraDicaEscrita.FormularioLeituraDicaEscritaDicas.OrderBy(x => x.Ordem).ToList();
                //     foreach (var tmp in dicasOrdenadas.ToList())
                //     {
                //         /// Instância célula DICA DE ESCRITA LINHA 1
                //         PdfPCell cellDEL = new PdfPCell(new Phrase(tmp.Dica.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //         cellDEL.FixedHeight = 15f;
                //         cellDEL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //         cellDEL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                //         cellDEL.BackgroundColor = BaseColor.LIGHT_GRAY;

                //         /// Ajuste de Alinhamento
                //         cellDEL.PaddingBottom = 3f;

                //         tableDEL.AddCell(cellDEL);
                //     }

                //     document.Add(tableDEL);
                //     #endregion

                //     #region DADOS DA LEITURA
                //     /// Instância da tabela DADOS DA LEITURA
                //     PdfPTable tableDL = new PdfPTable(1);
                //     tableDL.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableDLSize= new float[] {100};
                //     tableDL.SetWidths(tableDLSize);

                //     /// Instância célula IPEN
                //     PdfPCell cellDL = new PdfPCell(new Phrase("DADOS DA LEITURA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellDL.FixedHeight = 30f;
                //     cellDL.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellDL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellDL.PaddingBottom = 7f;
                //     cellDL.PaddingRight = 5f;

                //     tableDL.AddCell(cellDL);
                //     document.Add(tableDL);
                //     #endregion

                //     #region DADOS PERGUNTAS 1 a 5
                //     /// Instância da tabela PERGUNTA 1 
                //     PdfPTable tablePGTA1 = new PdfPTable(1);
                //     tablePGTA1.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tablePGTA1Size = new float[] {100};
                //     tablePGTA1.SetWidths(tablePGTA1Size);

                //     var perguntasOrdenadas = dadosLeitura.FormularioLeituraPerguntaGrupo.FormularioLeituraPerguntas.OrderBy(x => x.Ordem);
                //     foreach (var item in perguntasOrdenadas.Select((value, i) => new { i, value }))
                //     {
                        

                //         PdfPCell cellPGTA = new PdfPCell(new Phrase(item.value.Ordem + ". " + item.value.Pergunta, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                //         cellPGTA.FixedHeight = 15f;
                //         cellPGTA.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                //         cellPGTA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                //         cellPGTA.BackgroundColor = BaseColor.LIGHT_GRAY;

                //         /// Ajuste de Alinhamento
                //         cellPGTA.PaddingTop = 1f;

                //         tablePGTA1.AddCell(cellPGTA);

                //         /// Instância célula RESPOSTA 1
                //         PdfPCell cellRPSTA = new PdfPCell();
                //         cellRPSTA.FixedHeight = 15f;

                //         if (item.i == (perguntasOrdenadas.Count() - 1) ||
                //             item.i == (perguntasOrdenadas.Count() - 2))
                //         {
                //             tablePGTA1.AddCell(cellRPSTA);
                //             tablePGTA1.AddCell(cellRPSTA);
                //             tablePGTA1.AddCell(cellRPSTA);    
                //         }
                //         else 
                //         {
                //             tablePGTA1.AddCell(cellRPSTA);
                //             tablePGTA1.AddCell(cellRPSTA);
                //             tablePGTA1.AddCell(cellRPSTA);
                //             tablePGTA1.AddCell(cellRPSTA);
                //             tablePGTA1.AddCell(cellRPSTA);
                //         }
                        
                        
                //     }
                //     document.Add(tablePGTA1);
                //     #endregion
                    
                //     #endregion

                //     #region PAGE PDF 2

                //     #region DADOS DA RESENHA
                //     /// Instância da tabela DADOS DA RESENHA
                //     PdfPTable tableRSHA = new PdfPTable(1);
                //     tableRSHA.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableRSHASize= new float[] {100};
                //     tableRSHA.SetWidths(tableRSHASize);

                //     /// Instância célula DADOS DA RESENHA
                //     PdfPCell cellRSHA = new PdfPCell(new Phrase("RESENHA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                //     cellRSHA.FixedHeight = 45f;
                //     cellRSHA.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellRSHA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellRSHA.PaddingBottom = 7f;
                //     cellRSHA.PaddingRight = 5f;

                //     tableRSHA.AddCell(cellRSHA);

                //     /// Instância célula DADOS DA RESENHA DESCRIÇÃO
                //     PdfPCell cellRSHADescricao = new PdfPCell(new Phrase("Faça uma resenha de no mínimo 20 linhas e no máximo 40 linhas sobre o livro que você leu, contando os fatos mais importantes.", FontFactory.GetFont("Roboto", 8, BaseColor.BLACK)));
                //     cellRSHADescricao.FixedHeight = 25f;
                //     cellRSHADescricao.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellRSHADescricao.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellRSHADescricao.PaddingBottom = 7f;
                //     cellRSHADescricao.PaddingRight = 5f;

                //     tableRSHA.AddCell(cellRSHADescricao);

                //     /// Instância célula DADOS DA RESENHA RESPOSTA
                //     var cellRSHATL = 42;
                //     for (var i = 1; i < cellRSHATL - 1; i++)
                //     {
                //         PdfPCell cellRSHAL = new PdfPCell(new Phrase(i.ToString(), FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                //         cellRSHAL.FixedHeight = 16f;
                //         cellRSHAL.PaddingBottom = 1f;
                //         cellRSHAL.PaddingLeft = 2f;
                        
                //         tableRSHA.AddCell(cellRSHAL);
                //     }
                    
                //     document.Add(tableRSHA);
                //     #endregion

                //     #region DADOS ASSINATURA DO ALUNO
                //     /// Instância da tabela DADOS ASSINATURA DO ALUNO
                //     PdfPTable tableDAAL = new PdfPTable(1);
                //     tableDAAL.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableDAALSize= new float[] {100};
                //     tableDAAL.SetWidths(tableDAALSize);

                //     /// Instância célula IPEN
                //     PdfPCell cellDAAL = new PdfPCell(new Phrase("ASSINATURA DO ALUNO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.GRAY)));
                //     cellDAAL.FixedHeight = 55f;
                //     cellDAAL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //     cellDAAL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                //     cellDAAL.BackgroundColor = BaseColor.LIGHT_GRAY;

                //     /// Ajuste de Alinhamento
                //     cellDAAL.PaddingBottom = 7f;
                //     cellDAAL.PaddingRight = 5f;

                //     tableDAAL.AddCell(cellDAAL);
                //     document.Add(tableDAAL);
                //     #endregion

                //     #region DADOS DATA DOCUMENTO
                //     /// Instância da tabela DATA DOCUMENTO
                //     PdfPTable tableDDD = new PdfPTable(1);
                //     tableDDD.WidthPercentage = 100f;

                //     /// Definição de largura das colunas das tabelas
                //     float[] tableDDDSize= new float[] {100};
                //     tableDDD.SetWidths(tableDDDSize);

                //     /// Instância célula DATA DOCUMENTO
                //     var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                //     PdfPCell cellDDD = new PdfPCell(new Phrase("DOCUMENTO GERADO EM: " + dateTime, FontFactory.GetFont("Roboto", 9, Font.BOLDITALIC, BaseColor.LIGHT_GRAY)));
                //     cellDDD.FixedHeight = 20f;
                //     cellDDD.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //     cellDDD.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                //     /// Ajuste de Alinhamento
                //     cellDDD.PaddingBottom = 7f;
                //     cellDDD.PaddingRight = 5f;

                //     tableDDD.AddCell(cellDDD);
                //     document.Add(tableDDD);
                //     #endregion
                    
                //     #endregion
                // }
                #endregion

                #region PAGE PDF 1

                #region HEADER
                /// Instância da tabela HEADER
                PdfPTable tableHeader = new PdfPTable(3);
                tableHeader.WidthPercentage = 100f;

                /// Instâncias 3 células do HEADER
                PdfPCell cellHeaderLogoSc = new PdfPCell();
                PdfPCell cellHeaderTitulo = new PdfPCell();
                PdfPCell cellHeaderLogoProjetoLeitura = new PdfPCell();

                /// Definição de largura das colunas das tabelas
                float[] anchoDeColumnas= new float[] {15, 62, 23};
                tableHeader.SetWidths(anchoDeColumnas);

                /// Ajuste de Alinhamento das células
                cellHeaderTitulo.PaddingTop = 8;

                /// Ajuste de cores das células
                /// LOGO SC - BORDAS
                cellHeaderLogoSc.BorderWidthRight = 1;
                cellHeaderLogoSc.BorderColorRight = BaseColor.WHITE;

                /// HEADER TÍTULO - BORDAS
                cellHeaderTitulo.BorderWidthLeft = 1;
                cellHeaderTitulo.BorderColorLeft = BaseColor.WHITE;
                cellHeaderTitulo.BorderWidthRight = 1;
                cellHeaderTitulo.BorderColorRight = BaseColor.WHITE;

                /// LOGO PROJETO - BORDAS
                cellHeaderLogoProjetoLeitura.BorderWidthLeft = 1;
                cellHeaderLogoProjetoLeitura.BorderColorLeft = BaseColor.WHITE;

                //Path imagens HEADER
                string folderLogoSCName = "img\\logo-sc.png";
                string folderLogoProjetoLeituraName = "img\\logo-projeto-leitura.jpg";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string pathLogoSCImg = System.IO.Path.Combine(webRootPath, folderLogoSCName);
                string pathLogoProjetoLeituraImg = System.IO.Path.Combine(webRootPath, folderLogoProjetoLeituraName);

                Image imageLogoSC = Image.GetInstance(pathLogoSCImg);
                Image imageLogoProjetoLeitura = Image.GetInstance(pathLogoProjetoLeituraImg);

                imageLogoSC.ScaleAbsolute(80, 90);
                imageLogoProjetoLeitura.ScaleAbsolute(121, 81);

                var headerTitulo1 = new Chunk("ESTADO DE SANTA CATARINA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                var headerTitul2 = new Chunk("SECRETARIA DE ESTADO DA ADMINISTRAÇÃO PRISIONAL E SOCIOEDUCATIVA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                var headerTitulo3 = new Chunk(dadosLeitura.DadosUnidadePrisional.NomeExibicao, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                var headerTitulo4 = new Chunk("COORDENAÇÃO DE EDUCAÇÃO E PROMOÇÃO SOCIAL", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                cellHeaderTitulo.AddElement(headerTitulo1);
                cellHeaderTitulo.AddElement(headerTitul2);
                cellHeaderTitulo.AddElement(headerTitulo3);
                cellHeaderTitulo.AddElement(headerTitulo4);

                cellHeaderLogoSc.AddElement(imageLogoSC);
                cellHeaderLogoProjetoLeitura.AddElement(imageLogoProjetoLeitura);

                tableHeader.AddCell(cellHeaderLogoSc);
                tableHeader.AddCell(cellHeaderTitulo);
                tableHeader.AddCell(cellHeaderLogoProjetoLeitura);

                document.Add(tableHeader);
                #endregion

                #region FORMULÁRIO DE LEITURA E CHAVE LEITURA
                /// Instância da tabela TEXTO FORMULÁRIO LEITURA
                PdfPTable tableFLeCH = new PdfPTable(2);
                tableFLeCH.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableFLeCHSize= new float[] {80, 20};
                tableFLeCH.SetWidths(tableFLeCHSize);

                /// Instâncias e célula do TEXTO FORMULÁRIO LEITURA e CHAVE LEITURA
                PdfPCell celltextoFL = new PdfPCell(new Phrase("FORMULÁRIO DE LEITURA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                celltextoFL.FixedHeight = 30f;
                celltextoFL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celltextoFL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                celltextoFL.PaddingBottom = 7f;
                celltextoFL.PaddingLeft = 95f;

                tableFLeCH.AddCell(celltextoFL);

                PdfPCell cellCHL = new PdfPCell(new Phrase(dadoLeitura.ChaveLeitura.ToString(), FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellCHL.FixedHeight = 30f;
                cellCHL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCHL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellCHL.PaddingBottom = 7f;

                tableFLeCH.AddCell(cellCHL);
                document.Add(tableFLeCH);
                #endregion         

                #region DADOS ALUNO E QRCODE
                /// Instância da tabela DADOS DO ALUNO
                PdfPTable tableDA = new PdfPTable(1);
                tableDA.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDASize= new float[] {100};
                tableDA.SetWidths(tableDASize);

                /// Instância célula IPEN
                PdfPCell cellDA = new PdfPCell(new Phrase("DADOS DO ALUNO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellDA.FixedHeight = 30f;
                cellDA.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellDA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellDA.PaddingBottom = 7f;
                cellDA.PaddingRight = 5f;

                tableDA.AddCell(cellDA);
                document.Add(tableDA);
                #endregion

                #region DADOS IPEN
                /// Instância da tabela IPEN
                PdfPTable tableIpen = new PdfPTable(2);
                tableIpen.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableIpenSize = new float[] {20, 80};
                tableIpen.SetWidths(tableIpenSize);

                /// Instância célula IPEN LABEL
                PdfPCell cellIpenLabel = new PdfPCell(new Phrase("IPEN: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellIpenLabel.FixedHeight = 15f;
                cellIpenLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellIpenLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellIpenLabel.PaddingTop = 1f;

                tableIpen.AddCell(cellIpenLabel);

                /// Instância célula IPEN NÚMERO
                PdfPCell cellIpenNumero = new PdfPCell(new Phrase(dadoLeitura.Ipen.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellIpenNumero.FixedHeight = 15f;
                cellIpenNumero.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellIpenNumero.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellIpenLabel.PaddingTop = 1f;

                tableIpen.AddCell(cellIpenNumero);
                document.Add(tableIpen);
                #endregion

                #region DADOS NOME
                /// Instância da tabela IPEN
                PdfPTable tableNome = new PdfPTable(2);
                tableNome.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableNomeSize = new float[] {20, 80};
                tableNome.SetWidths(tableNomeSize);

                /// Instância célula NOME LABEL
                PdfPCell cellNomeLabel = new PdfPCell(new Phrase("NOME: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellNomeLabel.FixedHeight = 15f;
                cellNomeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellNomeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellNomeLabel.PaddingTop = 1f;

                tableNome.AddCell(cellNomeLabel);

                /// Instância célula IPEN NÚMERO
                PdfPCell cellNome = new PdfPCell(new Phrase(dadoLeitura.Nome.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellNome.FixedHeight = 15f;
                cellNome.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellNome.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellNome.PaddingTop = 1f;

                tableNome.AddCell(cellNome);
                document.Add(tableNome);
                #endregion
                
                #region DADOS ESCOLARIDADE, GALERIA E CELA
                /// Instância da tabela ESCOLARIDADE, GALERIA E CELA
                PdfPTable tableEGC = new PdfPTable(6);
                tableEGC.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableEGCSize = new float[] {20, 32, 12, 12, 12, 12};
                tableEGC.SetWidths(tableEGCSize);

                /// Instância célula ESCOLARIDADE LABEL
                PdfPCell cellEscolaridadeLabel = new PdfPCell(new Phrase("ESCOLARIDADE: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellEscolaridadeLabel.FixedHeight = 15f;
                cellEscolaridadeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellEscolaridadeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellEscolaridadeLabel.PaddingTop = 1f;

                tableEGC.AddCell(cellEscolaridadeLabel);

                /// Instância célula ESCOLARIDADE
                PdfPCell cellEscolaridade = new PdfPCell(new Phrase(dadoLeitura.Escolaridade.Replace("_", " "), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellEscolaridade.FixedHeight = 15f;
                cellEscolaridade.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellEscolaridade.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellEscolaridade.PaddingTop = 1f;

                tableEGC.AddCell(cellEscolaridade);

                /// Instância célula GALERIA LABEL
                PdfPCell cellGaleriaLabel = new PdfPCell(new Phrase("GALERIA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellGaleriaLabel.FixedHeight = 15f;
                cellGaleriaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellGaleriaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellGaleriaLabel.PaddingTop = 1f;

                tableEGC.AddCell(cellGaleriaLabel);

                /// Instância célula GALERIA
                PdfPCell cellGaleria = new PdfPCell(new Phrase(dadoLeitura.Galeria, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellGaleria.FixedHeight = 15f;
                cellGaleria.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellGaleria.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellGaleria.PaddingTop = 1f;

                tableEGC.AddCell(cellGaleria);

                /// Instância célula CELA LABEL
                PdfPCell cellCelaLabel = new PdfPCell(new Phrase("CELA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellCelaLabel.FixedHeight = 15f;
                cellCelaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellCelaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellCelaLabel.PaddingTop = 1f;

                tableEGC.AddCell(cellCelaLabel);

                /// Instância célula GALERIA
                PdfPCell cellCela = new PdfPCell(new Phrase(dadoLeitura.Cela.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellCela.FixedHeight = 15f;
                cellCela.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellCela.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellCela.PaddingTop = 1f;

                tableEGC.AddCell(cellCela);

                document.Add(tableEGC);
                #endregion

                #region DADOS TÍTULO LIVRO
                /// Instância da tabela TÍTULO LIVRO
                PdfPTable tableTL = new PdfPTable(2);
                tableTL.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableTLSize = new float[] {20, 80};
                tableTL.SetWidths(tableTLSize);

                /// Instância célula TITULO LIVRO LABEL
                PdfPCell cellTLLabel = new PdfPCell(new Phrase("TÍTULO LIVRO: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellTLLabel.FixedHeight = 15f;
                cellTLLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellTLLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellTLLabel.PaddingTop = 1f;

                tableTL.AddCell(cellTLLabel);

                /// Instância célula TITULO LIVRO
                PdfPCell cellTL = new PdfPCell(new Phrase(dadoLeitura.LivroTitulo, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellTL.FixedHeight = 15f;
                cellTL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellTL.PaddingTop = 1f;

                tableTL.AddCell(cellTL);
                document.Add(tableTL);
                #endregion

                #region DADOS AUTOR
                /// Instância da tabela TÍTULO LIVRO
                PdfPTable tableAT = new PdfPTable(2);
                tableAT.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableATSize = new float[] {20, 80};
                tableAT.SetWidths(tableATSize);

                /// Instância célula AUTOR LABEL
                PdfPCell cellATLabel = new PdfPCell(new Phrase("AUTOR: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellATLabel.FixedHeight = 15f;
                cellATLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellATLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellATLabel.PaddingTop = 1f;

                tableAT.AddCell(cellATLabel);

                /// Instância célula AUTOR
                PdfPCell cellAT = new PdfPCell(new Phrase(dadoLeitura.LivroAutorNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellAT.FixedHeight = 15f;
                cellAT.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellAT.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellAT.PaddingTop = 1f;

                tableAT.AddCell(cellAT);
                document.Add(tableAT);
                #endregion

                #region DADOS PERÍODO REFERÊNCIA E ANO REFERÊNCIA
                /// Instância da tabela PERÍODO REFERÊNCIA E ANO REFERÊNCIA
                PdfPTable tablePReAR = new PdfPTable(4);
                tablePReAR.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tablePReARSize = new float[] {20, 30, 25, 25};
                tablePReAR.SetWidths(tablePReARSize);

                /// Instância célula PERÍODO REFERÊNCIA LABEL
                PdfPCell cellPRLabel = new PdfPCell(new Phrase("PERÍODO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellPRLabel.FixedHeight = 15f;
                cellPRLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellPRLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellPRLabel.PaddingTop = 1f;

                tablePReAR.AddCell(cellPRLabel);

                /// Instância célula PERÍODO REFERÊNCIA
                PdfPCell cellPR = new PdfPCell(new Phrase(dadoLeitura.AlunoLeituraCronogramaNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellPR.FixedHeight = 15f;
                cellPR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellPR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellPR.PaddingTop = 1f;

                tablePReAR.AddCell(cellPR);

                /// Instância célula ANO REFERÊNCIA LABEL
                PdfPCell cellARLabel = new PdfPCell(new Phrase("ANO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellARLabel.FixedHeight = 15f;
                cellARLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellARLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellARLabel.PaddingTop = 1f;

                tablePReAR.AddCell(cellARLabel);

                /// Instância célula ANO REFERÊNCIA
                PdfPCell cellAR = new PdfPCell(new Phrase(dadoLeitura.AlunoLeituraCronogramaAnoReferencia, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellAR.FixedHeight = 15f;
                cellAR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellAR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellAR.PaddingTop = 1f;

                tablePReAR.AddCell(cellAR);
                document.Add(tablePReAR);
                #endregion

                #region DICA DE ESCRITA
                /// Instância da tabela DICA DE ESCRITA
                PdfPTable tableDE = new PdfPTable(2);
                tableDE.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDESize = new float[] {27, 73   };
                tableDE.SetWidths(tableDESize);

                /// Instância célula DICA DE ESCRITA LABEL
                PdfPCell cellDELabel = new PdfPCell(new Phrase("DICA DE ESCRITA: ", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellDELabel.FixedHeight = 30f;
                cellDELabel.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellDELabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellDELabel.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellDELabel.PaddingBottom = 7f;
                cellDELabel.PaddingRight = 5f;

                tableDE.AddCell(cellDELabel);

                /// Instância célula DICA DE ESCRITA LABEL
                PdfPCell cellDE = new PdfPCell(new Phrase(dadosLeitura.FormularioLeituraDicaEscrita.Nome, FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellDE.FixedHeight = 30f;
                cellDE.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellDE.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellDE.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellDE.PaddingBottom = 7f;
                cellDE.PaddingLeft = 10f;

                tableDE.AddCell(cellDE);

                document.Add(tableDE);
                #endregion

                #region DICA DE ESCRITA LINHAS
                /// Instância da tabela DICA DE ESCRITA LINHAS
                PdfPTable tableDEL = new PdfPTable(1);
                tableDEL.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDELSize = new float[] {100};
                tableDEL.SetWidths(tableDELSize);

                var dicasOrdenadas = dadosLeitura.FormularioLeituraDicaEscrita.FormularioLeituraDicaEscritaDicas.OrderBy(x => x.Ordem).ToList();
                foreach (var tmp in dicasOrdenadas.ToList())
                {
                    /// Instância célula DICA DE ESCRITA LINHA 1
                    PdfPCell cellDEL = new PdfPCell(new Phrase(tmp.Dica.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                    cellDEL.FixedHeight = 15f;
                    cellDEL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    cellDEL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cellDEL.BackgroundColor = BaseColor.LIGHT_GRAY;

                    /// Ajuste de Alinhamento
                    cellDEL.PaddingBottom = 3f;

                    tableDEL.AddCell(cellDEL);
                }

                document.Add(tableDEL);
                #endregion

                #region DADOS DA LEITURA
                /// Instância da tabela DADOS DA LEITURA
                PdfPTable tableDL = new PdfPTable(1);
                tableDL.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDLSize= new float[] {100};
                tableDL.SetWidths(tableDLSize);

                /// Instância célula IPEN
                PdfPCell cellDL = new PdfPCell(new Phrase("DADOS DA LEITURA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellDL.FixedHeight = 30f;
                cellDL.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellDL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellDL.PaddingBottom = 7f;
                cellDL.PaddingRight = 5f;

                tableDL.AddCell(cellDL);
                document.Add(tableDL);
                #endregion

                #region DADOS PERGUNTAS 1 a 5
                /// Instância da tabela PERGUNTA 1 
                PdfPTable tablePGTA1 = new PdfPTable(1);
                tablePGTA1.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tablePGTA1Size = new float[] {100};
                tablePGTA1.SetWidths(tablePGTA1Size);

                var perguntasOrdenadas = dadosLeitura.FormularioLeituraPerguntaGrupo.FormularioLeituraPerguntas.OrderBy(x => x.Ordem);
                foreach (var item in perguntasOrdenadas.Select((value, i) => new { i, value }))
                {
                    

                    PdfPCell cellPGTA = new PdfPCell(new Phrase(item.value.Ordem + ". " + item.value.Pergunta, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                    cellPGTA.FixedHeight = 15f;
                    cellPGTA.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    cellPGTA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cellPGTA.BackgroundColor = BaseColor.LIGHT_GRAY;

                    /// Ajuste de Alinhamento
                    cellPGTA.PaddingTop = 1f;

                    tablePGTA1.AddCell(cellPGTA);

                    /// Instância célula RESPOSTA 1
                    PdfPCell cellRPSTA = new PdfPCell();
                    cellRPSTA.FixedHeight = 15f;

                    if (item.i == (perguntasOrdenadas.Count() - 1) ||
                        item.i == (perguntasOrdenadas.Count() - 2))
                    {
                        tablePGTA1.AddCell(cellRPSTA);
                        tablePGTA1.AddCell(cellRPSTA);
                        tablePGTA1.AddCell(cellRPSTA);    
                    }
                    else 
                    {
                        tablePGTA1.AddCell(cellRPSTA);
                        tablePGTA1.AddCell(cellRPSTA);
                        tablePGTA1.AddCell(cellRPSTA);
                        tablePGTA1.AddCell(cellRPSTA);
                        tablePGTA1.AddCell(cellRPSTA);
                    }
                    
                    
                }
                document.Add(tablePGTA1);
                #endregion
                
                #endregion

                #region PAGE PDF 2

                #region DADOS DA RESENHA
                /// Instância da tabela DADOS DA RESENHA
                PdfPTable tableRSHA = new PdfPTable(1);
                tableRSHA.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableRSHASize= new float[] {100};
                tableRSHA.SetWidths(tableRSHASize);

                /// Instância célula DADOS DA RESENHA
                PdfPCell cellRSHA = new PdfPCell(new Phrase("RESENHA", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellRSHA.FixedHeight = 45f;
                cellRSHA.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellRSHA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellRSHA.PaddingBottom = 7f;
                cellRSHA.PaddingRight = 5f;

                tableRSHA.AddCell(cellRSHA);

                /// Instância célula DADOS DA RESENHA DESCRIÇÃO
                PdfPCell cellRSHADescricao = new PdfPCell(new Phrase("Faça uma resenha de no mínimo 20 linhas e no máximo 40 linhas sobre o livro que você leu, contando os fatos mais importantes.", FontFactory.GetFont("Roboto", 8, BaseColor.BLACK)));
                cellRSHADescricao.FixedHeight = 25f;
                cellRSHADescricao.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellRSHADescricao.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellRSHADescricao.PaddingBottom = 7f;
                cellRSHADescricao.PaddingRight = 5f;

                tableRSHA.AddCell(cellRSHADescricao);

                /// Instância célula DADOS DA RESENHA RESPOSTA
                var cellRSHATL = 42;
                for (var i = 1; i < cellRSHATL - 1; i++)
                {
                    PdfPCell cellRSHAL = new PdfPCell(new Phrase(i.ToString(), FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                    cellRSHAL.FixedHeight = 16f;
                    cellRSHAL.PaddingBottom = 1f;
                    cellRSHAL.PaddingLeft = 2f;
                    
                    tableRSHA.AddCell(cellRSHAL);
                }
                
                document.Add(tableRSHA);
                #endregion

                #region DADOS ASSINATURA DO ALUNO
                /// Instância da tabela DADOS ASSINATURA DO ALUNO
                PdfPTable tableDAAL = new PdfPTable(1);
                tableDAAL.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDAALSize= new float[] {100};
                tableDAAL.SetWidths(tableDAALSize);

                /// Instância célula IPEN
                PdfPCell cellDAAL = new PdfPCell(new Phrase("ASSINATURA DO ALUNO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.GRAY)));
                cellDAAL.FixedHeight = 55f;
                cellDAAL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellDAAL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellDAAL.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellDAAL.PaddingBottom = 7f;
                cellDAAL.PaddingRight = 5f;

                tableDAAL.AddCell(cellDAAL);
                document.Add(tableDAAL);
                #endregion

                #region DADOS DATA DOCUMENTO
                /// Instância da tabela DATA DOCUMENTO
                PdfPTable tableDDD = new PdfPTable(1);
                tableDDD.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDDDSize= new float[] {100};
                tableDDD.SetWidths(tableDDDSize);

                /// Instância célula DATA DOCUMENTO
                var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                PdfPCell cellDDD = new PdfPCell(new Phrase("DOCUMENTO GERADO EM: " + dateTime, FontFactory.GetFont("Roboto", 9, Font.BOLDITALIC, BaseColor.LIGHT_GRAY)));
                cellDDD.FixedHeight = 20f;
                cellDDD.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellDDD.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellDDD.PaddingBottom = 7f;
                cellDDD.PaddingRight = 5f;

                tableDDD.AddCell(cellDDD);
                document.Add(tableDDD);
                #endregion
                
                #endregion
            }

            document.Close();

            byte[] bytes = zipFileMemoryStream.ToArray();
            MemoryStream inStream = new MemoryStream(bytes);

            return bytes;
        }

        private byte[] CriarPDFForRelatorioLeitura(RelatorioAvaliacaoViewModel dadosLeitura)
        {
            var zipFileMemoryStream = new MemoryStream();
            Document document = new Document(PageSize.A4, 25, 25, 25, 15);
            document.SetMargins(15, 15, 35, 0);

            PdfWriter.GetInstance(document, zipFileMemoryStream).CloseStream = false;
            document.Open();

            // var leiturasOrdenandasPorDataAvaliacao = dadosLeitura.DadosLeituras.OrderBy(x => x.DataAvaliacao);
            var leiturasOrdenandasPorDataAvaliacao = dadosLeitura.DadosLeituras.ToList();
            foreach (var dadoLeitura in leiturasOrdenandasPorDataAvaliacao.ToList())
            {
                #region PAGE PDF 1

                #region HEADER
                /// Instância da tabela HEADER
                PdfPTable tableHeader = new PdfPTable(3);
                tableHeader.WidthPercentage = 100f;

                /// Instâncias 3 células do HEADER
                PdfPCell cellHeaderLogoSc = new PdfPCell();
                PdfPCell cellHeaderTitulo = new PdfPCell();
                PdfPCell cellHeaderLogoProjetoLeitura = new PdfPCell();

                /// Definição de largura das colunas das tabelas
                float[] anchoDeColumnas= new float[] {15, 62, 23};
                tableHeader.SetWidths(anchoDeColumnas);

                /// Ajuste de Alinhamento das células
                cellHeaderTitulo.PaddingTop = 8;

                /// Ajuste de cores das células
                /// LOGO SC - BORDAS
                cellHeaderLogoSc.BorderWidthRight = 1;
                cellHeaderLogoSc.BorderColorRight = BaseColor.WHITE;

                /// HEADER TÍTULO - BORDAS
                cellHeaderTitulo.BorderWidthLeft = 1;
                cellHeaderTitulo.BorderColorLeft = BaseColor.WHITE;
                cellHeaderTitulo.BorderWidthRight = 1;
                cellHeaderTitulo.BorderColorRight = BaseColor.WHITE;

                /// LOGO PROJETO - BORDAS
                cellHeaderLogoProjetoLeitura.BorderWidthLeft = 1;
                cellHeaderLogoProjetoLeitura.BorderColorLeft = BaseColor.WHITE;

                //Path imagens HEADER
                string folderLogoSCName = "img\\logo-sc.png";
                string folderLogoProjetoLeituraName = "img\\logo-projeto-leitura.jpg";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string pathLogoSCImg = System.IO.Path.Combine(webRootPath, folderLogoSCName);
                string pathLogoProjetoLeituraImg = System.IO.Path.Combine(webRootPath, folderLogoProjetoLeituraName);

                Image imageLogoSC = Image.GetInstance(pathLogoSCImg);
                Image imageLogoProjetoLeitura = Image.GetInstance(pathLogoProjetoLeituraImg);

                imageLogoSC.ScaleAbsolute(80, 90);
                imageLogoProjetoLeitura.ScaleAbsolute(121, 81);

                var headerTitulo1 = new Chunk("ESTADO DE SANTA CATARINA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                var headerTitul2 = new Chunk("SECRETARIA DE ESTADO DA ADMINISTRAÇÃO PRISIONAL E SOCIOEDUCATIVA", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                var headerTitulo3 = new Chunk(dadosLeitura.DadosUnidadePrisional.NomeExibicao, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                var headerTitulo4 = new Chunk("COORDENAÇÃO DE EDUCAÇÃO E PROMOÇÃO SOCIAL", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK));
                cellHeaderTitulo.AddElement(headerTitulo1);
                cellHeaderTitulo.AddElement(headerTitul2);
                cellHeaderTitulo.AddElement(headerTitulo3);
                cellHeaderTitulo.AddElement(headerTitulo4);

                cellHeaderLogoSc.AddElement(imageLogoSC);
                cellHeaderLogoProjetoLeitura.AddElement(imageLogoProjetoLeitura);

                tableHeader.AddCell(cellHeaderLogoSc);
                tableHeader.AddCell(cellHeaderTitulo);
                tableHeader.AddCell(cellHeaderLogoProjetoLeitura);

                document.Add(tableHeader);
                #endregion

                #region RELATÓRIO DE AVALIAÇÃO E CHAVE LEITURA
                /// Instância da tabela TEXTO RELATÓRIO AVALIAÇÃO
                PdfPTable tableFLeCH = new PdfPTable(2);
                tableFLeCH.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableFLeCHSize= new float[] {80, 20};
                tableFLeCH.SetWidths(tableFLeCHSize);

                /// Instâncias e célula do TEXTO FORMULÁRIO LEITURA e CHAVE LEITURA
                PdfPCell celltextoFL = new PdfPCell(new Phrase("RELATÓRIO DE AVALIAÇÃO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                celltextoFL.FixedHeight = 30f;
                celltextoFL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celltextoFL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                celltextoFL.PaddingBottom = 7f;
                celltextoFL.PaddingLeft = 100f;

                tableFLeCH.AddCell(celltextoFL);

                PdfPCell cellCHL = new PdfPCell(new Phrase(dadoLeitura.ChaveLeitura.ToString(), FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellCHL.FixedHeight = 30f;
                cellCHL.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCHL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellCHL.PaddingBottom = 7f;

                tableFLeCH.AddCell(cellCHL);
                document.Add(tableFLeCH);
                #endregion         

                #region DADOS ALUNO E QRCODE
                /// Instância da tabela DADOS DO ALUNO
                PdfPTable tableDA = new PdfPTable(1);
                tableDA.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDASize= new float[] {100};
                tableDA.SetWidths(tableDASize);

                /// Instância célula IPEN
                PdfPCell cellDA = new PdfPCell(new Phrase("DADOS DO ALUNO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellDA.FixedHeight = 30f;
                cellDA.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellDA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellDA.PaddingBottom = 7f;
                cellDA.PaddingRight = 5f;

                tableDA.AddCell(cellDA);
                document.Add(tableDA);
                #endregion

                #region DADOS IPEN
                /// Instância da tabela IPEN
                PdfPTable tableIpen = new PdfPTable(2);
                tableIpen.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableIpenSize = new float[] {20, 80};
                tableIpen.SetWidths(tableIpenSize);

                /// Instância célula IPEN LABEL
                PdfPCell cellIpenLabel = new PdfPCell(new Phrase("IPEN: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellIpenLabel.FixedHeight = 15f;
                cellIpenLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellIpenLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellIpenLabel.PaddingTop = 1f;

                tableIpen.AddCell(cellIpenLabel);

                /// Instância célula IPEN NÚMERO
                PdfPCell cellIpenNumero = new PdfPCell(new Phrase(dadoLeitura.Ipen.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellIpenNumero.FixedHeight = 15f;
                cellIpenNumero.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellIpenNumero.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellIpenLabel.PaddingTop = 1f;

                tableIpen.AddCell(cellIpenNumero);
                document.Add(tableIpen);
                #endregion

                #region DADOS NOME
                /// Instância da tabela IPEN
                PdfPTable tableNome = new PdfPTable(2);
                tableNome.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableNomeSize = new float[] {20, 80};
                tableNome.SetWidths(tableNomeSize);

                /// Instância célula NOME LABEL
                PdfPCell cellNomeLabel = new PdfPCell(new Phrase("NOME: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellNomeLabel.FixedHeight = 15f;
                cellNomeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellNomeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellNomeLabel.PaddingTop = 1f;

                tableNome.AddCell(cellNomeLabel);

                /// Instância célula IPEN NÚMERO
                PdfPCell cellNome = new PdfPCell(new Phrase(dadoLeitura.Nome.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellNome.FixedHeight = 15f;
                cellNome.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellNome.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellNome.PaddingTop = 1f;

                tableNome.AddCell(cellNome);
                document.Add(tableNome);
                #endregion
                
                #region DADOS ESCOLARIDADE, GALERIA E CELA
                /// Instância da tabela ESCOLARIDADE, GALERIA E CELA
                PdfPTable tableEGC = new PdfPTable(6);
                tableEGC.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableEGCSize = new float[] {20, 32, 12, 12, 12, 12};
                tableEGC.SetWidths(tableEGCSize);

                /// Instância célula ESCOLARIDADE LABEL
                PdfPCell cellEscolaridadeLabel = new PdfPCell(new Phrase("ESCOLARIDADE: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellEscolaridadeLabel.FixedHeight = 15f;
                cellEscolaridadeLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellEscolaridadeLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellEscolaridadeLabel.PaddingTop = 1f;

                tableEGC.AddCell(cellEscolaridadeLabel);

                /// Instância célula ESCOLARIDADE
                PdfPCell cellEscolaridade = new PdfPCell(new Phrase(dadoLeitura.Escolaridade.Replace("_", " "), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellEscolaridade.FixedHeight = 15f;
                cellEscolaridade.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellEscolaridade.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellEscolaridade.PaddingTop = 1f;

                tableEGC.AddCell(cellEscolaridade);

                /// Instância célula GALERIA LABEL
                PdfPCell cellGaleriaLabel = new PdfPCell(new Phrase("GALERIA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellGaleriaLabel.FixedHeight = 15f;
                cellGaleriaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellGaleriaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellGaleriaLabel.PaddingTop = 1f;

                tableEGC.AddCell(cellGaleriaLabel);

                /// Instância célula GALERIA
                PdfPCell cellGaleria = new PdfPCell(new Phrase(dadoLeitura.Galeria, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellGaleria.FixedHeight = 15f;
                cellGaleria.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellGaleria.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellGaleria.PaddingTop = 1f;

                tableEGC.AddCell(cellGaleria);

                /// Instância célula CELA LABEL
                PdfPCell cellCelaLabel = new PdfPCell(new Phrase("CELA: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellCelaLabel.FixedHeight = 15f;
                cellCelaLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellCelaLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellCelaLabel.PaddingTop = 1f;

                tableEGC.AddCell(cellCelaLabel);

                /// Instância célula GALERIA
                PdfPCell cellCela = new PdfPCell(new Phrase(dadoLeitura.Cela.ToString(), FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellCela.FixedHeight = 15f;
                cellCela.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellCela.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellCela.PaddingTop = 1f;

                tableEGC.AddCell(cellCela);

                document.Add(tableEGC);
                #endregion

                #region DADOS TÍTULO LIVRO
                /// Instância da tabela TÍTULO LIVRO
                PdfPTable tableTL = new PdfPTable(2);
                tableTL.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableTLSize = new float[] {20, 80};
                tableTL.SetWidths(tableTLSize);

                /// Instância célula TITULO LIVRO LABEL
                PdfPCell cellTLLabel = new PdfPCell(new Phrase("TÍTULO LIVRO: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellTLLabel.FixedHeight = 15f;
                cellTLLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellTLLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellTLLabel.PaddingTop = 1f;

                tableTL.AddCell(cellTLLabel);

                /// Instância célula TITULO LIVRO
                PdfPCell cellTL = new PdfPCell(new Phrase(dadoLeitura.LivroTitulo, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellTL.FixedHeight = 15f;
                cellTL.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTL.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellTL.PaddingTop = 1f;

                tableTL.AddCell(cellTL);
                document.Add(tableTL);
                #endregion

                #region DADOS AUTOR
                /// Instância da tabela TÍTULO LIVRO
                PdfPTable tableAT = new PdfPTable(2);
                tableAT.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableATSize = new float[] {20, 80};
                tableAT.SetWidths(tableATSize);

                /// Instância célula AUTOR LABEL
                PdfPCell cellATLabel = new PdfPCell(new Phrase("AUTOR: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellATLabel.FixedHeight = 15f;
                cellATLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellATLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellATLabel.PaddingTop = 1f;

                tableAT.AddCell(cellATLabel);

                /// Instância célula AUTOR
                PdfPCell cellAT = new PdfPCell(new Phrase(dadoLeitura.LivroAutorNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellAT.FixedHeight = 15f;
                cellAT.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellAT.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellAT.PaddingTop = 1f;

                tableAT.AddCell(cellAT);
                document.Add(tableAT);
                #endregion

                #region DADOS PERÍODO REFERÊNCIA E ANO REFERÊNCIA
                /// Instância da tabela PERÍODO REFERÊNCIA E ANO REFERÊNCIA
                PdfPTable tablePReAR = new PdfPTable(4);
                tablePReAR.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tablePReARSize = new float[] {20, 30, 25, 25};
                tablePReAR.SetWidths(tablePReARSize);

                /// Instância célula PERÍODO REFERÊNCIA LABEL
                PdfPCell cellPRLabel = new PdfPCell(new Phrase("PERÍODO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellPRLabel.FixedHeight = 15f;
                cellPRLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellPRLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellPRLabel.PaddingTop = 1f;

                tablePReAR.AddCell(cellPRLabel);

                /// Instância célula PERÍODO REFERÊNCIA
                PdfPCell cellPR = new PdfPCell(new Phrase(dadoLeitura.AlunoLeituraCronogramaNome, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellPR.FixedHeight = 15f;
                cellPR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellPR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellPR.PaddingTop = 1f;

                tablePReAR.AddCell(cellPR);

                /// Instância célula ANO REFERÊNCIA LABEL
                PdfPCell cellARLabel = new PdfPCell(new Phrase("ANO REF: ", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellARLabel.FixedHeight = 15f;
                cellARLabel.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellARLabel.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellARLabel.PaddingTop = 1f;

                tablePReAR.AddCell(cellARLabel);

                /// Instância célula ANO REFERÊNCIA
                PdfPCell cellAR = new PdfPCell(new Phrase(dadoLeitura.AlunoLeituraCronogramaAnoReferencia, FontFactory.GetFont("Roboto", 10, BaseColor.BLACK)));
                cellAR.FixedHeight = 15f;
                cellAR.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellAR.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellAR.PaddingTop = 1f;

                tablePReAR.AddCell(cellAR);
                document.Add(tablePReAR);
                #endregion

                #region CRITÉRIOS DE AVALIAÇÃO
                /// Instância da tabela CRITÉRIO DE AVALIAÇÃO
                PdfPTable tableCA = new PdfPTable(1);
                tableCA.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCASize= new float[] {100};
                tableCA.SetWidths(tableCASize);

                /// Instância célula IPEN
                PdfPCell cellCA = new PdfPCell(new Phrase("CRITÉRIOS DE AVALIAÇÃO", FontFactory.GetFont("Roboto", 14, Font.BOLDITALIC, BaseColor.BLACK)));
                cellCA.FixedHeight = 30f;
                cellCA.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellCA.PaddingBottom = 7f;
                cellCA.PaddingRight = 5f;

                tableCA.AddCell(cellCA);
                document.Add(tableCA);
                #endregion

                #region CRITÉRIOS DE AVALIAÇÃO - DO 1 AO 7                
                var index = 1;

                #region CRITÉRIO 1
                /// Instância da tabela CRITÉRIO 1
                PdfPTable tableCA1 = new PdfPTable(3);
                tableCA1.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCA1Size = new float[] {20, 60, 20};
                tableCA1.SetWidths(tableCA1Size);

                PdfPCell cellACA = new PdfPCell(new Phrase((index++).ToString(), FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACA.FixedHeight = 50f;
                cellACA.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACA.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACA.PaddingTop = 1f;

                tableCA1.AddCell(cellACA);

                PdfPCell cellACB = new PdfPCell(new Phrase("- ADEQUAÇÃO DO TEXTO AO GÊNERO -", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACB.FixedHeight = 50f;
                cellACB.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACB.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACB.PaddingTop = 1f;

                tableCA1.AddCell(cellACB);
                
                String crt1;
                try
                {
                    crt1 = dadoLeitura.AvaliacaoCriterio1;
                }
                catch { throw new Exception("Problemas na conversão do critério 1. Tente novamente daqui a alguns minutos."); }
                
                PdfPCell cellACC = new PdfPCell(new Phrase(crt1, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.DARK_GRAY)));
                cellACC.FixedHeight = 50f;
                cellACC.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACC.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellACC.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellACC.PaddingTop = 1f;

                tableCA1.AddCell(cellACC);
                document.Add(tableCA1);
                #endregion

                #region CRITÉRIO 2
                /// Instância da tabela CRITÉRIO 2
                PdfPTable tableCA2 = new PdfPTable(3);
                tableCA2.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCA2Size = new float[] {20, 60, 20};
                tableCA2.SetWidths(tableCA2Size);

                PdfPCell cellACA2 = new PdfPCell(new Phrase((index++).ToString(), FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACA2.FixedHeight = 50f;
                cellACA2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACA2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACA2.PaddingTop = 1f;

                tableCA2.AddCell(cellACA2);

                PdfPCell cellACB2 = new PdfPCell(new Phrase("- COESÃO E COERÊNCIA -", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACB2.FixedHeight = 50f;
                cellACB2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACB2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACB2.PaddingTop = 1f;

                tableCA2.AddCell(cellACB2);
                
                String crt2;
                try
                {
                    crt2 = dadoLeitura.AvaliacaoCriterio2;
                }
                catch { throw new Exception("Problemas na conversão do critério 2. Tente novamente daqui a alguns minutos."); }
                
                PdfPCell cellACC2 = new PdfPCell(new Phrase(crt2, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.DARK_GRAY)));
                cellACC2.FixedHeight = 50f;
                cellACC2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACC2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellACC2.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellACC2.PaddingTop = 1f;

                tableCA2.AddCell(cellACC2);
                document.Add(tableCA2);
                #endregion 

                #region CRITÉRIO 3
                /// Instância da tabela CRITÉRIO 3
                PdfPTable tableCA3 = new PdfPTable(3);
                tableCA3.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCA3Size = new float[] {20, 60, 20};
                tableCA3.SetWidths(tableCA3Size);

                PdfPCell cellACA3 = new PdfPCell(new Phrase((index++).ToString(), FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACA3.FixedHeight = 50f;
                cellACA3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACA3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACA3.PaddingTop = 1f;

                tableCA3.AddCell(cellACA3);

                PdfPCell cellACB3 = new PdfPCell(new Phrase("- COMPROVAÇÃO DA LEITURA -", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACB3.FixedHeight = 50f;
                cellACB3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACB3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACB3.PaddingTop = 1f;

                tableCA3.AddCell(cellACB3);
                
                String crt3;
                try
                {
                    crt3 = dadoLeitura.AvaliacaoCriterio3;
                }
                catch { throw new Exception("Problemas na conversão do critério 3. Tente novamente daqui a alguns minutos."); }
                
                PdfPCell cellACC3 = new PdfPCell(new Phrase(crt3, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.DARK_GRAY)));
                cellACC3.FixedHeight = 50f;
                cellACC3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACC3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellACC3.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellACC3.PaddingTop = 1f;

                tableCA3.AddCell(cellACC3);
                document.Add(tableCA3);
                #endregion 

                #region CRITÉRIO 4
                /// Instância da tabela CRITÉRIO 4
                PdfPTable tableCA4 = new PdfPTable(3);
                tableCA4.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCA4Size = new float[] {20, 60, 20};
                tableCA4.SetWidths(tableCA4Size);

                PdfPCell cellACA4 = new PdfPCell(new Phrase((index++).ToString(), FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACA4.FixedHeight = 50f;
                cellACA4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACA4.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACA4.PaddingTop = 1f;

                tableCA4.AddCell(cellACA4);

                PdfPCell cellACB4 = new PdfPCell(new Phrase("- COMPREENSÃO DO CONTEÚDO -", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACB4.FixedHeight = 50f;
                cellACB4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACB4.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACB4.PaddingTop = 1f;

                tableCA4.AddCell(cellACB4);
                
                String crt4;
                try
                {
                    crt4 = dadoLeitura.AvaliacaoCriterio4;
                }
                catch { throw new Exception("Problemas na conversão do critério 4. Tente novamente daqui a alguns minutos."); }
                
                PdfPCell cellACC4 = new PdfPCell(new Phrase(crt4, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.DARK_GRAY)));
                cellACC4.FixedHeight = 50f;
                cellACC4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACC4.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellACC4.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellACC4.PaddingTop = 1f;

                tableCA4.AddCell(cellACC4);
                document.Add(tableCA4);
                #endregion                

                #region CRITÉRIO 5
                /// Instância da tabela CRITÉRIO 5
                PdfPTable tableCA5 = new PdfPTable(3);
                tableCA5.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCA5Size = new float[] {20, 60, 20};
                tableCA5.SetWidths(tableCA5Size);

                PdfPCell cellACA5 = new PdfPCell(new Phrase((index++).ToString(), FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACA5.FixedHeight = 50f;
                cellACA5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACA5.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACA5.PaddingTop = 1f;

                tableCA5.AddCell(cellACA5);

                PdfPCell cellACB5 = new PdfPCell(new Phrase("- LINGUAGEM CLARA E OBJETIVA -", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACB5.FixedHeight = 50f;
                cellACB5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACB5.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACB5.PaddingTop = 1f;

                tableCA5.AddCell(cellACB5);
                
                String crt5;
                try
                {
                    crt5 = dadoLeitura.AvaliacaoCriterio5;
                }
                catch { throw new Exception("Problemas na conversão do critério 5. Tente novamente daqui a alguns minutos."); }
                
                PdfPCell cellACC5 = new PdfPCell(new Phrase(crt5, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.DARK_GRAY)));
                cellACC5.FixedHeight = 50f;
                cellACC5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACC5.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellACC5.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellACC5.PaddingTop = 1f;

                tableCA5.AddCell(cellACC5);
                document.Add(tableCA5);
                #endregion

                #region CRITÉRIO 6
                /// Instância da tabela CRITÉRIO 6
                PdfPTable tableCA6 = new PdfPTable(3);
                tableCA6.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCA6Size = new float[] {20, 60, 20};
                tableCA6.SetWidths(tableCA6Size);

                PdfPCell cellACA6 = new PdfPCell(new Phrase((index++).ToString(), FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACA6.FixedHeight = 50f;
                cellACA6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACA6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACA6.PaddingTop = 1f;

                tableCA6.AddCell(cellACA6);

                PdfPCell cellACB6 = new PdfPCell(new Phrase("- VARIEDADE DE VOCABULÁRIO -", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACB6.FixedHeight = 50f;
                cellACB6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACB6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACB6.PaddingTop = 1f;

                tableCA6.AddCell(cellACB6);
                
                String crt6;
                try
                {
                    crt6 = dadoLeitura.AvaliacaoCriterio6;
                }
                catch { throw new Exception("Problemas na conversão do critério 6. Tente novamente daqui a alguns minutos."); }
                
                PdfPCell cellACC6 = new PdfPCell(new Phrase(crt6, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.DARK_GRAY)));
                cellACC6.FixedHeight = 50f;
                cellACC6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACC6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellACC6.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellACC6.PaddingTop = 1f;

                tableCA6.AddCell(cellACC6);
                document.Add(tableCA6);
                #endregion

                #region CRITÉRIO 7
                /// Instância da tabela CRITÉRIO 7
                PdfPTable tableCA7 = new PdfPTable(3);
                tableCA7.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableCA7Size = new float[] {20, 60, 20};
                tableCA7.SetWidths(tableCA7Size);

                PdfPCell cellACA7 = new PdfPCell(new Phrase((index++).ToString(), FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACA7.FixedHeight = 50f;
                cellACA7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACA7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACA7.PaddingTop = 1f;

                tableCA7.AddCell(cellACA7);

                PdfPCell cellACB7 = new PdfPCell(new Phrase("- ORTOGRAFIA E ASPECTOS GRAMATICAIS -", FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.BLACK)));
                cellACB7.FixedHeight = 50f;
                cellACB7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACB7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellACB7.PaddingTop = 1f;

                tableCA7.AddCell(cellACB7);
                
                String crt7;
                try
                {
                    crt7 = dadoLeitura.AvaliacaoCriterio7;
                }
                catch { throw new Exception("Problemas na conversão do critério 7. Tente novamente daqui a alguns minutos."); }
                
                PdfPCell cellACC7 = new PdfPCell(new Phrase(crt7, FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.DARK_GRAY)));
                cellACC7.FixedHeight = 50f;
                cellACC7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellACC7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellACC7.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellACC7.PaddingTop = 1f;

                tableCA7.AddCell(cellACC7);
                document.Add(tableCA7);
                #endregion

                #endregion

                #region DADOS CONCEITO TITULO
                /// Instância da tabela DADOS CONCEITO TITULO
                PdfPTable tableDCT = new PdfPTable(1);
                tableDCT.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDCTSize= new float[] {100};
                tableDCT.SetWidths(tableDCTSize);

                /// Instância célula DATA DOCUMENTO
                PdfPCell cellDCT = new PdfPCell(new Phrase("CONCEITO", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellDCT.FixedHeight = 20f;
                cellDCT.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellDCT.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellDCT.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellDCT.PaddingBottom = 7f;

                tableDCT.AddCell(cellDCT);
                document.Add(tableDCT);
                #endregion

                #region DADOS CONCEITO OBTIDO
                /// Instância da tabela DADOS CONCEITO OBTIDO
                PdfPTable tableDCO = new PdfPTable(1);
                tableDCO.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDCOSize= new float[] {100};
                tableDCO.SetWidths(tableDCOSize);

                /// Instância célula DATA DOCUMENTO
                PdfPCell cellDCO = new PdfPCell(new Phrase(dadoLeitura.AvaliacaoConceito, FontFactory.GetFont("Roboto", 12, Font.BOLD, BaseColor.LIGHT_GRAY)));
                cellDCO.FixedHeight = 25f;
                cellDCO.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellDCO.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellDCO.PaddingBottom = 7f;
                cellDCO.PaddingRight = 5f;

                tableDCO.AddCell(cellDCO);
                document.Add(tableDCO);
                #endregion

                #region DADOS JUSTIFICATIVA CONCEITO TITULO
                /// Instância da tabela DADOS JUSTIFICATIVA CONCEITO TITULO
                PdfPTable tableJCT = new PdfPTable(1);
                tableJCT.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableJCTSize= new float[] {100};
                tableJCT.SetWidths(tableDCTSize);

                /// Instância célula DATA DOCUMENTO
                PdfPCell cellJCT = new PdfPCell(new Phrase("JUSTIFICATIVA CONCEITO", FontFactory.GetFont("Roboto", 10, Font.BOLD, BaseColor.BLACK)));
                cellJCT.FixedHeight = 20f;
                cellJCT.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellJCT.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellJCT.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellJCT.PaddingBottom = 7f;

                tableJCT.AddCell(cellJCT);
                document.Add(tableJCT);
                #endregion

                #region DADOS JUSTIFICATIVA CONCEITO
                /// Instância da tabela DADOS JUSTIFICATIVA CONCEITO
                PdfPTable tableJC = new PdfPTable(1);
                tableJC.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableJCSize= new float[] {100};
                tableJC.SetWidths(tableJCSize);

                /// Instância célula DATA DOCUMENTO
                PdfPCell cellJC = new PdfPCell(new Phrase(dadoLeitura.AvaliacaoConceitoJustificativa, FontFactory.GetFont("Roboto", 9, Font.BOLD, BaseColor.LIGHT_GRAY)));
                cellJC.FixedHeight = 50f;
                cellJC.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellJC.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellJC.PaddingBottom = 7f;
                cellJC.PaddingRight = 5f;

                tableJC.AddCell(cellJC);
                document.Add(tableJC);
                #endregion

                #region DADOS ASSINATURA DO PROFESSOR
                /// Instância da tabela DADOS ASSINATURA DO PROFESSOR
                PdfPTable tableDAP = new PdfPTable(1);
                tableDAP.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDAPSize= new float[] {100};
                tableDAP.SetWidths(tableDAPSize);

                /// Instância célula IPEN
                PdfPCell cellDAP = new PdfPCell(new Phrase("ASSINATURA PROFESSOR (A) ORIENTADOR (A) DA LEITURA", FontFactory.GetFont("Roboto", 14, Font.BOLD, BaseColor.GRAY)));
                cellDAP.FixedHeight = 40f;
                cellDAP.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellDAP.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellDAP.BackgroundColor = BaseColor.LIGHT_GRAY;

                /// Ajuste de Alinhamento
                cellDAP.PaddingBottom = 7f;
                cellDAP.PaddingRight = 5f;

                tableDAP.AddCell(cellDAP);
                document.Add(tableDAP);
                #endregion

                #region DADOS DATA DOCUMENTO
                /// Instância da tabela DATA DOCUMENTO
                PdfPTable tableDDD = new PdfPTable(1);
                tableDDD.WidthPercentage = 100f;

                /// Definição de largura das colunas das tabelas
                float[] tableDDDSize= new float[] {100};
                tableDDD.SetWidths(tableDDDSize);

                /// Instância célula DATA DOCUMENTO
                var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                PdfPCell cellDDD = new PdfPCell(new Phrase("DOCUMENTO GERADO EM: " + dateTime, FontFactory.GetFont("Roboto", 9, Font.BOLDITALIC, BaseColor.LIGHT_GRAY)));
                cellDDD.FixedHeight = 20f;
                cellDDD.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellDDD.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                /// Ajuste de Alinhamento
                cellDDD.PaddingBottom = 7f;
                cellDDD.PaddingRight = 5f;

                tableDDD.AddCell(cellDDD);
                document.Add(tableDDD);
                #endregion

                #endregion
            }

            document.Close();

            byte[] bytes = zipFileMemoryStream.ToArray();
            MemoryStream inStream = new MemoryStream(bytes);

            return bytes;
        }
        #endregion
        
        #region Métodos de relatórios e formulários
        [Route("get-all-form-leituras")]
        [HttpPost]
        public async Task<IActionResult> GetAllFormLeiturasAsync([FromBody]AlunoLeituraFormsLeiturasRequestModel 
                                                                    alunoLeituraFormsLeiturasRequestModel)
        {
            var leituras = await _alunoLeituraManager
                                    .GetAllForFormsLeituraAsync(alunoLeituraFormsLeiturasRequestModel);
        
            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
            byte[] bytes = null;

            var posFixoNomeArquivo = leituras.DadosLeituras.Select(x => x.AlunoLeituraCronogramaNome).FirstOrDefault().Replace("/", "-");
            var nomeArquivo = "FORMULARIOS DE LEITURA CRONOGRAMA_" + posFixoNomeArquivo + ".pdf";
            var newEntry = new ZipEntry(nomeArquivo.Replace("/", "-"));
            newEntry.DateTime = DateTime.Now;

            zipStream.PutNextEntry(newEntry);

            bytes = CriarPDF(leituras);

            MemoryStream inStream = new MemoryStream(bytes);
            StreamUtils.Copy(inStream, zipStream, new byte[4096]);
            inStream.Close();
            zipStream.CloseEntry();

            zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

            outputMemStream.Position = 0;

            return File(outputMemStream.ToArray(), "application/octet-stream", "reports.zip");

            #region Método original

            // MemoryStream outputMemStream = new MemoryStream();
            // ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            // zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
            // byte[] bytes = null;

            // // loops through the PDFs I need to create
            // var tpdfs = 10;
            // for (var i =0; i < tpdfs; i++)
            // {
            //     var newEntry = new ZipEntry("test" + i + ".pdf");
            //     newEntry.DateTime = DateTime.Now;

            //     zipStream.PutNextEntry(newEntry);

            //     bytes = CreatePDF(++i);

            //     MemoryStream inStream = new MemoryStream(bytes);
            //     StreamUtils.Copy(inStream, zipStream, new byte[4096]);
            //     inStream.Close();
            //     zipStream.CloseEntry();
            // }

            // zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            // zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

            // outputMemStream.Position = 0;

            // return File(outputMemStream.ToArray(), "application/octet-stream", "reports.zip");

            #endregion

            #region Método adaptado
            // MemoryStream outputMemStream = new MemoryStream();
            // ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            // zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
            
            // var newEntry = new ZipEntry("test.pdf");
            // newEntry.DateTime = DateTime.Now;

            // zipStream.PutNextEntry(newEntry);

            // byte[] bytes = zipFileMemoryStream.ToArray();

            // MemoryStream inStream = new MemoryStream(bytes);
            // StreamUtils.Copy(inStream, zipStream, new byte[4096]);
            // inStream.Close();
            // zipStream.CloseEntry();

            // zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            // zipStream.Close();

            // outputMemStream.Position = 0;
            // return File(outputMemStream.ToArray(), "application/octet-stream");
            #endregion

            #region Método antigo
            // byte[] byteInfo = zipFileMemoryStream.ToArray();
            // zipFileMemoryStream.Write(byteInfo, 0, byteInfo.Length);
            // zipFileMemoryStream.Position = 0;

            // var response = new FileStreamResult(zipFileMemoryStream, "application/pdf");

            // string folderName = "Uploads";
            // string newPath = System.IO.Path.Combine(webRootPath, folderName);

            // return response;

            // #region Código para colocar todos os pdfs criados em um arquivo comprimido zip.
            // string folderName = "Uploads";
            // string webRootPath = _webHostEnvironment.WebRootPath;
            // string newPath = System.IO.Path.Combine(webRootPath, folderName);

            // var botFilePaths = Directory.GetFiles(newPath);
            
            // using (ZipArchive archive = new ZipArchive(zipFileMemoryStream, ZipArchiveMode.Update, leaveOpen: true))
            // {
            //     foreach (var botFilePath in botFilePaths)
            //     {
            //         var botFileName = Path.GetFileName(botFilePath);
            //         var entry = archive.CreateEntry(botFileName);
            //         using (var entryStream = entry.Open())
            //         using (var fileStream = System.IO.File.OpenRead(botFilePath))
            //         {
            //             await fileStream.CopyToAsync(entryStream);
            //         }
            //     }
            // }

            // zipFileMemoryStream.Seek(0, SeekOrigin.Begin);
            // #endregion
            
            // return File(zipFileMemoryStream, "application/octet-stream", "Bots.zip");
            #endregion Método antigo
        }

        [Route("get-rel-avaliacao")]
        [HttpPost]
        public async Task<IActionResult> GetRelAvaliacao([FromBody]AlunoLeituraRelAvaliacaoRequestModel
                                                         alunoLeituraRelAvaliacaoRequestModel)
        {
            var leituras = await _alunoLeituraManager
                                    .GetAllForRelAvaliacaoAsync(alunoLeituraRelAvaliacaoRequestModel);
        
            #region Generals validations
            if (leituras.DadosLeituras.Count() > 0 &&
                leituras.DadosLeituras.Count() < 
                alunoLeituraRelAvaliacaoRequestModel.LeiturasIds.Count())
                return BadRequest("Uma ou mais leituras selecionadas não estão aptas para geração de RELATÓRIO DE AVALIAÇÃO. </br>Seleciona somente leituras avaliadas.");

            if (alunoLeituraRelAvaliacaoRequestModel.LeiturasIds != null &&
                alunoLeituraRelAvaliacaoRequestModel.LeiturasIds.Count() > 0 &&
                leituras.DadosLeituras.Count() <= 0)
                return NotFound("A (s) leitura (s) selecionada (s) não está (ão) apta (s) para geração de RELATÓRIO DE AVALIAÇÃO.</br>Verique se ela (s) já foi (ram) avaliada (s).");

            if (leituras == null || leituras.DadosLeituras.Count <= 0)
                return NotFound("Nenhuma leitura encontrada para geração de RELATÓRIO DE AVALIAÇÃO.");
            #endregion

            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression
            byte[] bytes = null;

            String posFixoNomeArquivo;
            try
            {
                posFixoNomeArquivo = leituras.DadosLeituras.Select(x => x.AlunoLeituraCronogramaNome).FirstOrDefault().Replace("/", "-");
            }
            catch { throw new Exception("Problemas ao criar o nome do arquivo. Tente novamente mais tarde."); }

            var nomeArquivo = "RELATORIO (S) AVALIACAO_CRONOGRAMA_" + posFixoNomeArquivo + ".pdf";
            var newEntry = new ZipEntry(nomeArquivo.Replace("/", "-"));
            newEntry.DateTime = DateTime.Now;

            zipStream.PutNextEntry(newEntry);

            bytes = CriarPDFForRelatorioLeitura(leituras);

            MemoryStream inStream = new MemoryStream(bytes);
            StreamUtils.Copy(inStream, zipStream, new byte[4096]);
            inStream.Close();
            zipStream.CloseEntry();

            zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

            outputMemStream.Position = 0;

            return File(outputMemStream.ToArray(), "application/octet-stream", "reports.zip");
        }
        #endregion

        #region Métodos principais Leituras
        [Authorize(Roles = "Master, Alunos-Leituras_Todos, Alunos-Leituras_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Novo([FromBody]AlunoLeituraViewModel alunoLeituraViewModel)
        {
            var commandSend  = await _alunoLeituraManager.AddAsync(alunoLeituraViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Todos, Alunos-Leituras_Novos")]
        [Route("novos")]
        [HttpPost] 
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Novos([FromBody]AlunoLeituraNovosRequestViewModel 
                                                alunoLeituraNovosRequestViewModel)
        {
            var result = new AlunoLeituraNovosResponseViewModel();
            try
            {
                result = await _alunoLeituraManager
                                        .AddsAsync(alunoLeituraNovosRequestViewModel);
            }
            catch { throw; }
            return Ok(result);
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Todos, Alunos-Leituras_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Edicao([FromBody]AlunoLeituraViewModel alunoLeituraViewModel)
        {
            var commandSend  = await _alunoLeituraManager.UpdateAsync(alunoLeituraViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoLeituraViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Todos, Alunos-Leituras_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]AlunoLeituraViewModel alunoLeituraViewModel)
        {
            var commandSend  = _alunoLeituraManager.Remove((Guid)alunoLeituraViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoLeituraViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Todos, Alunos-Leituras_Lista")]
        [Route("lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListaAsync([FromForm] DataTableServerSideRequest request)
        {
            //Quando o método for acionado por uma busca
            //Deverá identificar qual o tipo de dado, afim de direcionar a coluna de pesquisa
            //Permitindo assim somente pesquisa de uma condicional (Ipen/Nome)
            if (!request.Search.Value.IsNullOrEmpty())
            {
                var valueSearch = request.Search.Value;

                if (NumericHelpers.HasNumber(valueSearch))
                {
                    //havendo numeros na string
                    //deixo ativado somente o searcheable do ipen
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "AlunoLeitor.Aluno.Detento.Ipen")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "AlunoLeitor.Aluno.Detento.Nome")
                            item.Searchable = false;
                    }
                }
            }

            // var result = new DataTableServerSideResult<AlunoLeituraViewModel>();
            // try
            // {
            //     result = await _alunoLeituraManager
            //                                 .GetWithDataTableResultAsync(request);
            // }
            // catch { throw; }
            // return Ok(result);

            var result = await _alunoLeituraManager
                                    .GetWithDataTableResultAsync(request);
            
            var resultOrdered = result
                                    .Data
                                    .OrderByDescending(x => x.AlunoLeituraCronograma.AnoReferencia)
                                    .ThenBy(x => x.AlunoLeituraCronograma.PeriodoReferencia);

            return Ok(new { 
                data = resultOrdered,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }
        
        [Route("get-by-chave-leitura")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByChaveLeituraAsync([FromBody] string chaveLeitura)
        {
            #region Required validations
            try
            {
                if (chaveLeitura.IsNullOrEmpty())
                    throw new ArgumentException("Chave leitura requerida.");

                if (chaveLeitura.Count() >= 11)
                    throw new Exception("Limite máximo de caracter ultrapassado. </br>Informe no máximo 10 caracteres para a chave da leitura");                
            }
            catch { throw; }
            #endregion

            var result = new AlunoLeituraViewModel();
            try
            {
                result = await _alunoLeituraManager
                                        .GetByChaveLeituraAsync(chaveLeitura);
            }
            catch { throw; } 
            return Ok(result);
        }

        [Route("get-livro-for-edicao")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetLivroForEdicao([FromBody] string alunoLeituraId)
        {
            try
            {
                #region Validações de obrigatoriedade
                if (alunoLeituraId.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Id da leitura requerido");
                    return CustomResponse(_validationResult);
                }
                #endregion Validações de obrigatoriedade

                var commandSend = _alunoLeituraManager
                                        .GetLivroForEdicao(alunoLeituraId);

                if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);
                
                if (commandSend.Objects != null || !commandSend.Objects.Any())
                foreach (var obj in commandSend.Objects)
                    AddObject(obj);

                return CustomResponse(commandSend);
            }
            catch { throw; } 
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Todos, Alunos-Leituras_Avaliacao")]
        [Route("avaliacao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Avaliacao([FromBody]AlunoLeituraViewModel alunoLeituraViewModel)
        {
            var commandSend  = _alunoLeituraManager.Avaliar(alunoLeituraViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);
            
            return CustomResponse(commandSend);
        }
        
        [Route("get-cronograma-id")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCronogramaIdAsync([FromBody] string alunoLeituraId)
        {
            Guid result;
            try
            {
                #region Required validations
                if (alunoLeituraId.IsNullOrEmpty())
                    throw new ArgumentException("Id da leitura requerido.");
                #endregion    

                result = await _alunoLeituraManager
                                        .GetCronogramaIdAsync(Guid.Parse(alunoLeituraId));

                return Ok(result);
            }
            catch { throw; } 
        }
        #endregion

        #region Métodos principais Leituras Cronogramas
        [Authorize(Roles = "Master, Alunos-Leituras-Cronogramas_Todos,"+
                           "Alunos-Leituras-Cronogramas_Novo")]
        [Route("cronogramas/novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CronogramaNovo([FromBody]AlunoLeituraCronogramaViewModel 
                                            alunoLeituraCronogramaViewModel)
        {
            var commandSend  = await _alunoLeituraCronogramaManager
                                        .AddAsync(alunoLeituraCronogramaViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Alunos-Leituras-Cronogramas_Todos, "+
                           "Alunos-Leituras-Cronogramas_Edicao")]
        [Route("cronogramas/edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CronogramaEdicao([FromBody]AlunoLeituraCronogramaViewModel
                                                 alunoLeituraCronogramaViewModel)
        {
            var commandSend = await _alunoLeituraCronogramaManager
                                        .UpdateAsync(alunoLeituraCronogramaViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoLeituraCronogramaViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leituras-Cronogramas_Todos, "+
                           "Alunos-Leituras-Cronogramas_Delete")]
        [Route("cronogramas/delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CronogramaDelete([FromBody]AlunoLeituraCronogramaViewModel
                                                alunoLeituraCronogramaViewModel)
        {
            var commandSend  = _alunoLeituraCronogramaManager
                                .Remove((Guid)alunoLeituraCronogramaViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoLeituraCronogramaViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leituras-Cronogramas_Todos,"+
                           "Alunos-Leituras-Cronogramas_Lista")]
        [Route("cronogramas/lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CronogramaLista([FromForm] DataTableServerSideRequest request)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new DataTableServerSideResult<AlunoLeituraCronograma>();
            try
            {
                result = await _context
                                .AlunosLeiturasCronogramas
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .OrderBy(x => x.AnoReferencia)
                                .GetDatatableResultAsync(request);  
            }
            catch { throw; }

            IEnumerable<AlunoLeituraCronogramaViewModel> dataMapped = new List<AlunoLeituraCronogramaViewModel>();
            try
            {
                dataMapped = _mapper.Map<IEnumerable<AlunoLeituraCronogramaViewModel>>(result.Data);
            }
            catch { throw; }

            var data = new {
                data = dataMapped
            };
        
            return Ok(new {
                Data = data,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }

        [Route("cronogramas/get-datas-by-periodo-referencia")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CronogramaGetDatasByPeriodoReferencia([FromBody] AlunoLeituraCronogramaRequestPeriodosViewModel
                                                                              alunoLeituraCronogramaRequestPeriodosViewModel)
        {
            try
            {
                if (alunoLeituraCronogramaRequestPeriodosViewModel.AnoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ano referência requerido.");
                    return CustomResponse(_validationResult);
                }

                if (alunoLeituraCronogramaRequestPeriodosViewModel.PeriodoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Período referência requerido.");
                    return CustomResponse(_validationResult);
                }

                var ar = DateTime.Parse(alunoLeituraCronogramaRequestPeriodosViewModel
                                        .AnoReferencia + "/" + "01" + "/" + "01").Date.Year;
                var pr = Convert.ToInt32(alunoLeituraCronogramaRequestPeriodosViewModel.PeriodoReferencia);

                var commandSend = _context.AlunosLeiturasCronogramas
                                            .Select(x => new {
                                                AnoReferencia = x.AnoReferencia,
                                                PeriodoReferencia = x.PeriodoReferencia,
                                                PeriodoInicio = x.PeriodoInicio.ToString("dd/MM/yyyy"),
                                                PeriodoFim = x.PeriodoFim.ToString("dd/MM/yyyy")
                                            })
                                            .FirstOrDefault(x => x.PeriodoReferencia == pr &&
                                                            x.AnoReferencia.Date.Year == ar);
                return CustomResponse(commandSend);
            }
            catch { throw; }            
        }

        [Route("cronogramas/get-by-nome")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CronogramaGetByNome([FromBody] string nome)
        {
            try
            {
                if (nome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Nome requerido.");
                    return CustomResponse(_validationResult);
                }

                var commandSend = _context.AlunosLeiturasCronogramas
                                            .FirstOrDefault(x => x.Nome == nome);
                
                if (commandSend != null)
                {
                    var alcMapped = _mapper
                        .Map<AlunoLeituraCronogramaViewModel>(commandSend);
                    
                     return CustomResponse(alcMapped);
                }
                else
                {
                    return CustomResponse(commandSend);
                }
            }
            catch { throw; }            
        }

        [Route("cronogramas/get-all-for-select2")]
        public async Task<IActionResult> CronogramaGetAllForSelect2Async()
        {
            try
            {
                var result = await _alunoLeituraCronogramaManager
                                        .GetAllForSelect2Async();
                return CustomResponse(result);
            }
            catch { throw; }
        }
        #endregion Métodos principais Leituras Cronogramas
    }
}