﻿using System.ComponentModel.DataAnnotations;

namespace ResturantAPI.Models;
public class Menu
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int RestId { get; set; }
}