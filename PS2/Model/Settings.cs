using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2.Model
{
    public class Settings
    {
        public string LineageWindowTitle { get; set; }
        public string MainLineageClientPath { get; set; }
        public string AlternativeLineageClientPath { get; set; }

        public bool RenameClientWindow { get; set; }
        public bool LoginUpToCharacter { get; set; }

    }
}
