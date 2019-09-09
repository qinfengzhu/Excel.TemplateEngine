using System;

using Excel.TemplateEngine.Helpers;
using Excel.TemplateEngine.ObjectPrinting.RenderCollection.Renderers;
using Excel.TemplateEngine.ObjectPrinting.RenderingTemplates;

using JetBrains.Annotations;

namespace Excel.TemplateEngine.ObjectPrinting.RenderCollection
{
    public class RendererCollection : IRendererCollection
    {
        public RendererCollection(ITemplateCollection templateCollection)
        {
            this.templateCollection = templateCollection;
        }

        [NotNull]
        public IRenderer GetRenderer([NotNull] Type modelType)
        {
            if (modelType == typeof(string))
                return new StringRenderer();
            if (modelType == typeof(int))
                return new IntRenderer();
            if (modelType == typeof(decimal))
                return new DecimalRenderer();
            if (modelType == typeof(double))
                return new DoubleRenderer();
            if (TypeCheckingHelper.IsEnumerable(modelType))
                return new EnumerableRenderer(this);
            return new ClassRenderer(templateCollection, this);
        }

        [NotNull]
        public IFormControlRenderer GetFormControlRenderer([NotNull] string typeName, [NotNull] Type modelType)
        {
            if (typeName == "CheckBox" && modelType == typeof(bool))
                return new CheckBoxRenderer();
            if (typeName == "DropDown" && modelType == typeof(string))
                return new DropDownRenderer();
            throw new InvalidProgramStateException($"Unsupported pair of typeName ({typeName}) and modelType ({modelType}) for form controls");
        }

        private readonly ITemplateCollection templateCollection;
    }
}