// ** Api Imports
import formularioLeituraApiServices from "../api-services/formulario-leitura-api-service"

// ** Axios Imports
import axios from 'axios'

// ** Types Imports
import FormularioLeituraDicaEscritaDicaTypes from "../types/formularioLeituraDicaEscritaDicaTypes"

export namespace FormularioLeituraStoreService {
    // ** Grupo dica escrita

    // Ativa uma dica de  leitura
    export const dicaEscritaAtivarAsync = (dicaEscritaId: string) => {
        const request = axios.get(`${formularioLeituraApiServices.dicaEscritaAtivarAsync}${dicaEscritaId}`, {})
        return request
    }

    // Inativa uma dica de  leitura
    export const dicaEscritaInativarAsync = (dicaEscritaId: string) => {
        const request = axios.get(`${formularioLeituraApiServices.dicaEscritaInativarAsync}${dicaEscritaId}`, {})
        return request
    }

    // Lista grupos de dicas escrita ativas
    export const dicaEscritaListaAsync = () => {
        const request = axios.get(formularioLeituraApiServices.dicaEscritaListaToSelectAsync, {})
        return request
    }

    // ** Dica escrita dica

    // Dica escrita dica
    export const dicaEscritaDicaNovoAsync = (data: FormularioLeituraDicaEscritaDicaTypes) => {
        const headers = {
            'Content-Type': 'application/json'
        }

        const request = axios.post(formularioLeituraApiServices.dicaEscritaDicaNovoAsync, data, {headers: headers})
        return request
    }

    export const dicaEscritaDicaEdicaoAsync = (data:any) => {
        const headers = {
            'Content-Type': 'application/json'
        }

        const request = axios.put(formularioLeituraApiServices.dicaEscritaDicaEdicaoAsync, data, {headers: headers})
        return request
    }

    export const dicaEscritaDicaDeleteAsync = (id:string) => {
        const request = axios.delete(`${formularioLeituraApiServices.dicaEscritaDicaDeleteAsync}/${id}`, {})
        return request
    }
}