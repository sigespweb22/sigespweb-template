// ** Toolkit imports
import alunoLeitorApiServices from "../api-services/aluno-leitor-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace AlunoLeitorStoreService {
    // ** 
    // Inativa todos os alunos e lança ocorrência de desistência FIM_ANO_LETIVO
    // **
    export const encerrarAnoLetivoAsync = () => {
        const request = axios.put(`${alunoLeitorApiServices.encerrarAnoLetivoAsync}`)
        return request
    }
}