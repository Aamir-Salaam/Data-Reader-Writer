using Data_Reader_Writer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Reader_Writer.Contracts
{
    public interface IJsonParser
    {
        /// <summary>
        /// Parse json stream data into list of <see cref="JsonProduct"/>
        /// </summary>
        /// <returns>list of <see cref="JsonProduct"/></returns>
        List<JsonProduct> ParseFromStream();
    }
}
