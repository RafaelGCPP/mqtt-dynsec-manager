using System.Text.Json;

namespace mqtt_dynsec_manager.Helpers;

internal static class ObjectExtensions
{
    public static TObject DumpToConsole<TObject>(this TObject @object)
    {
        var output = "NULL";
        if (@object != null)
        {
            var jsonoptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            //jsonoptions.Converters.Add(new ResponseConverter());

            output = JsonSerializer.Serialize(@object, jsonoptions);
        }

        Console.WriteLine($"[{@object?.GetType().Name}]:\r\n{output}");
        return @object;
    }
}