//REGRAS PARA CRIAÇAÕ DE UM NOVO COMPONENTE
//1 - A primeira letra do componente deve ser Maiuscula
//2 - O componente DEVE ser um função
//3 - O componente DEVE retornar APENAS UM elemento HTML
//4 - Exportar o componenente

function ComponenteExemplo(){
    return (
        <div>
            <h1> Primeiro Post </h1>
            <p> Não há ninguém que ame a dor por si só, que a busque e queira tê-la, simplesmente por ser dor..</p>
            <button>Test</button>
        </div> 
    );
}

export default ComponenteExemplo;