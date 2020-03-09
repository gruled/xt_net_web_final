using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Entities
{
    public struct Asset
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public string Path { get; set; }
        public bool Moderated { get; set; }
        public int Size { get; set; }
        public string Version { get; set; }
        public string PatchNote { get; set; }
        public string Hierarchy { get; set; }
        public int Parent { get; set; }
    }
}
