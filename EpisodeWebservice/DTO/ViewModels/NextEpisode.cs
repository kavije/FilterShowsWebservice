﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpisodeWebservice.DTO.ViewModels
{
    public class NextEpisode
    {
        public NextEpisode()
        {
            date = new DateTime();
        }
        public object channel { get; set; }
        public string channelLogo { get; set; }
        public object date { get; set; }
        public string html { get; set; }
        public string url { get; set; }

    }
}