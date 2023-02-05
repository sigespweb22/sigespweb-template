// ** Toolkit imports
import servidorEstadoReforcoRegraApiServices from "../api-services/servidor-estado-reforco-regra-api-service"

// ** Axios Imports
import axios from 'axios'

export namespace ServidorEstadoReforcoRegraStoreService {
    // ** List One By Month
    export const listOneByMonthAsync = (data: string) => {
        const request = axios.get(`${servidorEstadoReforcoRegraApiServices.listOneByMonthAsync}/${data}`)
        return request
    }
}