﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
namespace SpellSpell
{
    public class AddScore
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Highscore { get; set; }

    }
}
