using AutoMapper;
using Data_Reader_Writer.Contracts;
using Data_Reader_Writer.Helpers;
using Data_Reader_Writer.Logic.Mappers;
using Data_Reader_Writer.Logic.Readers;
using Data_Reader_Writer.Logic.Writers;
using Data_Reader_Writer.Models;
using Data_Reader_Writer.Repositories;
using Microsoft.Extensions.PlatformAbstractions;
using System.Text;

namespace Data_Reader_Writer
{
    class Program
    {
        private ProductInfoRepository productInfoRepository;
        private static Mapper GenericMapper;

        public Program()
        {
            productInfoRepository = new ProductInfoRepository();
            GenericMapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddMaps("Data_Reader_Writer"); }));
        }

        public static void Main(string[] args)
        {
            var program = new Program();

            program.Process(args);
        }

        public void Process(string[] fileNames)
        {
            Console.WriteLine("Parsing files:");

            foreach (var fileName in fileNames)
            {
                var filePath = PathHelper.GetPath(fileName);
                var productInfoList = new List<ProductInfo>();

                try
                {
                    if (fileName.Contains("yaml"))
                    {
                        var parser = new YamlParser(filePath);

                        Console.WriteLine($"\nImport: {filePath} \n");

                        var yamlProductDataList = parser.ParseFromStream();

                        foreach (var product in yamlProductDataList)
                        {
                            var productInfo = GenericMapper.Map<ProductInfo>(product);

                            productInfoList.Add(productInfo);
                        }
                    }
                    else if (fileName.Contains("json"))
                    {
                        var parser = new JsonParser(filePath);
                        var jsonProductDataList = parser.ParseFromStream();

                        Console.WriteLine($"\nImport: {filePath} \n");

                        foreach (var product in jsonProductDataList)
                        {
                            var productInfo = GenericMapper.Map<ProductInfo>(product);

                            productInfoList.Add(productInfo);
                        }
                    }

                    var writer = new MySqlWriter();

                    foreach (var entry in productInfoList)
                    {
                        writer.WriteToDb(entry, productInfoRepository);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
