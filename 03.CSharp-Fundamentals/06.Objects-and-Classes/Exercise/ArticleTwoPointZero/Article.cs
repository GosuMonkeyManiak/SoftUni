using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleTwoPointZero
{
    class Article
    {
        private string title;
        private string content;
        private string author;

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public Article(string title, string content, string author)
        {
            this.title = title;
            this.content = content;
            this.author = author;
        }

        public override string ToString()
        {
            return $"{this.title} - {this.content}: {this.author}";
        }

    }
}
