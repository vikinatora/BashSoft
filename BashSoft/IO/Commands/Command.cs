﻿using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;

namespace BashSoft.IO.Commands
{
    public abstract class Command:IExecutable
    {

        private string input;
        public string Input
        {
            get
            {
                return this.input;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        private string[] data;
        public string[] Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;          
        }

        public abstract void Execute();
    }
}
