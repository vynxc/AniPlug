using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniPlug.Models;

    public class MovieCollectionModel
    {
        public string name { get; set; }
        public ICollection<API_Wrappers.Consumet.Models.Movie> movies { get; set; }
    }
