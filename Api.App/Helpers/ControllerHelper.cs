using Api.App.DataTypes;

namespace Api.App.Helpers;

internal static class ControllerHelper
{
    internal static void NormalizeLimitAndOffset(ref int limit, ref int offset)
    {
        if (limit < 0 || limit > 100) limit = 100;
        if (offset < 0) offset = 0;
    }
}
