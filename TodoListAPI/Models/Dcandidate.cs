using System;
using System.Collections.Generic;

namespace TodoListAPI.Models
{
    public partial class Dcandidate
    {
        public int Id { get; set; }
        public string Task { get; set; } = null!;
        public string Lvl { get; set; } = null!;
    }
}
