using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMBO.Models
{
    public class Musica
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Titulo é obrigatório.")]
        [MaxLength(400, ErrorMessage = "Máximo 400 caracteres.")]
        [Remote("VerificarTitulo", "Musica", ErrorMessage = "Essa música já existe.")]
        public string Titulo { get; set; }
        public Categoria Categoria { get; set; }
        public TipoMidia TipoMidia { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}