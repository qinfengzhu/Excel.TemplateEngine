using SkbKontur.Excel.TemplateEngine.FileGenerating.DataTypes;

namespace SkbKontur.Excel.TemplateEngine.FileGenerating.Caches
{
    internal interface IExcelDocumentStyle
    {
        uint AddStyle(ExcelCellStyle style);
        ExcelCellStyle GetStyle(int styleIndex);
    }
}