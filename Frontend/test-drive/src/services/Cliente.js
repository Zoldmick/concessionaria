import axios from 'axios'

const api = axios.create({
    baseURL:'http://localhost:5000'
})

export default class Cliente {

    async ConsultarPorID(id){
        const response = await api.get(`/Cliente/${id}`)
        return response.data
    }

    async Cadastrar({Email, Senha, Nome, Cpf, Nascimento, Endereco, Telefone, Celular, Residencia, Deficiencia, Cnh, Imagem}){
        const f = new FormData()
        console.log("Bem-vindo cliente")
        f.append('Email',Email) 
        f.append('Senha',Senha) 
        f.append('Nome',Nome) 
        f.append('Nascimento',Nascimento)
        f.append('Cpf',Cpf)
        f.append('Endereco',Endereco)
        f.append('Telefone',Telefone) // string
        f.append('Celular',Celular) // string
        f.append('Residencia',Residencia) // Numero de residencia -- int
        f.append('Deficiencia',Deficiencia) 
        f.append('Cnh',Cnh) // int
        f.append('Imagem',Imagem)
        
        const response = await api.post(`/Cliente`,f,{
            headers: {'content-type' : 'multipart/form-data'}
        })

        return response.data
    }

    BuscarFoto(nome){
        const response =  api.get(`/Cliente/Foto/${nome}`)
        return response.data
    }

    async ConsultarClientes(nome){ // funcionario
        const response = await api.get(`/Cliente/Clientes?nome=${nome}`)
        return response;
    }

    async Deletar(id){
        const response = await api.delete(`/Cliente/${id}`)
        return response.data
    }
}