﻿// Copyright (c) 2018 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;

namespace Wangkanai.Detection
{
    public class Crawler : ICrawler
    {
        public string Name { get; set; }
        public CrawlerType Type { get; set; }
        public IVersion Version { get; set; }

        public Crawler() { }
        public Crawler(string name)
        {
            Name = name;
            Type = GetType(name);
        }

        public Crawler(string name, string version) : this(name)
        {
            Version = new Version(version);
        }

        private CrawlerType GetType(string name)
        {
            name = name.ToLower();
            if (name == string.Empty || name == null)
                return CrawlerType.Others;

            if (name.Contains("google"))
                return CrawlerType.Google;
            if (name.Contains("bing"))
                return CrawlerType.Bing;
            if (name.Contains("baidu"))
                return CrawlerType.Baidu;
            if (name.Contains("yahoo"))
                return CrawlerType.Yahoo;

            return CrawlerType.Others;
        }
    }
}