﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class SeqAppender :LoggerServiceBase
    {
        public SeqAppender() : base("SeqAppender")
        {

        }
    }
}