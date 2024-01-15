using Api.App.DataTypes;
using Api.Infrastructure.Generators.Schemas;
using Api.Infrastructure.Generators.Schemas.DataTypes;
using Api.Infrastructure.Generators.Schemas.Enums;
using Api.Infrastructure.Persistent;
using Api.Infrastructure.Persistent.Models.Documents;

namespace Api.App.Common;

public sealed record DocumentSchemaCreationContext(List<List<SchemaCatalogEntity>> Representatives, List<SchemaEntityParser> Parsers)
{
    public void Create(Action<List<SchemaCatalogEntity>, List<SchemaEntityParser>> callable)
    {
        var representative = new List<SchemaCatalogEntity>();

        callable(representative, Parsers);

        Representatives.Add(representative);
    }
}

public sealed class DocumentSchema
{
    public IReadOnlyList<IReadOnlyList<SchemaCatalogEntity>> Representatives { get; }
    public IReadOnlyList<SchemaEntityParser> Parsers { get; } // IReadOnlyList<IParserSchemaEntity>

    public DocumentSchema(IServiceProvider provider)
    {
        var representatives = new List<List<SchemaCatalogEntity>>();
        var parsers = new List<SchemaEntityParser>();

        var ctx = new DocumentSchemaCreationContext(representatives, parsers);
        ctx.Create((representatives, parsers) => CreateIncomingDocumentSchema(representatives, parsers, provider));


        //new("Исходящий документ", CreateOutgoingDocumentSchema()),
        //new("Договор", CreateAgreementSchema()),
        //new("Доверенность", CreatePowerOfAttorneySchema()),
        //new("Приказы", CreateOrdersSchema()),
        //new("Обходной лист", CreateBypassSheetSchema()),
        //new("Заявка на мобилизацию", CreateApplicationForMobilizationSchema()),
        //new("Лист испытательного срока", CreateProbationPeriodSheetSchema()),
        //new("Заявка на командировку", CreateApplicationForABusinessTripSchema()),
        //new("Заявка на подбор персонала", CreateRecruitmentApplicationSchema()),
        //new("Заявка на проведения инструктажа", CreateApplicationForTrainingSchema()),
        //new("Акт списания ТМЦ", CreateInventoryWriteOffActSchema()),
        //new("Заявка на наряд заказ", CreateRequestForWorkPrderSchema()),
        //new("Служебная записка", CreateServiceMemoSchema()),
        //new("Заявка на транспорт", CreateApplicationForTransportSchema()),
        //new("Заявка на газификацию без СМР", CreateApplicationForGasificationWithoutConstructionAndInstallationWorkSchema()),
        //new("Заявка на газификацию с СМР", CreateApplicationForGasificationWithConstructionAndInstallationWorkSchema()),

        Representatives = representatives.Select(e => e.ToArray()).ToArray();
        Parsers = parsers.ToArray();
    }

    public bool IsValidCatalogIndex(int index) => index >= 0 && index < Representatives.Count;

    /// <summary>
    /// Входящий документ
    /// </summary>
    private static void CreateIncomingDocumentSchema(List<SchemaCatalogEntity> representatives, List<SchemaEntityParser> parsers, IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<PersistentContext>();

        var generator = new SchemaGenerator(typeof(IncomingDocumentModel));

        generator.AddPanel(panel => panel
            .AddTextLine(nameof(IncomingDocumentModel.MailSender), "Отправитель письма")
            .AddList(nameof(IncomingDocumentModel.MailType), context.DocumentList, "Тип письма")
            .AddDateOnly(nameof(IncomingDocumentModel.RegisteredAt), "Дата регистрации")
            .AddDateOnly(nameof(IncomingDocumentModel.OutcomingAt), "Исходящая дата")
            .AddNumberLine(nameof(IncomingDocumentModel.MailRegistrationNumber), "Регистрационный номер письма")
            .AddNumberLine(nameof(IncomingDocumentModel.OutcomingNumber), "Исходящий номер"));

        generator.AddPanel(e => e.AddTextBox(nameof(IncomingDocumentModel.BriefContentOfMail), "Краткое содержание письма"));

        // generator.AddPanel(e => e.AddFile(nameof(IncomingDocumentModel.), "Файл", SourceFileEntity.Documents));

        representatives.Add(new("Входящий документ", generator.BuildRepresentatives()));
        parsers.Add(generator.BuildParsers());
    }

    ///// <summary>
    ///// Исходящий документ
    ///// </summary>
    //private static RootSchemaGenerator CreateOutgoingDocumentSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Договор
    ///// </summary>
    //private static RootSchemaGenerator CreateAgreementSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Доверенность
    ///// </summary>
    //private static RootSchemaGenerator CreatePowerOfAttorneySchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Приказы
    ///// </summary>
    //private static RootSchemaGenerator CreateOrdersSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Обходной лист
    ///// </summary>
    //private static RootSchemaGenerator CreateBypassSheetSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на мобилизацию
    ///// </summary>
    //private static RootSchemaGenerator CreateApplicationForMobilizationSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Лист испытательного срока
    ///// </summary>
    //private static RootSchemaGenerator CreateProbationPeriodSheetSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на командировку
    ///// </summary>
    //private static RootSchemaGenerator CreateApplicationForABusinessTripSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на подбор персонала
    ///// </summary>
    //private static RootSchemaGenerator CreateRecruitmentApplicationSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на проведения инструктажа
    ///// </summary>
    //private static RootSchemaGenerator CreateApplicationForTrainingSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Акт списания ТМЦ
    ///// </summary>
    //private static RootSchemaGenerator CreateInventoryWriteOffActSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на наряд заказ
    ///// </summary>
    //private static RootSchemaGenerator CreateRequestForWorkPrderSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Служебная записка
    ///// </summary>
    //private static RootSchemaGenerator CreateServiceMemoSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на транспорт
    ///// </summary>
    //private static RootSchemaGenerator CreateApplicationForTransportSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на газификацию без СМР
    ///// </summary>
    //private static RootSchemaGenerator CreateApplicationForGasificationWithoutConstructionAndInstallationWorkSchema() => SchemaDocumentGenerator.CreateSchema();

    ///// <summary>
    ///// Заявка на газификацию с СМР
    ///// </summary>
    //private static RootSchemaGenerator CreateApplicationForGasificationWithConstructionAndInstallationWorkSchema() => SchemaDocumentGenerator.CreateSchema();
}
