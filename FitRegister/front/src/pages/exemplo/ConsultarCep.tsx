import React, { useEffect ,useState} from "react";

function ConsultarCep(){
    const [cep, setCep] = useState('');
    const [logradouro, setLogradouro] = useState('');
    const [localidade, setLocalidade] = useState('');
    const [estado, setEstado] = useState('');
    const [error, setError] = useState('');


    const buscarEndereco = async()=>{
        try {
            const response = await fetch(`https://viacep.com.br/ws/${cep}/json/`);
            if (!response.ok) {
                throw new Error("Erro ao buscar os dados");
            }

            const endereco = await response.json();
            if (endereco.erro) {
                throw new Error("CEP não encontrado");
            }

            setLogradouro(endereco.logradouro); // Armazenar o logradouro no estado
            setLocalidade(endereco.localidade); // Armazenar o localidade no estado
            setEstado(endereco.estado); // Armazenar o estado no estado
            setError(''); // Limpar erro se a busca for bem-sucedida

        } catch (err) {

            const errorMessage = (err as Error).message; // Asserção de tipo
            setError(errorMessage); // Armazenar a mensagem de erro
            setLogradouro(''); // Limpar logradouro em caso de erro
            setLocalidade(''); // Limpar logradouro em caso de erro
            setEstado(''); // Limpar logradouro em caso de erro
        }

    }

   
    
    useEffect(()=> {
        //evento de carreamento do componente 
        //executar codigo ao reinderizar o componente
        //Axios - biblioteca de requisições
            fetch("https://viacep.com.br/ws/81150210/json/")
                .then(resposta => resposta.json())
                .then(endereco => {console.log(endereco.logradouro 
                    + "/" + endereco.localidade 
                    + "/" + endereco.estado) });
    });

    function digitar (event : any){ //vai armazenanado o valor na variavel
        console.log(event.target.value);
        setCep(event.target.value);
    }

    return (
        <div>
            <h1>Consultar CEP</h1>
            <input 
                type="text" 
                placeholder="Digite o CEP" 
                value={cep} 
                //onChange={(e){ => setCep(e.target.value)} // Atualizar o estado com o valor do input em uma linha
                onChange= {digitar}
                //onBlur= {buscarEndereco}
            />
            <button onClick={buscarEndereco}>Buscar</button> {/* Botão para buscar o endereço */}
            {error && <p style={{ color: 'red' }}>{error}</p>} {/* Exibir erro se houver */}
            {logradouro && <p>Estado: {estado}</p>} {/* Exibir logradouro se houver */}
            {logradouro && <p>Cidade: {localidade}</p>} {/* Exibir logradouro se houver */}
            {logradouro && <p>Logradouro: {logradouro}</p>} {/* Exibir logradouro se houver */}
        </div>
    );
}

export default ConsultarCep;

//EXERICICIOS
// 1 - EXIBIR OS DADOS NO HTML / PAGINA
// 2 - REALIZAR A REQUISIÇÃO PARA A SUA API
// 3 - RESOLVER O PROBLMEA DE CORS
// 4 - EXIBIR A LSITA DE RPDUOTS NO HTML