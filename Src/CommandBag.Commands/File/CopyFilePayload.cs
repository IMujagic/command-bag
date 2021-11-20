using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Commands.File
{
    public class CopyFilePayload
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
    }
}
