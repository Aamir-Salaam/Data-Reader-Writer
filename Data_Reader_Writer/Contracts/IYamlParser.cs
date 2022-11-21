﻿using Data_Reader_Writer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Contracts
{
    public interface IYamlParser
    {
        List<YamlProduct> ParseFromStream();
    }
}