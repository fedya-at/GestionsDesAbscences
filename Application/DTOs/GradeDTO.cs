﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GradeDTO
    {
        public int CodeGrade { get; set; }
        public string? NomGrade { get; set; }
    }
}