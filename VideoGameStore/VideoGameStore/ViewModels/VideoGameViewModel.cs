using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VGS.Shared.Entities;

namespace VideoGameStore.ViewModels
{
    public class VideoGameViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Escriba el titulo del videojuego")]
        [DisplayName("Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El año es requerido")]
        [DisplayName("Año")]
        public int Anho { get; set; }

        [DisplayName("Calificación")]
        public int Ranking { get; set; }

        [Required(ErrorMessage = "Seleccione el tipo de consola")]
        [DisplayName("Consola")]
        public int ConsoleId { get; set; }
        public IEnumerable<SelectListItem>? ConsoleList { get; set; }

        [Required(ErrorMessage = "Seleccione el genero del videojuego")]
        [DisplayName("Genero")]
        public int GenderId { get; set; }
        public IEnumerable<SelectListItem>? GenderList { get; set; }
        public IFormFile? ImageFile { get; set; }
        public String? Base64ImageFile { get; set; }
        public bool OpenModal { get; set; }
        public bool IsTableView { get; set; }
    }
}
