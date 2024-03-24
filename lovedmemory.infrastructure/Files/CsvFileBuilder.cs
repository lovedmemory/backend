//using System.Globalization;
//using lovedmemory.Application.Common.Interfaces;
//using lovedmemory.Application.TodoLists.Queries.ExportTodos;
//using lovedmemory.Infrastructure.Files.Maps;
//using CsvHelper;

//namespace lovedmemory.Infrastructure.Files;

//public class CsvFileBuilder : ICsvFileBuilder
//{
//    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
//    {
//        using var memoryStream = new MemoryStream();
//        using (var streamWriter = new StreamWriter(memoryStream))
//        {
//            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

//            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
//            csvWriter.WriteRecords(records);
//        }

//        return memoryStream.ToArray();
//    }
//}
