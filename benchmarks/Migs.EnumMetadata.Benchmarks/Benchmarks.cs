using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using Migs.EnumMetadata.Benchmarks.TestData;

namespace Migs.EnumMetadata.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net80, baseline: true)]
    public class Benchmarks
    {
        [Benchmark]
        public void GetAttribute_WithCache_Benchmark()
        {
            EnumMetadataConfig.UseCache = true;
            _ = Enums.Color.Blue.GetAttribute<ColorAttribute>().Name;
        }

        [Benchmark]
        public void GetAttribute_WithoutCache_Benchmark()
        {
            EnumMetadataConfig.UseCache = false;
            _ = Enums.Color.Blue.GetAttribute<ColorAttribute>().Name;
        }

        [Benchmark]
        public void EnumToString_Benchmark()
        {
            _ = Enums.Color.None.ToString();
        }
    }
}
