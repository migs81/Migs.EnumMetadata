using System;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using Migs.EnumMetadata;
using Migs.EnumMetadata.Benchmarks;
using Migs.EnumMetadata.Benchmarks.TestData;

_ = BenchmarkRunner.Run<Benchmarks>();

EnumMetadataConfig.UseCache = false;
var stopwatch = Stopwatch.StartNew();

for (var i = 0; i < 1_000_000; i++)
    _ = Enums.NameType.FirstName.GetAttribute<EnumMetadataAttribute>().Name;

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");

Console.WriteLine("Press any key...");
Console.ReadKey();
