﻿using BashSoft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Contracts
{
    public interface IStudent:IComparable<IStudent>
    {
        string UserName { get; set; }

        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        void EnrollInCourse(ICourse course);

        void SetMarksInCourse(string courseName, params int[] scores);

        
    }
}
