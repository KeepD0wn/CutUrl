﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShortUrl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ShortUrl
{
    public class UniqUrlAttribute : ValidationAttribute
    {          
        public UniqUrlAttribute()
        {
            ErrorMessage = "Такая короткая ссылка уже существует";            
        }

        public override bool IsValid(object value)
        {
            try
            {
                string val = value.ToString().Trim();
                foreach (var obj in LinksContext.LinksList)
                {
                    if (obj.ShortUrl == val)
                    {
                        return false;
                    }
                }                
            }
            catch
            {
                
            }
            return true;
        }
    }
}
