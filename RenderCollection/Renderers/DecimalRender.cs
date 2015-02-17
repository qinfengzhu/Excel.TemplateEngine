﻿using SKBKontur.Catalogue.ExcelObjectPrinter.RenderingTemplates;
using SKBKontur.Catalogue.ExcelObjectPrinter.TableBuilder;

namespace SKBKontur.Catalogue.ExcelObjectPrinter.RenderCollection.Renderers
{
    public class DecimalRender : IRenderer
    {
        public void Render(ITableBuilder tableBuilder, object model, RenderingTemplate template)
        {
            var decimalToRender = (decimal)model;
            tableBuilder.RenderAtomicValue(decimalToRender);
        }
    }
}