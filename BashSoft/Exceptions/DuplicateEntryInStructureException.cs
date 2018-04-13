﻿using System;

namespace BashSoft.Exceptions
{
    public class DuplicateEntryInStructureException : Exception
    {
        private const string DuplicateEntry = "The {0} already exists in {1}.";

        public DuplicateEntryInStructureException(string entry, string structure)
            : base(string.Format(DuplicateEntry, entry, structure))
        {
        }

        public DuplicateEntryInStructureException(string message) : base(message)
        {
        }
    }
}
