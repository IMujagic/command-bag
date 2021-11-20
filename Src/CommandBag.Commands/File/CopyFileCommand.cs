using CommandBag.Common;
using CommandBag.Core;
using CommandBag.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Commands.File
{
    [CommandGroup("File")]
    [CommandDescription("Copy files from source to target location")]
    public class CopyFileCommand : IDomainCommand<CopyFilePayload>
    {
        public Result Execute(CopyFilePayload payload)
        {
            return Result.Ok();
        }
    }
}
