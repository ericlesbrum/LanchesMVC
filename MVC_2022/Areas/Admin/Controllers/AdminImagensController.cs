using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC_2022.Models;

namespace MVC_2022.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize("Admin")]
public class AdminImagensController : Controller
{
    private readonly ConfigurationImagens _configurationImagens;
    private readonly IWebHostEnvironment _hostEnvironment;

    public AdminImagensController(IOptions<ConfigurationImagens> configurationImagens, IWebHostEnvironment hostEnvironment)
    {
        _configurationImagens = configurationImagens.Value;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> UploadFiles(List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
        {
            ViewData["Erro"] = "Error: Arquivos(s) não selecionado(s)";
            return View(ViewData);
        }

        if (files.Count > 10)
        {
            ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
            return View(ViewData);
        }

        long size = files.Sum(f => f.Length);

        var filePathsName = new List<string>();
        var filePath = GetFilePath();

        foreach (var formFile in files)
        {
            if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".png"))
            {
                var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);
                filePathsName.Add(fileNameWithPath);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
        }

        ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " + $"com tamanho total de :{size} bytes";

        ViewBag.Arquivos = filePathsName;

        return View(ViewData);
    }

    public IActionResult GetImagens()
    {
        FileManagerModel model = new FileManagerModel();

        var filePath = GetFilePath();

        DirectoryInfo dir = new DirectoryInfo(filePath);

        FileInfo[] files = dir.GetFiles();

        model.PathImagesProdutos = _configurationImagens.NomePastaImagensProdutos;

        if (files.Length == 0)
        {
            ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {filePath}";
        }

        model.Files = files;
        return View(model);
    }

    public IActionResult DeleteFile(string fileName)
    {
        var filePath = GetFilePath();
        string _imagemDeletada = Path.Combine(filePath + "\\", fileName);
        if (System.IO.File.Exists(_imagemDeletada))
        {
            System.IO.File.Delete(_imagemDeletada);

            ViewData["Deletado"] = $"Arquivo(s){_imagemDeletada} deletado com sucesso";
        }
        return View("Index");
    }

    private string GetFilePath()
    {
        return Path.Combine(_hostEnvironment.WebRootPath, _configurationImagens.NomePastaImagensProdutos);

    }
}
