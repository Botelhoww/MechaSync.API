﻿namespace MechaSync.Domain;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Funcao { get; set; }
    public DateTime CreatedDate = DateTime.Now;
}