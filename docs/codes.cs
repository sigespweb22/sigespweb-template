#region Intersect and Except example

 string[] dataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
string[] dataSource2 = { "India", "uk", "Canada", "France", "Japan" };
//Method Syntax
var MS = dataSource1.Intersect(dataSource2).ToList();
var MSExcept = dataSource1.Except(dataSource2).ToList();
//Query Syntax
var QS = (from country in dataSource1
            select country)
            .Intersect(dataSource2).ToList();
            
foreach (var item in QS)
{
    Console.WriteLine(item);
}

#endregion

#region Code Controller Pattern
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using DataTablePaginationEFCore.Context;
// using DataTablePaginationEFCore.Models.Entities;
// using DataTablePaginationEFCore.Helpers.DataTable;

namespace DataTablePaginationEFCore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataTablePaginationEFCoreContext _context;

        public ProductsController(DataTablePaginationEFCoreContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Product.ToListAsync());
            return View();
        }

        public async Task<IActionResult> List([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.Product.GetDatatableResultAsync(request);
            return Json(result);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Description,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}

#endregion

#region Select@ - Personalizar mensagem busca quando dados são obtidos via ajax
$( "#select2" )
.select2({
     formatInputTooShort: "Please add more text"
});

Agora, se você quiser inserir um texto que varie, dependendo de algumas regras, você pode fazer o seguinte:

function input_length()
{
     var length = $( .select2-search-field ).find(input ).val().length;
     if( length < 6 )
     {
          if( length == 5 )
          {
               return "One character left.";
          }
          else
          {
               return "Add " + ( 6 - length ) + " characters.";
          }
     }
}

$( "#select2" )
.select2({
     formatInputTooShort: function ( args )
     {
          return input_length();
     }
});

A função será executada toda vez que você escrever algo na entrada.
#endregion


#region Datatable Helpers
//Efetua busca via código
$("#dt-basic-example").dataTable().api().search('123456').draw();
#endregion


#region Benchmark para extração de números de string
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Program>();
    }


    [Benchmark]
    [Arguments("42, starting with a number.")]
    [Arguments("With a number 42 in the middle.")]
    [Arguments("The secret number is 42.")]
    [Arguments("42")]
    public int ExtractIntUsingRegex(string input)
    {
        var number = Regex.Match(input, @"d+").Value;
        return int.Parse(number);
    }

    
    Regex numberExtractor;
    [GlobalSetup]
    public void GlobalSetup()
    {
        numberExtractor = new Regex(@"d+", RegexOptions.Compiled);
    }

    [Benchmark]
    [Arguments("42, starting with a number.")]
    [Arguments("With a number 42 in the middle.")]
    [Arguments("The secret number is 42.")]
    [Arguments("42")]
    public int ExtractIntUsingCompiledRegex(string input)
    {
        var number = numberExtractor.Match(input).Value;
        return int.Parse(number);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static (int Start, int Length) GetNumberPosition(string s)
    {
        var start = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                start = i;
                break;
            }
        }

        for (int i = start + 1; i < s.Length; i++)
        {
            if (!char.IsDigit(s[i]))
            {
                return (start, i - start);
            }
        }

        return (start, s.Length - start);
    }

    [Benchmark]
    [Arguments("42, starting with a number.")]
    [Arguments("With a number 42 in the middle.")]
    [Arguments("The secret number is 42.")]
    [Arguments("42")]
    public int ExtractIntUsingSubstring(string input)
    {
        var position = GetNumberPosition(input);
        return int.Parse(input.Substring(position.Start, position.Length));
    }

    [Benchmark]
    [Arguments("42, starting with a number.")]
    [Arguments("With a number 42 in the middle.")]
    [Arguments("The secret number is 42.")]
    [Arguments("42")]
    public int ExtractIntUsingSpan(string input)
    {
        var position = GetNumberPosition(input);
        var numberSpan = input.AsSpan(position.Start, position.Length);
        return int.Parse(numberSpan);
    }
}
#endregion

#region Identity
//verificar se o usuário tem a hole;
var userInRole = await _userManager.IsInRoleAsync(user, role);
#endregion

#region POSTGRESQL - USING em DELETE e UPDATE

//EXEMPLO testado e funcionando com DELETE e UPDATE
DELETE FROM public."Colaboradores" AS cl
USING public."ContasCorrentes" AS co, public."Lancamentos" AS lc
WHERE cl."Id" = co."ColaboradorId"
AND co."Id" = lc."ContaCorrenteId"
AND lc."ValorLiquido"='0.00';

UPDATE public."Colaboradores" SET "DemissaoOcorrencia"=1, "Situacao"=3 
FROM "Detentos" WHERE "Detentos"."Id" = "Colaboradores"."DetentoId" AND "Detentos"."Galeria"='I';

#endregion


#region Criar atributo

//Class para criação do atributo
public class DisplayStringAttribute : Attribute
{
    private readonly string value;
    public string Value
    {
        get { return value; }
    }

    public DisplayStringAttribute(string val)
    {
        value = val;
    }
}

//Uso do atributo
public enum MyState 
{ 
    [DisplayString("Ready")]
    Ready, 
    [DisplayString("Not Ready")]
    NotReady, 
    [DisplayString("Error")]
    Error 
};

//Conversor
public class EnumDisplayNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        Type t = value.GetType();
        if (t.IsEnum)
        {
            FieldInfo fi = t.GetField(value.ToString());
            DisplayStringAttribute[] attrbs = (DisplayStringAttribute[])fi.GetCustomAttributes(typeof(DisplayStringAttribute),
                false);
            return ((attrbs.Length > 0) && (!String.IsNullOrEmpty(attrbs[0].Value))) ? attrbs[0].Value : value.ToString();
        }
        else
        {
            throw new NotImplementedException("Converter is for enum types only");
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

#endregion

#region EFCORE Update somente em um campo da tabela

Usuario novoUsuario = new Usuario();
novoUsuario.Email = "fernando@hotmail.com";
novoUsuario.Nome = "Fernando Henrique";

using (Contexto dataBase = new Contexto())
{
    dataBase.Usuarios.Add(novoUsuario);
    dataBase.SaveChanges();
}
            
novoUsuario.Email = "fernando@outlook.com";

using (Contexto dataBase = new Contexto())
{
    dataBase.Usuarios.Attach(novoUsuario);

    // Marcar a propriedade E-Mail como modificada
    dataBase.Entry(novoUsuario).Property(u => u.Email).IsModified = true;

    dataBase.SaveChanges();
}
#endregion

#region Endereço documentação javascript
https://www.dofactory.com/javascript/design-patterns/factory-method
#endregion


#region Task.Run
// Declare, assign, and start the antecedent task.
Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

// Execute the continuation when the antecedent finishes.
await taskA.ContinueWith(antecedent => Console.WriteLine($"Today is {antecedent.Result}."));
#endregion

#region JQUERY - Evento keypress e key down
@* if ($(e.target).is('input, textarea')) {
    return;   
}
if (e.which === 119) doSomething(); *@

var ctrlPressed = false;
$(window).keydown(function(evt) {
    if (evt.which == 17) { // ctrl
        ctrlPressed = true;
    }
    }).keyup(function(evt) {
    if (evt.which == 17) { // ctrl
        ctrlPressed = false;
    }
});

@* function KeyPress(e) {
    var evtobj = window.event? event : e
    if (evtobj.keyCode == 90 && evtobj.ctrlKey) alert("Ctrl+z");
}

document.onkeydown = KeyPress; *@

#endregion

#region EXPRESSÃO REGULAR
//Testar email
^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$

//REGEX de data testado e funcionando
Regex r = new Regex(@"^(\d{1,2}\/\d{1,2}\/\d{4})$");
                                        
//class Regex Repesents an immutable regular expression.
// string[] str = { "+91-9678967101", "9678967101", "+91-9678-967101", "+91-96789-67101", "+919678967101" };
string[] str = { 
        "01/01/2021 ", 
        "01/01/2021",
        "010-001/20021",
        "10-001/20",
        "100-01/20",
        "100-001/2000",
        "01-01-2021",
        "01/01/2021",
        "01-01-2022" };

//Input strings for Match valid mobile number.
foreach (string s in str)
{
    Console.WriteLine("{0} {1} a valid mobile number.", s,
    r.IsMatch(s) ? "is" : "is not");
    //The IsMatch method is used to validate a string or
    //to ensure that a string conforms to a particular pattern.
}
#endregion

#region DATATABLE - SEARCH - ALTERA COMPORTAMENTO DO CAMPO SEARCH DA DATATABLE

// @* $('#dt-basic-example_filter input').unbind(); *@
// 			$('#dt-basic-example_filter input').bind('keyup', function(e) {
// 				$('#dt-basic-example_filter input').val($('#dt-basic-example_filter input').val().toUpperCase());

// 				@* if(e.keyCode == 13) {
// 					myTable.fnFilter(this.value);
// 				} *@
// 			});
#endregion

#region OrderBy and ThenBy
public class EFSortHelper
{
  public static EFSortHelper<TModel> Create<TModel>(IQueryable<T> query)
  {
    return new EFSortHelper<TModel>(query);
  }
}  

public class EFSortHelper<TModel> : EFSortHelper
{
  protected IQueryable<TModel> unsorted;
  protected IOrderedQueryable<TModel> sorted;

  public EFSortHelper(IQueryable<TModel> unsorted)
  {
    this.unsorted = unsorted;
  }

  public void SortBy<TCol>(Expression<Func<TModel, TCol>> sort, bool isDesc = false)
  {
    if (sorted == null)
    {
      sorted = isDesc ? unsorted.OrderByDescending(sort) : unsorted.OrderBy(sort);
      unsorted = null;
    }
    else
    {
      sorted = isDesc ? sorted.ThenByDescending(sort) : sorted.ThenBy(sort)
    }
  }

  public IOrderedQueryable<TModel> Sorted
  {
    get
    {
      return sorted;
    }
  }
}
#endregion

#region SUMMERNOTE - BUTTON CUSTOM
var tags = [];

$(document).ready(function() {
  $(function() {
    $.material.init();
  });


  var myEditor = $('#myEditor');
  $(myEditor).summernote({
    height:200,
    toolbar: [
      ['style', ['bold', 'italic', 'underline', 'clear']],
    ],    
    callbacks: {
      onInit: function() {
        var customButton = '<div class="note-file btn-group">' +
          '  <button id="myButton" type="button" class="btn btn-default btn-sm btn-small" title="My Trigger" tabindex="-1">engage</button>' +
          '</div>'
        ;
        $(customButton).appendTo($('.note-toolbar'));  

        $('#myButton').click(function(event) {
          var editor = $('#myEditor');
          if (editor.summernote('isEmpty') === false) {
            var r = editor.summernote('createRange');
            tags.push(r.toString());
            r.pasteHTML('<span style="background-color:yellow;" data-tag-index="' + tags.length +'">' + r.toString() + '</span>');
            var c = editor.summernote('code');               
            $('#results').val(c);          
          }
        });
      }
    }      
  });  
}); 
#endregion

#region MVC - Padrão de retorno para requests que retornam um objeto ou erros dos serviços - CustomResponde via API
dotnetvar commandSend  = _alunoLeituraManager.GetByIdAsync(null);

            if (commandSend.Exception != null)
                if (commandSend.Exception.InnerExceptions != null)
                    foreach (var error in commandSend.Exception.InnerExceptions.Select(x => x.Message))
                        AddError(error);

            return CustomResponse(commandSend);
#endregion

#region Leitor PdfReader e REGEX
// System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
            // using (PdfReader leitor = new PdfReader(fullPath))
            // {
            //     StringBuilder texto = new StringBuilder();
            //     var ipens = new List<string>();

            //     for (int i = 1; i <= leitor.NumberOfPages; i++)
            //     {
            //         var pg = PdfTextExtractor.GetTextFromPage(leitor, i);
                    
            //         //(xx) xxxxx-xxxx
            //         // Hoje em dia, todos os telefones celulares no Brasil têm nove dígitos e iniciam com o dígito 9 e todos os telefones fixos têm 8 dígitos e nunca iniciam com o dígito 9. Eu pessoalmente preferiria formatar o telefone como (xx) xxxxx-xxxx. Assim sendo, a melhor expressão regular para isso seria essa:

            //         // ^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$
            //         // A explicação completa dela é:

            //         // ^ - Início da string.
            //         // \( - Um abre parênteses.
            //         // [1-9]{2} - Dois dígitos de 1 a 9. Não existem códigos de DDD com o dígito 0.
            //         // \) - Um fecha parênteses.
            //         // - Um espaço em branco.
            //         // (?:[2-8]|9[1-9]) - O início do número. Representa uma escolha entre um dígito de 2 a 8 (a parte do [2-8]) e de um 9 seguido de um dígito de 1 a 9 (a parte do 9[1-9]). O | separa as opções a serem escolhidas. O (?: ... ) agrupa tais escolhas. Telefones fixos começam com dígitos de 2 a 8. Telefones celulares começam com 9 e têm um segundo dígito de 1 a 9. O primeiro dígito nunca será 0 ou 1. Celulares não podem começar com 90 porque esse é o prefixo para ligações a cobrar.
            //         // [0-9]{3} - Os demais três dígitos da primeira metade do número do telefone, perfazendo um total de 4 ou 5 dígitos na primeira metade.
            //         // \- - Um hífen.
            //         // [0-9]{4} - A segunda metade do número do telefone.
            //         // $ - Final da string.
            //         // Se você quiser deixar os parênteses, o espaço em branco e hífen opcionais, então você pode colocar um ? após cada um desses símbolos, resultando nesta expressão regular:
            //         /// ^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$

            //         Regex codigoAreaPattern = new Regex(@"\([1-9]{2}\)");
            //         Regex firstNumeroTelefone = new Regex(@"\([1-9]{2}\)\s\d{9}\s");
            //         Regex ipenPattern = new Regex(@"\s[0-9]{6,6}\s");
            //         // => \s\[D\]\sCelular:\s\([1-9]{2}\) [1-9]{9}
                        
                        //Se você quiser realmente casar qualquer coisa até uma letra seguida por um ), ou o fim da string, pode usar esta RegExp:   (regexr.com)
                        //([\s\S]+?(?=\b[a-z][)]|$))
                        // [\s\S] é uma maneira de casar todos os caracteres, incluindo quebras de linha.
                        // Normalmente, usaríamos a flag singleline para alterar o comportamento do ponto, mas não existe no ASP.

                        // (?=…) é um lookahead (dá uma "espiada" adiante), garantindo que foi seguido por uma letra e um ), ou pelo final da string. Mas tem a peculiaridade de corresponder ao padrão, enquanto não faz parte do fragmento casado.

                        // \b é uma borda de palavra.

                        // No entanto, essa expressão não é muito eficiente, especialmente com textos longos, e pode dar um falso positivo com casos como: "pergunta (veja o segmento b) pergunta".


                        // Tendo em conta que cada resposta é precedida por (pelo menos) uma quebra de linha, pode usá-lo como uma condição adicional. Desta forma, podemos combinar linhas inteiras, desde que uma linha interna não comece com [a-z][)].

                        //Captura antes e depois da virgula
                        //(("[\w\s,]*")(,)?)|([\w\s\+]*(,)?)

            //         var codigoAreaPatternTest = codigoAreaPattern.Matches(pg);
            //         var ipenPatternTest = ipenPattern.Matches(pg);
            //         var firstNumeroTelefoneTest = firstNumeroTelefone.Matches(pg);

            //         var iPens = ipenPatternTest;

            //         codigoAreaPatternTest = null;
            //         ipenPatternTest = null;
                    
            //         // texto.Append(PdfTextExtractor.GetTextFromPage(leitor, i));
            //     }
            // }
#endregion Leitor PdfReader e REGEX

#region DELETE WITH JOIN POSTGRESQL
DELETE FROM "Detentos" a
  WHERE EXISTS (SELECT 1 FROM "Detentos" b 
      WHERE a."Ipen" = b."Ipen" 
        AND a."Id" < b."Id");
		
#endregion

#region C# - BUILD EXPRESSION
//Expression explicit
var terms = title.Split(' ').ToList();
items = items.Where(w => terms.Contains(w.ItemName)); // IN clause.

//Expression build
var terms = title.Split(' ').ToList();
Expression<Func<Item, bool>> predicate = (Item) => false;
foreach(var term in terms)
    predicate = predicate.Or(x => x.ItemName.Contains(term));

items = items.Where(predicate);

#endregion

#region Exception POSTGRESQL EFCORE
try
{
    _context.Add(entity);
    await _context.SaveChangesAsync().ConfigureAwait(false);
    return RedirectToAction(nameof(Index));
}
catch (DbUpdateException ex)
{
    if (ex.GetBaseException() is PostgresException pgException)
    {
        switch (pgException.SqlState)
        {
            case "23505":
                ModelState.AddModelError(string.Empty, "This entity exists in the database");
                return View(yourViewModelFromRequest);
            default:
                throw;
         }
     }
}
#endregion

#region QUERY DUPLICADOS

/// testada e funcionando
SELECT embalagem, sabor, count(*) as quantidade
FROM tabela_de_produtos
GROUP BY embalagem, sabor
HAVING count(*) > 1;

SELECT "AlunoId", COUNT(*)
FROM "AlunosLeitores"
GROUP BY "AlunoId"
HAVING count(*) > 1;
/// 

SELECT "Id", Ipen", "Nome", "IsDeleted", COUNT("Ipen") AS a
FROM "Detentos" GROUP BY "Ipen", "Nome", "IsDeleted"
HAVING COUNT("Ipen") > 1;
#endregion

#region LINQ - CONSULTA BRUTA
var searchTerm = "Lorem ipsum";

var blogs = context.Blogs
    .FromSqlInterpolated($"SELECT * FROM dbo.SearchBlogs({searchTerm})")
    .Where(b => b.Rating > 3)
    .OrderByDescending(b => b.Rating)
    .ToList();

var searchTerm = "Lorem ipsum";

var blogs = context.Blogs
    .FromSqlInterpolated($"SELECT * FROM dbo.SearchBlogs({searchTerm})")
    .Include(b => b.Posts)
    .ToList();

https://docs.microsoft.com/pt-br/ef/core/querying/raw-sql
#endregion

#region FOREACH - ITERAR SABENDO A POSIÇÃO DO ELEMENTO
foreach (var cela in celas.Select((value, i) => new { i, value }))
                {
                    if (celas.Count() == cela.i + 1)
                    {
                        createWhereForConsult = createWhereForConsult + "d.\"Cela\"=" + "\'" + cela.value + "\'" + ") ORDER BY d.\"Cela\"";
                    }
                    else
                    {
                        createWhereForConsult = createWhereForConsult + "d.\"Cela\"=" + "\'" + cela.value + "\'" + " OR ";
                    }
                }
#endregion

#region UPDATE COM JOIN EM POSTGRESQL TESTADO E FUNCIONANDO
/* POSTGRESQL NÃO ACEITA A CLÁUSULA JOIN EM UPDATE COMO O MYSQL*/
/* É PRECISO INCLUIR O FROM, CONFORME ABAIXO*/

/** UPDATE "AlunosLeituras" SET "LeituraTipo" = 1
FROM "AlunosLeitores", "Alunos", "Detentos"
WHERE 
"AlunosLeitores"."Id" = "AlunosLeituras"."AlunoLeitorId" AND
"Alunos"."Id" = "AlunosLeitores"."AlunoId" AND
"Detentos"."Id" = "Alunos"."DetentoId" AND
"Detentos"."Ipen" = 729949; **/
#endregion

#region QUERY PARA UPDATE DAS LEITURAS
/** 
SELECT a."IsAvaliado", a."DataAvaliacao", a."AvaliacaoConceito", a."AvaliacaoCriterio1", a."AvaliacaoCriterio2",
a."AvaliacaoCriterio3", a."AvaliacaoCriterio4",
a."AvaliacaoCriterio5", a."AvaliacaoCriterio6", 
a."AvaliacaoCriterio7" FROM public."AlunosLeituras" AS a
JOIN "AlunosLeitores" AS b ON b."Id" = a."AlunoLeitorId"
JOIN "Alunos" AS c ON c."Id" = b."AlunoId"
JOIN "Detentos" AS d ON d."Id" = c."DetentoId"
JOIN "AlunosLeiturasCronogramas" AS e ON e."Id" = a."AlunoLeituraCronogramaId"
WHERE d."Galeria" = 'F' AND
e."Id" = '7291658f-ace5-4bbf-a9b8-fc4b0eff9b11' AND
a."AvaliacaoConceito" != 1;**/

/** UPDATE "AlunosLeituras" SET "IsAvaliado" = true
FROM "AlunosLeitores", "Alunos", "Detentos", "AlunosLeiturasCronogramas"
WHERE 
"AlunosLeitores"."Id" = "AlunosLeituras"."AlunoLeitorId" AND
"Alunos"."Id" = "AlunosLeitores"."AlunoId" AND
"Detentos"."Id" = "Alunos"."DetentoId" AND
"AlunosLeiturasCronogramas"."Id" = "AlunosLeituras"."AlunoLeituraCronogramaId" 
AND
"Detentos"."Galeria" = 'F' AND
"AlunosLeiturasCronogramas"."Id" = '7291658f-ace5-4bbf-a9b8-fc4b0eff9b11' AND
"AlunosLeituras"."AvaliacaoConceito" != 1; **/
#endregion

#region MODAL IN RIGHT SCREEN
.modal.fade:not(.in).right .modal-dialog {
    -webkit-transform: translate3d(25%, 0, 0);
    transform: translate3d(25%, 0, 0);
}

<link href="http://netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script src="http://netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>

<div id="myModal" class="modal fade right">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;<span class="sr-only">Close</span></button>
        <h4 class="modal-title">Modal title</h4>
      </div>
      <div class="modal-body">
        <p>Modal body</p>
      </div>
    </div>
  </div>
</div>

<a class="btn btn-primary" data-toggle="modal" data-target="#myModal">Open modal from the right</a>
#endregion

#region DATATABLE - Obter row selecionada a partir do botão edit
var tableToQuery = $("#dt-basic-example").DataTable();
var selectedRow = $("#dt-basic-example tr.selected");
var row = tableToQuery.row(selectedRow).data();
#endregion

#region UPDATE WITH JOIN
SELECT a.idIngresso,
       a.idDetento,
       b.nome,
       a.isAtivo
  FROM ingressos AS a
       JOIN
       detentos AS b ON b.idDetento = a.idDetento
 WHERE b.galeria = "D" AND 
       cela = 11;
       
UPDATE ingressos
   SET isAtivo = 1
 WHERE ingressos.idIngresso IN (
    SELECT ingressos.idIngresso
      FROM ingressos
           LEFT JOIN
           detentos ON detentos.idDetento = ingressos.idDetento
     WHERE detentos.galeria = "D" AND 
           detentos.cela = 11
);
#endregion

#region DATATABLE OBTER LINHA (ROW) PARA EDIÇÃO OU OUTRAS OPERAÇÃO
var tableToQuery = $("#dt-basic-example").DataTable();
var selectedRow = $("#dt-basic-example tr.selected");
var row = tableToQuery.row(selectedRow).data();
#endregion

#region COMENTÁRIO PADRÃO PARA REFACTORING DE CONTEXTO DE BANCO
/// <summary>
/// To ContextDB refactoring
/// </summary>
#endregion

#region SignalR - Methods
// Send message client especific by userId
await _canalDeNotificacao.Clients.User("5625b761-68e1-42c2-bd22-aa747e21e988").SendAsync("VagasPorDesistencia", mensagem);

// Send message all clients
await _canalDeNotificacao.Clients.User("5625b761-68e1-42c2-bd22-aa747e21e988").SendAsync("VagasPorDesistencia", mensagem);
#endregion

#region UPDATE WITH JOIN
SELECT a.idIngresso,
       a.idDetento,
       b.nome,
       a.isAtivo
  FROM ingressos AS a
       JOIN
       detentos AS b ON b.idDetento = a.idDetento
 WHERE b.galeria = "D" AND 
       cela = 11;
       
UPDATE ingressos
   SET isAtivo = 1
 WHERE ingressos.idIngresso IN (
    SELECT ingressos.idIngresso
      FROM ingressos
           LEFT JOIN
           detentos ON detentos.idDetento = ingressos.idDetento
     WHERE detentos.galeria = "D" AND 
           detentos.cela = 11
);
#endregion