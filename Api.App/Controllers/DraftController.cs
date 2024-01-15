using Api.App.Common;
using Api.Domain.Requests.Drafts;
using Api.Infrastructure.Persistent;
using Microsoft.AspNetCore.Mvc;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class DraftController(DocumentSchema schema) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DraftRequest request, PersistentContext context)
    {
        if (schema.IsValidCatalogIndex(request.Document) is false)
            return BadRequest();

        var parsers = schema.Parsers[request.Document];

        var instance = Activator.CreateInstance(parsers.Model);
        ArgumentNullException.ThrowIfNull(instance);

        if (parsers.Parsers.Count != request.Values.Count)
            return BadRequest();

        foreach (var (parser, value) in parsers.Parsers.Zip(request.Values))
            parser.SetValue(instance, value);

        // save db

        return Ok();
    }
}


//public sealed record PostDraftRequest(int Document, IReadOnlyList<PostDraftRequest.PostDraftRequestRecord> Values)
//{
//    public sealed record PostDraftRequestRecord(object Value);
//}

//internal sealed class UserDataValidator(IReadOnlyList<PostDraftRequest.PostDraftRequestRecord> values)
//{
//    private int _index = 0;

//    internal bool TryValidate(SchemaGenerator schema) => RecursiveValidate(schema);

//    private bool RecursiveValidate(SchemaGenerator schema)
//    {
//        foreach (var item in schema.Entities)
//        {
//            if (item is PanelSchemaEntity panel)
//            {
//                if (RecursiveValidate(panel) is false)
//                    return false;

//                continue;
//            }

//            if (item is IEditableSchemaEntity entity && _index < values.Count)
//            {
//                var value = values[_index].Value;

//                var validator = entity.GetValidator();
//                validator.Validate(value, _index);

//                ++_index;
//                continue;
//            }

//            return false;
//        }

//        return true;
//    }
//}

//internal sealed class UserDataSetter(object instance, IReadOnlyList<PostDraftRequest.PostDraftRequestRecord> values)
//{
//    private readonly object _instance = instance;

//    private int _index = 0;

//    internal bool TrySet(RootSchemaGenerator schema) => TryRecursiveSet(schema);

//    private bool TryRecursiveSet(SchemaGenerator schema)
//    {
//        foreach (var item in schema.Entities)
//        {
//            if (item is PanelSchemaEntity panel)
//            {
//                if (TryRecursiveSet(panel) is false)
//                    return false;

//                continue;
//            }

//            if (item is IEditableSchemaEntity entity && _index < values.Count)
//            {
//                entity.SetValue(_instance, values[_index].Value);

//                var value = values[_index].Value;
//                entity.Property.SetValue(_instance, value);

//                ++_index;
//                continue;
//            }

//            return false;
//        }

//        return true;
//    }
//}

//[ApiController]
//[Route("[controller]")]
//public sealed class DraftController(DocumentSchema schema) : ControllerBase
//{
//    [HttpPost]
//    public async Task<IActionResult> Post([FromBody] PostDraftRequest request, PersistentContext context)
//    {
//        if (schema.IsValidCatalogIndex(request.Document) is false)
//            return BadRequest();

//        var schema = schema.Representatives[request.Document].Schema;

//        var validator = new UserDataValidator(request.Values);
//        if (validator.TryValidate(schema) is false)
//            return BadRequest("Ошибка настройки валидатора");

//        var instance = Activator.CreateInstance(schema.ModelType);
//        if (instance is null)
//            return BadRequest("Ошибка настройки схемы");

//        var setter = new UserDataSetter(instance, request.Values);
//        if (setter.TrySet(schema) is false)
//            return BadRequest("Ошибка структуры запроса");

//        //// save db

//        //var document = new DocumentModel();

//        return Ok();
//    }
//}
