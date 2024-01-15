using Api.App.Common;
using Api.Infrastructure.Generators.Schemas;
using Api.Infrastructure.Generators.Schemas.Entities;
using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Persistent;
using Microsoft.AspNetCore.Mvc;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class SchemaController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(DocumentSchema.Catalog);
}

public sealed record PostDraftRequest(int Document, IReadOnlyList<PostDraftRequest.Record> Values)
{
    public sealed record Record(object Value);
}

internal sealed class UserDataValidator(IReadOnlyList<PostDraftRequest.Record> values)
{
    private int _index = 0;

    internal bool TryValidate(SchemaGenerator schema) => RecursiveValidate(schema);

    private bool RecursiveValidate(SchemaGenerator schema)
    {
        foreach (var item in schema.Entities)
        {
            if (item is PanelSchemaEntity panel)
            {
                if (RecursiveValidate(panel) is false)
                    return false;

                continue;
            }

            if (item is IEditableSchemaEntity entity && _index < values.Count)
            {
                var value = values[_index].Value;

                var validator = entity.GetValidator();
                validator.Validate(value, _index);

                ++_index;
                continue;
            }

            return false;
        }

        return true;
    }
}

internal sealed class UserDataSetter(object instance, IReadOnlyList<PostDraftRequest.Record> values)
{
    private readonly object _instance = instance;

    private int _index = 0;

    internal bool TrySet(RootSchemaGenerator schema) => TryRecursiveSet(schema);
    
    private bool TryRecursiveSet(SchemaGenerator schema)
    {
        foreach (var item in schema.Entities)
        {
            if (item is PanelSchemaEntity panel)
            {
                if (TryRecursiveSet(panel) is false)
                    return false;

                continue;
            }

            if (item is IEditableSchemaEntity entity && _index < values.Count)
            {
                var value = values[_index].Value;
                entity.Property.SetValue(_instance, value);

                ++_index;
                continue;
            }

            return false;
        }

        return true;
    }
}

[ApiController]
[Route("[controller]")]
public sealed class DraftController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostDraftRequest request, PersistentContext context)
    {
        if (DocumentSchema.IsValidCatalogIndex(request.Document) is false)
            return BadRequest();

        var schema = DocumentSchema.Catalog[request.Document].Schema;

        var validator = new UserDataValidator(request.Values);
        if (validator.TryValidate(schema) is false)
            return BadRequest("Ошибка настройки валидатора");

        var instance = Activator.CreateInstance(schema.ModelType);
        if (instance is null)
            return BadRequest("Ошибка настройки схемы");

        var setter = new UserDataSetter(instance, request.Values);
        if (setter.TrySet(schema) is false)
            return BadRequest("Ошибка структуры запроса");

        //// save db

        //var document = new DocumentModel();

        return Ok();
    }
}
