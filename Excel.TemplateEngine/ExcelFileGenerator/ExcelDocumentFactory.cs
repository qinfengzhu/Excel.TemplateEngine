﻿using System;

using JetBrains.Annotations;

using SKBKontur.Catalogue.ExcelFileGenerator.Implementation.Primitives;
using SKBKontur.Catalogue.ExcelFileGenerator.Interfaces;
using SKBKontur.Catalogue.Objects;

using Vostok.Logging.Abstractions;

namespace SKBKontur.Catalogue.ExcelFileGenerator
{
    public static class ExcelDocumentFactory
    {
        [CanBeNull]
        public static IExcelDocument TryCreateFromTemplate([NotNull] byte[] template, [NotNull] ILog logger)
        {
            var excelFileGeneratorLogger = logger.ForContext("ExcelFileGenerator");
            try
            {
                return new ExcelDocument(template, excelFileGeneratorLogger);
            }
            catch (Exception ex)
            {
                excelFileGeneratorLogger.Error($"An error occurred while creating of {nameof(ExcelDocument)}: {ex}");
                return null;
            }
        }

        [NotNull]
        public static IExcelDocument CreateFromTemplate([NotNull] byte[] template, [NotNull] ILog logger)
        {
            var result = TryCreateFromTemplate(template, logger);
            return result ?? throw new InvalidProgramStateException($"An error occurred while creating of {nameof(ExcelDocument)}");
        }

        [NotNull]
        public static IExcelDocument CreateEmpty(bool useXlsm, [NotNull] ILog logger)
        {
            if (useXlsm)
                return CreateFromTemplate(GetFileBytes("empty.xlsm"), logger);
            return CreateFromTemplate(GetFileBytes("empty.xlsx"), logger);
        }

        private static byte[] GetFileBytes(string filename)
        {
            return typeof(ExcelDocumentFactory).Assembly.ReadAllBytesFromResource(filename);
        }
    }
}