using Api.App.DataTypes;
using Api.Infrastructure.Generators.Schemas;
using Api.Infrastructure.Generators.Schemas.Enums;
using Api.Infrastructure.Persistent.Models.Documents;
using System.Reflection;

namespace Api.App.Common;

internal static class DocumentSchema
{
    public static IReadOnlyList<SchemaCatalogEntity> Catalog { get; } = new SchemaCatalogEntity[]
        {
            new("Входящий документ", CreateIncomingDocumentSchema()),
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
        };

    public static bool IsValidCatalogIndex(int index) => index >= 0 && index < Catalog.Count;

    private static PropertyInfo GetProperty<T>(string name) where T : new()
    {
        var property = typeof(T).GetProperty(name);
        ArgumentNullException.ThrowIfNull(property);
                
        return property;
    }

    /// <summary>
    /// Входящий документ
    /// </summary>
    private static RootSchemaGenerator CreateIncomingDocumentSchema()
    {
        var schema = SchemaDocumentGenerator.CreateSchema(typeof(IncomingDocumentModel));

        schema.AddPanel(e => e
                .AddTextLine(GetProperty<IncomingDocumentModel>(nameof(IncomingDocumentModel.MailSender)), "Отправитель письма")
                .AddList(GetProperty<IncomingDocumentModel>(nameof(IncomingDocumentModel.MailType)), "Тип письма", SourceListEntity.Mail)
                .AddDateOnly(GetProperty<IncomingDocumentModel>(nameof(IncomingDocumentModel.RegisteredAt)), "Дата регистрации")
                .AddDateOnly(GetProperty<IncomingDocumentModel>(nameof(IncomingDocumentModel.OutcomingAt)), "Исходящая дата")
                .AddNuberLine(GetProperty<IncomingDocumentModel>(nameof(IncomingDocumentModel.MailRegistrationNumber)), "Регистрационный номер письма")
                .AddNuberLine(GetProperty<IncomingDocumentModel>(nameof(IncomingDocumentModel.OutcomingNumber)), "Исходящий номер"))
            .AddPanel(e => e.AddTextBox(GetProperty<IncomingDocumentModel>(nameof(IncomingDocumentModel.BriefContentOfMail)), "Краткое содержание письма"));
        // .AddPanel(e => e.AddFile(nameof(IncomingDocumentModel.), "Файл", SourceFileEntity.Documents));

        return schema;
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
