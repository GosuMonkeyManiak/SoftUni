﻿namespace FootballManager.Services.Models
{
    public class PlayerDto
    {
        public int Id { get; init; }

        public string FullName { get; init; }

        public string ImageUrl { get; init; }

        public string Position { get; init; }

        public byte Speed { get; init; }

        public byte Endurance { get; init; }

        public string Description { get; init; }
    }
}
