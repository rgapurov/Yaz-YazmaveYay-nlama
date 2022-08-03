﻿namespace DersNote.Models
{
    public class Note
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string Content { get; set; }
            public bool IsPublish { get; set; }
            public Author Author { get; set; }
            public int AuthorId { get; set; }
            public Category Category { get; set; }
            public int CategoryId { get; set; }
            public Tag Tag { get; set; }
            public int TagId { get; set; }

    }
}
