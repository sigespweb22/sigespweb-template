// ** Toolkit imports
import oficioEducacaoApiServices from "../api-services/oficio-educacao-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace OficioEducacaoStoreService {
    // ** Cancelar oficío leitura
    export const leituraCancelarAsync = (oficio: string) => {
        const request = axios.delete(`${oficioEducacaoApiServices.leituraCancelarAsync}${oficio}`, {})
        return request
    }

    // ** Reimprimir oficío leitura
    export const leituraReimprimirAsync = (oficio: string) => {
        const request = axios.get(`${oficioEducacaoApiServices.leituraReimprimirAsync}${oficio}`, {
            responseType: 'arraybuffer',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        return request
    }
}