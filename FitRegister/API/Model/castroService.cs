using System;

namespace API.Model;

public class castroService
{
    public bool efetuarCadastro(cadastroFactory factory){
        iCadastroUsuario cadastro = factory.cadastar();
        return cadastro.cadastrar();
    }

}
