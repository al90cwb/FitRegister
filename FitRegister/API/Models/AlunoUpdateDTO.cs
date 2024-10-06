using System;

namespace API.Models;

public class AlunoUpdateDTO
 {
        public string Id { get; set; } // O Id do aluno é obrigatório para localizar o registro

        public string? Nome { get; set; } // Nome pode ser atualizado ou deixado como null
        public string? Endereco { get; set; } // Endereço pode ser atualizado ou deixado como null
        public string? Telefone { get; set; } // Telefone pode ser atualizado ou deixado como null
        public string? Login { get; set; } // Login pode ser atualizado ou deixado como null
        public string? Senha { get; set; } // Senha pode ser atualizada ou deixada como null
        public DateTime? DataDuracao { get; set; } // Data de duração pode ser atualizada ou deixada como null
        public string? ProfessorId { get; set; } // O Id do Professor associado pode ser atualizado ou deixado como null
    }
