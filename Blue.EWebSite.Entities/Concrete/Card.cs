﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.EWebSite.Entities.Concrete
{
    public class Card
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<Card> Cards { get; set; }
    }
}
