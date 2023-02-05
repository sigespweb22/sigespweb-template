// ** Toolkit imports
import servidorEstadoApiServices from "../api-services/servidor-estado-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace ServidorEstadoStoreService {
    // ** Ativar by id
    export const ativarAsync = (id: string) => {
        const request = axios.post(`${servidorEstadoApiServices.ativarAsync}${id}`, {})
        return request
    }
}